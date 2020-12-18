﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public AudioMixer mixer;
    
    public void SetLevel (float sliderVlaue)
    {
    	mixer.SetFloat("MusicVol", Mathf.Log10(sliderVlaue) * 20);
    }
}