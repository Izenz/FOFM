using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] TMPro.TMP_Dropdown resolutionDropdown;

    [SerializeField] Slider generalSlider;
    [SerializeField] Slider ambientSlider;
    [SerializeField] Slider effectsSlider;
    [SerializeField] Slider backgroundSlider;

    [SerializeField] Toggle toggleFullscreen;

    private Resolution[] availableResolutions;

    const float DEFAULT_GLOBAL_VOLUME = 0f;
    const float DEFAULT_SUB_VOLUME = -40f;

    void Awake()
    {
        PlayerPrefs.GetFloat("masterVolume", DEFAULT_GLOBAL_VOLUME);
        generalSlider.value = PlayerPrefs.GetFloat("masterVolume", DEFAULT_GLOBAL_VOLUME);
        PlayerPrefs.GetFloat("effectsVolume", DEFAULT_SUB_VOLUME);
        ambientSlider.value = PlayerPrefs.GetFloat("ambientVolume", DEFAULT_SUB_VOLUME);
        PlayerPrefs.GetFloat("ambientVolume", DEFAULT_SUB_VOLUME);
        effectsSlider.value = PlayerPrefs.GetFloat("effectsVolume", DEFAULT_SUB_VOLUME);
        PlayerPrefs.GetFloat("backgroundVolume", DEFAULT_SUB_VOLUME);
        backgroundSlider.value = PlayerPrefs.GetFloat("backgroundVolume", DEFAULT_SUB_VOLUME);

        LoadResolutionDropdown();

        SetFullscreen(Convert.ToBoolean(PlayerPrefs.GetInt("toggleFullscreen", 1)));
        toggleFullscreen.isOn = Convert.ToBoolean(PlayerPrefs.GetInt("toggleFullscreen", 1));
    }

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

    public void SetMasterVolume( float volume)
    {
        audioMixer.SetFloat("masterVolume", volume);
        PlayerPrefs.SetFloat("masterVolume", volume);
        PlayerPrefs.Save();
    }

    public void SetEffectsVolume(float volume)
    {
        audioMixer.SetFloat("effectsVolume", volume);
        PlayerPrefs.SetFloat("effectsVolume", volume);
        PlayerPrefs.Save();
    }

    public void SetAmbientVolume(float volume)
    {
        audioMixer.SetFloat("ambientVolume", volume);
        PlayerPrefs.SetFloat("ambientVolume", volume);
        PlayerPrefs.Save();
    }
    public void SetBackgroundVolume(float volume)
    {
        audioMixer.SetFloat("backgroundVolume", volume);
        PlayerPrefs.SetFloat("backgroundVolume", volume);
        PlayerPrefs.Save();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution res = availableResolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    public void SetFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
        PlayerPrefs.SetInt("toggleFullscreen", isFullScreen ? 1:0);
        PlayerPrefs.Save();
    }

}

