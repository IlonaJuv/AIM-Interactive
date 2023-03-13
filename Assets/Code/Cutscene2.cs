using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene2 : MonoBehaviour
{

    private int i = 0;
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject black1;
    [SerializeField] private GameObject black2;
    [SerializeField] private GameObject black3;

    //Toisen cutscenen navigointi
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (i == 0)
            {
                text.SetActive(false);
                black1.SetActive(false);
            }
            else if (i == 1)
            {
                black2.SetActive(false);
            }
            else if (i == 2)
            {
                black3.SetActive(false);
            }
            else
            {
                GameObject.FindGameObjectWithTag("Music").GetComponent<MusicPlayer>().StopMusic();
                SceneManager.LoadScene("Menu");
            }
            i++;
        }
    }
}
