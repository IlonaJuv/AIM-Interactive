using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;

    public void SetLevel(float sliderValue) //Tekee ‰‰ni sliderista tarkemman https://www.youtube.com/watch?v=xNHSGMKtlv4 esimerkin mukaan.
    {
        mixer.SetFloat("Volume", Mathf.Log10 (sliderValue) * 20);
    }
}
