using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] TMPro.TMP_Dropdown resolutionDropdown;

    private Resolution[] availableResolutions;

    //  PRIVATE METHODS

    private void LoadResolutionDropdown()
    {
        availableResolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        int currentResolutionIndex = 0;

        List<string> resolutionOptions = new List<string>();
        for (int i = 0; i < availableResolutions.Length; ++i)
        {
            string optionLabel = availableResolutions[i].width + " x " + availableResolutions[i].height;
            resolutionOptions.Add(optionLabel);

            if (availableResolutions[i].width == Screen.currentResolution.width &&
                availableResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    // PUBLIC METHODS

    private void Start()
    {
        LoadResolutionDropdown();
    }

    public void SetMasterVolume( float volume)
    {
        audioMixer.SetFloat("masterVolume", volume);
    }

    public void SetEffectsVolume(float volume)
    {
        audioMixer.SetFloat("effectsVolume", volume);
    }

    public void SetAmbientVolume(float volume)
    {
        audioMixer.SetFloat("ambientVolume", volume);
    }
    public void SetBackgroundVolume(float volume)
    {
        audioMixer.SetFloat("backgroundVolume", volume);
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution res = availableResolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

}

