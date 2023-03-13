using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallDeath : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) //kun triggeriin koskee..
    {
        if(other.CompareTag("Player")) //.. pelaajahahmo, ..
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //.. taso ladataan uudestaan
        }
    }
}
