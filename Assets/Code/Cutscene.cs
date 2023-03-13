using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cutscene : MonoBehaviour
{

    private int i = 0;
    [SerializeField] private GameObject text;
    [SerializeField] private GameObject black1;
    [SerializeField] private GameObject black2;
    [SerializeField] private GameObject black3;
    [SerializeField] private GameObject black4;
    [SerializeField] private GameObject rumble;


    //Ekan cutscenen navigointi
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            if(i == 0)
            {
                text.SetActive(false);
                black1.SetActive(false);
            }
            else if(i == 1)
            {
                black2.SetActive(false);
            }
            else if(i == 2)
            {
                black3.SetActive(false);
            }
            else if(i == 3)
            {
                rumble.SetActive(false);
                black4.SetActive(false);
            }
            else
            {
                SceneManager.LoadScene("Stage_1");
            }
            i++;
        }
    }
}
