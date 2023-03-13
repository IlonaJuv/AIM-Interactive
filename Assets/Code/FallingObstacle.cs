using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingObstacle : MonoBehaviour
{
    public GameObject Obstacle;
    Rigidbody2D rb;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

    }
    //tippuu kun pelaaja on alla
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = false;

        }
            
    }
    //Tuhoutuu kun koskee maahan tai piikkeihin
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("platform") || collision.gameObject.CompareTag("Damage") || collision.gameObject.CompareTag("Falling"))
        {
            Destroy(Obstacle);
        }
    }
}
