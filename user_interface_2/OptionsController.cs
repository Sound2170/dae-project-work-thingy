using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Collections.Generic;
using TMPro;

public class OptionsController : MonoBehaviour
{
    [Header("Audio")]
    public AudioMixer mixer;
    public Slider masterSlider, musicSlider, sfxSlider;

    [Header("Display")]
    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;

    void Start()
    {
        // Populate resolutions dropdown
        resolutions = Screen.resolutions
            .Where(r => r.refreshRate == Screen.currentResolution.refreshRate)
            .ToArray();
        var options = new List<string>();
        int currentIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            var r = resolutions[i];
            options.Add($"{r.width} x {r.height}");
            if (r.width == Screen.currentResolution.width && r.height == Screen.currentResolution.height)
                currentIndex = i;
        }

        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentIndex;
        resolutionDropdown.RefreshShownValue();

        // Load saved audio prefs
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        musicSlider.value  = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxSlider.value    = PlayerPrefs.GetFloat("SFXVolume", 1f);
    }

    // Called by masterSlider OnValueChanged
    public void SetMasterVolume(float v)
    {
        mixer.SetFloat("MasterVolume", Mathf.Log10(v) * 20);
        PlayerPrefs.SetFloat("MasterVolume", v);
    }

    public void SetMusicVolume(float v)
    {
        mixer.SetFloat("MusicVolume", Mathf.Log10(v) * 20);
        PlayerPrefs.SetFloat("MusicVolume", v);
    }

    public void SetSfxVolume(float v)
    {
        mixer.SetFloat("SFXVolume", Mathf.Log10(v) * 20);
        PlayerPrefs.SetFloat("SFXVolume", v);
    }

    // Called by resolutionDropdown OnValueChanged
    public void SetResolution(int idx)
    {
        var r = resolutions[idx];
        Screen.SetResolution(r.width, r.height, Screen.fullScreen);
        PlayerPrefs.SetInt("ResolutionIndex", idx);
    }

    // Hook this to Back button OnClick
    public void OnBack()
    {
        gameObject.SetActive(false);
    }
}
