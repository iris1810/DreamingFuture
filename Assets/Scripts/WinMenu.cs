using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuickGame()
    {
        Application.Quit();
    }
}
