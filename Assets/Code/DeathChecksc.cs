using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathChecksc : MonoBehaviour
{
    public AudioSource Death;
    private void OnCollisionEnter2D(Collision2D collision) //tuhoaa vihollis objectin kun sen p‰‰lle hypp‰‰
    {
        if(collision.gameObject.name == "Player")
        {
            Death.Play();
            Destroy(transform.parent.gameObject);
        }
    }
}
