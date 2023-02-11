using UnityEngine;
using UnityEngine.SceneManagement;
using CI.QuickSave;

public class newGame : MonoBehaviour
{
    public SaveData SaveData;
    public void Event()
    {
        QuickSaveWriter.Create("Player")
            .Commit();
		SceneManager.LoadSceneAsync("SceneManager");
	}
}
