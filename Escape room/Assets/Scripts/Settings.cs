using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public TMP_Dropdown resolutionDropdown;
    public Toggle toggle;
    public Slider Music;
    public Slider Sound;
    public Slider Volume;
    Resolution[] resolutions;
    private int correntResolutionIndex;
    private float value;
    void Start()
    {
        toggle.isOn = Screen.fullScreen;

        audioMixer.GetFloat("Buttons", out value);
        Sound.value = value;
         audioMixer.GetFloat("Music", out value);
        Music.value = value;
         audioMixer.GetFloat("Volume", out value);
        Volume.value = value;

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        for(int i=0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width &&
               resolutions[i].height == Screen.currentResolution.height)
               {
                correntResolutionIndex = i;
               }
        }
        resolutionDropdown.AddOptions(options);

        resolutionDropdown.value = correntResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume",volume);
    }
    public void SetMusic(float volume)
    {
        audioMixer.SetFloat("Music",volume);
    }
    public void SetSounds(float volume)
    {
        audioMixer.SetFloat("Buttons",volume);
    }
    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void SetResolution(int resolutionIndex)
    { 
        Resolution newResolution = resolutions[resolutionIndex];
        Screen.SetResolution(newResolution.width, newResolution.height, Screen.fullScreen);
    }
}
