using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    private Rigidbody2D eRB;

    void Start()
    {
        eRB = GetComponent<Rigidbody2D>();
    }

    
    void Update() //Vihollinen liikkuu sinne suuntaan minne katsoo
    {
        if(FacingRight())
        {
            eRB.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            eRB.velocity = new Vector2(-moveSpeed, 0f);
        }
    }
    private void OnTriggerExit2D(Collider2D collision) //Kääntää vihollisen suunnan kun on mennyt alla olevan platformin päähän
    {
        transform.localScale = new Vector2(-(Mathf.Sign(eRB.velocity.x)), transform.localScale.y);
    }
    private bool FacingRight()
    {
        return transform.localScale.x > .001f;
    }
}
