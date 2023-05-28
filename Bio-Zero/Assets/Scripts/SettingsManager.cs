using System.Collections.Generic;
using TMPro;
using UnityEngine;
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
    private int resIndex;
    private Toggle highRadioRes;
    private Toggle mediumRadioRes;
    private Toggle lowRadioRes;

    [Header("FullScreen Menu Element")] 
    public GameObject buttonOnFS;
    public GameObject buttonOffFS;

    [Header("ScreenSize Menu Element")] 
    private int indexDropDown;
    public TMP_Dropdown dropDownButton;
    public Resolution[] resolutionList;
    
    // Start is called before the first frame update
    void Start()
    {
        List<string> optionResolutions = new List<string>();
        
        resolutionList = Screen.resolutions;
        dropDownButton.ClearOptions();

        for (int i = 0; i < resolutionList.Length; i++)
        {
            string resolution = resolutionList[i].width + " x " + resolutionList[i].height;
            optionResolutions.Add(resolution);

            if (resolutionList[i].width == Screen.currentResolution.width &&
                resolutionList[i].height == Screen.currentResolution.height)
            {
                indexDropDown = i;
            }
        }
        
        dropDownButton.AddOptions(optionResolutions);
        dropDownButton.value = indexDropDown;
        dropDownButton.RefreshShownValue();
        
        sliderSounds.value = 100.0f;
        
        buttonOnFS.SetActive(true);
        buttonOffFS.SetActive(false);
        flagFS = true;
        Screen.fullScreen = true;

        resIndex = 1;
    }

    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(resIndex);
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
        resIndex = 1;
        QualitySettings.SetQualityLevel(resIndex);
    }
    
    public void MediumRadioMethod()
    {
        resIndex = 2;
        QualitySettings.SetQualityLevel(resIndex);
    }
    
    public void LowRadioMethod()
    {
        resIndex = 3;
        QualitySettings.SetQualityLevel(resIndex);
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

    public void SetScreenSize(int indexDropDown)
    {
        Resolution selectedRes = resolutionList[indexDropDown];
        Screen.SetResolution(selectedRes.width, selectedRes.height, Screen.fullScreen);
    }
}
