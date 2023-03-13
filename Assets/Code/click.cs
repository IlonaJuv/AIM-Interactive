using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class click : MonoBehaviour
{

    private Button startButton;

    void Start()    //kun painaa play nappia alkaa eka cutscene
    {
        startButton = GameObject.Find("Play").GetComponent<Button>();
        startButton.onClick.AddListener(() => SceneManager.LoadScene("cutscene"));
    }
}
