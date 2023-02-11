using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CI.QuickSave;
using UnityEngine.Windows;

public class LoadSceneFromINV : MonoBehaviour
{
	Scene sceney;
	public string defaultSceneName;
    void Awake()
    {

        QuickSaveReader.Create("Player")
            .Read<Scene>("Scene", (r) => { sceney = r; });

		if (sceney.name == null) { SceneManager.LoadScene(defaultSceneName); } else { SceneManager.LoadScene(sceney.name); }
    }
}
