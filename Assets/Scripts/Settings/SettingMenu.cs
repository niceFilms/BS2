using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public TMPro.TMP_Dropdown resolutionDropdown;

	public TMPro.TMP_Dropdown qualityDropdown;

    public Slider Volume;

    public TextMeshProUGUI VolumeText;

    public Slider FOV;

    public TextMeshProUGUI FOVText;

    public Toggle Fullscreen;

    int i = 0;

	Resolution[] resolutions;

	private float val;

	private void Update ()
	{
        if (i != 6) { i++; }
	}
	private void Awake ()
	{
        float idk = PlayerPrefs.GetFloat("FOV");

        if (idk == 0) { PlayerPrefs.SetFloat("FOV", 80); }

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        qualityDropdown.value = QualitySettings.GetQualityLevel();

        float prefs = PlayerPrefs.GetFloat("Volume");
        Volume.value = prefs;
        audioMixer.SetFloat("MasterVol", prefs);
        prefs += 80;
        prefs *= 1.25f;
		VolumeText.text = "Volume: " + prefs.ToString("0");
		prefs = PlayerPrefs.GetFloat("FOV");
		FOV.value = prefs;
        FOVText.text = "FOV: "+ prefs.ToString("0");
        Fullscreen.isOn = Screen.fullScreen;
	}

	public void SetVolume (float volume)
    {
        float prefs = volume;
        prefs += 80;
		prefs *= 1.25f;
		VolumeText.text = "Volume: " + prefs.ToString("0");
		audioMixer.SetFloat("MasterVol", volume);
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

	public void SetFOV (float FOV)
	{
		FOVText.text = "FOV: " + FOV.ToString("0");
		PlayerPrefs.SetFloat("FOV", FOV);
		PlayerPrefs.Save();
	}

	public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen (bool isFullscreen)
    {
        if (i >= 5)
        {
            Screen.fullScreen = isFullscreen;
        }
    }

    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
