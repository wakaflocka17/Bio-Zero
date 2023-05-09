using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    private bool flagFS;
    
    [Header("Sounds Menu Element")] 
    public GameObject buttonPlusSounds;
    public GameObject buttonMinusSounds;
    public Slider sliderSounds;
    //public AudioMixer audio;

    [Header("Resolution Menu Element")] 
    /* I've use this only for setup the real logic button */
    private Toggle highRadioRes;
    private Toggle mediumRadioRes;
    private Toggle lowRadioRes;

    [Header("FullScreen Menu Element")] 
    public GameObject buttonOnFS;
    public GameObject buttonOffFS;

    [Header("ScreenSize Menu Element")] 
    public GameObject dropDownButton;
    
    // Start is called before the first frame update
    void Start()
    {
        sliderSounds.value = 100.0f;
        
        buttonOnFS.SetActive(true);
        buttonOffFS.SetActive(false);
        flagFS = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetQuality(int indexQuality)
    {
        QualitySettings.SetQualityLevel(indexQuality);
    }

    public void UpSounds()
    {
        if (sliderSounds.value < 100)
        {
            sliderSounds.value += 1;
        }
    }

    public void DownSounds()
    {
        if (sliderSounds.value > 0)
        {
            sliderSounds.value -= 1;
        }
    }

    public void HighRadioMethod()
    {
        highRadioRes.isOn = true;
        mediumRadioRes.isOn = false;
        lowRadioRes.isOn = false;
    }
    
    public void MediumRadioMethod()
    {
        highRadioRes.isOn = false;
        mediumRadioRes.isOn = true;
        lowRadioRes.isOn = false;
    }
    
    public void LowRadioMethod()
    {
        highRadioRes.isOn = false;
        mediumRadioRes.isOn = false;
        lowRadioRes.isOn = true;
    }

    public void ModeFullScreen()
    {
        if (flagFS)
        {
            Screen.fullScreen = true;
            buttonOnFS.SetActive(false);
            buttonOffFS.SetActive(true);
            flagFS = false;
        }

        else
        {
            Screen.fullScreen = false;
            buttonOffFS.SetActive(false);
            buttonOnFS.SetActive(true);
            flagFS = true;
        }
    }
}
