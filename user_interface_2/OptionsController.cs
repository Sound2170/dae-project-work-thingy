using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Collections.Generic;

public class OptionsController : MonoBehaviour
{
    [Header("Audio")]
    public AudioMixer mixer;
    public Slider masterSlider, musicSlider, sfxSlinder;

    [Header("Display")]
    public Dropdown resolutionDropdown; 
    Resolution[] resolutions;

    void Start()
    {

        //populate resolutions dropdown
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
        
    }
}
