using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Pausemenu;
    public GameObject SettingsMenu;
    public SaveData SaveData;

    public void Save()
    {
        SaveData.save = true;
    }
    public void Load ()
    {
		SceneManager.LoadScene("SceneManager");
    }
	public void Settings ()
	{
		SettingsMenu.SetActive(!SettingsMenu.activeSelf);
	}
    public void Quit ()
    {
        SceneManager.LoadScene("Menu");
    }
    public void CloseMenu ()
    {
        Pausemenu.SetActive(false);
		Time.timeScale = 1.0f;
		Cursor.lockState = CursorLockMode.None;
	}
	private void Update ()
	{
        if (Pausemenu.activeSelf)
        {
            Time.timeScale = 0.0f;
            Cursor.lockState= CursorLockMode.None;
            
        }
        else
        {
            Time.timeScale = 1.0f;
            Cursor.lockState= CursorLockMode.Locked;
            SettingsMenu.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) { Pausemenu.SetActive(!Pausemenu.activeSelf); }
	}
}
