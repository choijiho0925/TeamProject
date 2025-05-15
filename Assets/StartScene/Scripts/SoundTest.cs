using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundTest : MonoBehaviour
{
    private Slider master_Slider = null;
    private AudioSource _masterSound = null;


    void Start()
    {
        _masterSound = GetComponentInChildren<AudioSource>();
        master_Slider = GameObject.Find("Sound").GetComponent<Slider>();

        Init();
    }

    void Update()
    {
        SetVolum();
    }

    void Init()
    {
        master_Slider.maxValue = 1;
        master_Slider.minValue = 0.0001f;
        master_Slider.value = _masterSound.volume;
    }

    void SetVolum()
    {
        _masterSound.volume = master_Slider.value;
    }
}
