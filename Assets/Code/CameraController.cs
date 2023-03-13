using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public GameObject player;        //Pelaajahahmon objecti


    private Vector3 offset;          //Kameran ja pelaajan ero

    void Start()
    {
        //Tarkastaa kameran ja pelaajan eron
        offset = transform.position - player.transform.position;
    }

    //Lateupdate p‰ivitt‰‰ updatin j‰lkeen joka frami
    void LateUpdate()
    {
        //Siirr‰ kamera pelaajan luokse
        transform.position = player.transform.position + offset;
    }
}