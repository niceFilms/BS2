using UnityEngine;
using UnityEngine.SceneManagement;

public class newGame : MonoBehaviour
{
    public SaveData SaveData;
    public void Event()
    {
        SaveData = null;
		SceneManager.LoadSceneAsync("SceneManager");
	}
}
