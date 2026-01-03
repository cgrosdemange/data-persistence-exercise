using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[DefaultExecutionOrder(1000)]

public class UIMenuManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TMP_InputField playerNameInput;
    [SerializeField] private TMP_Text bestScoreText;

    private void Start()
    {
        var (bestPlayerName, bestScore) = GlobalManager.Instance.GetHighScore();
        if (bestScore > 0)
        {
            bestScoreText.text = $"Best Score : {bestPlayerName} : {bestScore}";
        }
        else
        {
            bestScoreText.text = "Best Score : Play to set one !";
        }
    }

    public void StartGame()
    {
        GlobalManager.Instance.SetPlayerName(playerNameInput.text);
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
