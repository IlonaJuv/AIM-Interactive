using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement_Script : MonoBehaviour
{
    public float speed;                                 //Unityn puolella annettu arvo. K‰ytet‰‰n m‰‰r‰‰m‰‰n x akselin liikkeen voima.
    public float jumpForce;                             //Unityn puolella annettu arvo. K‰ytet‰‰n m‰‰r‰‰m‰‰n hypyn voima.
    private float xMovement;                            //Liikkumisen voima lasketaan ja tallenetaan t‰h‰n muuttujaan.
    private Rigidbody2D rb;                             //Pelaajan Rigidbody2D komponentti haetaan t‰h‰n.
    private Vector3 sivuttainLiike = Vector3.zero;      
    private float m_MovementSmoothing = .05f;           //Arvo, jota k‰ytet‰‰n liikkeen tasoittamiseen.
    private bool toJump = false;                        //Arvo, jolla kerrotaan halutaanko hyp‰t‰ vai ei.
    private float toGlide = 0;                          //Arvo, jolla kerrotaan halutaanko liit‰‰ vai ei.
    private bool m_FacingRight = true;                  //Pelaajan katseen suunnan selvitt‰miseen.
    public Animator animator;                           //referenssi Animator komponenttiin.
    private int jumpCount = 0;                          //arvo, joka kertoo hyppy toiminnolle voiko viel‰ hyp‰t‰.
    [SerializeField] private LayerMask WhatIsGround;    //muuttuja joka kertoo scriptille mik‰ on maata
    [SerializeField] private Transform GroundCheck;     //muuttuja johon liitet‰‰n groundcheck object
    const float GroundedRadius = 0.01f;                 //alue jonka sis‰lt‰ groundcheck tarkistaa maan
    private bool Grounded;                              //boolean joka kertoo sriptille onko pelaaja maassa vai ei
    private float glideTime = 1.4f;                     //Liit‰misen aikaraja
    public AudioSource Jump;
    public AudioSource Glide;
    public AudioSource Running;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() //FixedUpdate p‰ivit‰‰ synciss‰ pelimoottorin kanssa.
    {
        Grounded = false;
        //Tarkistaa ett‰ onko pelaaja maassa kiinni
        Collider2D[] colliders = Physics2D.OverlapCircleAll(GroundCheck.position, GroundedRadius, WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                Grounded = true;
            }
        }
        animator.SetBool("Grounded", Grounded);
        animator.SetFloat("YVelocity", rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(xMovement));
    }

    void Update()      // Updatessa haetaan pelaajan syˆtteet ja l‰hetet‰‰n ne Move() metodille.
    {
        xMovement = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
        toJump = Input.GetButtonDown("Jump");
        toGlide = Input.GetAxis("Vertical");
        Move(xMovement, toJump, toGlide);
    }

    public void Move(float move, bool jump, float glide)        //Ottaa vastaan pelaajan syˆtteet ja mik‰li niit‰ on liikuttaa pelaajaa.
    {
        if(move>0 && !Running.isPlaying && Grounded || move<0 && !Running.isPlaying && Grounded)
        {
            Running.Play();
        }
        else if(move == 0 || !Grounded)
        {
            Running.Stop();
        }
        //etsit‰‰n haluttu nopeus/voima:
        Vector3 targetVelocity = new Vector2(move * 10F, rb.velocity.y);
        //Tasoitetaan ja asetetaan pelaajaan:
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref sivuttainLiike, m_MovementSmoothing);

        
        if (jump == true)       //t‰ll‰ hyp‰t‰‰n. Tarkistaa halutaanko hyp‰t‰ ja ollaanko jo hyp‰tty kaksi kertaa.
        {
            rb.drag = 0;
            Vector2 JumpDirection = new Vector2(0, 1);
            if (jumpCount < 2)
            {
                Jump.Play();
                rb.velocity = new Vector2(rb.velocity.x, 0F);
                rb.AddForce(JumpDirection * jumpForce);
                jumpCount++;
            }

        }

        if (glide > 0 && !Grounded && rb.velocity.y <= 0 && glideTime > 0)     //Liito toiminto.
        {
            rb.drag = 10;
            glideTime = glideTime - Time.deltaTime;
            if(!Glide.isPlaying)
            {
                Glide.Play();
            }
            animator.SetBool("Gliding", true);
        }
        else
        {
            if(Glide.isPlaying)
            {
                Glide.Stop();
            }
            rb.drag = 0;
            animator.SetBool("Gliding", false);
        }

        //Jos liikkuu oikealle ja hahmon naama osoittaa vasemalle, k‰‰nn‰ hahmo
        if (move > 0 && !m_FacingRight)
        {
            // K‰‰nt‰‰ hahmon
            Flip();
        }
        //Jos liikkuu vasemmalle ja hahmon naama osoittaa oikealle, k‰‰nn‰ hahmo
        else if (move < 0 && m_FacingRight)
        {
            Flip();
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Grounded) //Kun pelaaja koskettaa jotain tasoa, tarkistetaan seisooko se maan p‰‰ll‰,
                      //jos vastaus on kyll‰, pelaajan hypyt ja liito aika resettaa.
        {
            glideTime = 1.4f;
            jumpCount = 0;
            rb.drag = 0;
        }
    }


    private void Flip()     //K‰‰nt‰‰ pelaajahahmon kutsuttaessa.
    {
        m_FacingRight = !m_FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

}
