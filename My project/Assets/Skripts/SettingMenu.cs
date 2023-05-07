using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public SceneFader sceneFader;
    Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    private AudioSource ButtonClick;

    private void GetButtonClickSound()
    {
        GameObject[] soundObj = GameObject.FindGameObjectsWithTag("ButtonClickSound");
        ButtonClick = soundObj[0].GetComponent<AudioSource>();
    }

    private void Start()
    {
        GetButtonClickSound();

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution (int resolutionIndex)
    {
        ButtonClick.Play();
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetFullscreen (bool isFullscreen)
    {
        ButtonClick.Play();
        Screen.fullScreen = isFullscreen;
    }

    public void Close()
    {
        sceneFader.FadeTo("MainMenu");
        ButtonClick.Play();
    }
}
