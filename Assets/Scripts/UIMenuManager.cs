using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]

public class UIMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.ExitPlaymode();
        #else
                Application.Quit();
        #endif
    }
}
