using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneFromINV : MonoBehaviour
{
    public SaveData SaveData;
    public string defaultSceneName;
    void Awake()
    {
        if (SaveData.inventory.Level == "") { SceneManager.LoadScene(defaultSceneName); } else { SceneManager.LoadScene(SaveData.inventory.Level); }
    }
}
