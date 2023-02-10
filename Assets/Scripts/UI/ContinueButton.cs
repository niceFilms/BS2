using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : MonoBehaviour
{
    public void Event()
    {
        SceneManager.LoadSceneAsync("SceneManager");
    }
}
