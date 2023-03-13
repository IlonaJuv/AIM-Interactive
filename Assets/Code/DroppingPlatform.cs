using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingPlatform : MonoBehaviour
{
    public GameObject square;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D (Collision2D Col) //Tippuu sekuntin jälkeen kun pelaaja on koskenut sitä
    {
        if (Col.gameObject.name.Equals ("Player"))
        {
            Invoke("DropPlatform", 0.5f);
            Destroy(gameObject, 1f);
        }
    }
   void DropPlatform() //Saa platformin tippumaan
    {
        rb.isKinematic = false;
    }
}
