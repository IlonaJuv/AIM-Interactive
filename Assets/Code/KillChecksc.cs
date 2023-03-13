using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillChecksc : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision) //lataa nykyisen tason uudellen jos koskee pelaajan
    {
        if(collision.gameObject.name == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
