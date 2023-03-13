using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PickUpDamageAndDoor : MonoBehaviour
{
    public Text CountText;
    private int count;
    public GameObject nextLevelTextObject;
    public GameObject notEnoughText;
    private GameObject[] pickUpCount;
    public AudioSource Collect;

    // Start is called before the first frame update
    void Start()
    {
        pickUpCount = GameObject.FindGameObjectsWithTag("PickUp");
        count = 0;
        SetCountText();
        nextLevelTextObject.SetActive(false);
        notEnoughText.SetActive(false);
    }

    void SetCountText()                                                     //Lukee kuinka monta collectiblea on ker‰tty ja jos niit‰ on ker‰tty 5 (eli kaikki t‰m‰nhetkinen max m‰‰r‰ objekteja)                                                                                       
    {                                                                       // NextLevelTextObjekti tulee unityss‰ aktiiviseksi ja n‰ytˆlle tulee teksti mik‰ unityss‰ siihen asetettu. 
        CountText.text = "Count:" + count.ToString();

        if (count >= pickUpCount.Length)
        {
            nextLevelTextObject.SetActive(true);
            Invoke("Wait", 5);
        }
    }

    void Wait()
    {
        nextLevelTextObject.SetActive(false);
        notEnoughText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {                                                              // jos pelaajaobjekti osuu pickUp t‰g‰ttyyn objektiin, se ker‰‰ sen
        if (collision.gameObject.CompareTag("PickUp"))             // sek‰ lis‰‰ counttiin +1 ja lukee sen void setCountTextiss‰. 
        {
            collision.gameObject.SetActive(false);
            Collect.Play();
            count = count + 1;
            SetCountText();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)                     
    {                                                                          
        if (collision.gameObject.CompareTag("Damage")) // Jos gameobject on t‰g‰tty damageksi ja pelaaja osuu, alla oleva if lauseke k‰ynnistyy. 
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().name);         // Menee takaisin starrtiin                                        
        }

        if(collision.gameObject.CompareTag("Door"))                            //P‰‰tt‰‰ mihin tasoon ovi johtaa perustuen nykyiseen tasoon.
        {
            if(count==pickUpCount.Length)
            {
                if(SceneManager.GetActiveScene().name == "Stage_1")
                {
                    SceneManager.LoadScene("Stage_2");
                }
                else if (SceneManager.GetActiveScene().name == "Stage_2")
                {
                    SceneManager.LoadScene("Stage_3");
                }
                else if (SceneManager.GetActiveScene().name == "Stage_3")
                {
                    SceneManager.LoadScene("Stage_4");
                }
                else if (SceneManager.GetActiveScene().name == "Stage_4")
                {
                    SceneManager.LoadScene("Cutscene2");
                }
            }
            else
            {
                notEnoughText.SetActive(true);
                Invoke("Wait", 5);
            }            
        }
    }
}
