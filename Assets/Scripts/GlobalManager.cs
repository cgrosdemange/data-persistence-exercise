using UnityEngine;
using System.IO;

public class GlobalManager : MonoBehaviour
{
    public static GlobalManager Instance { get; private set; }

    public string PlayerName { get; private set; }

    public string BestPlayerName { get; private set; }
    public int BestScore { get; private set; } = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadHighScore();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerName(string name)
    {
        PlayerName = name;
    }

    public bool TrySetHighScore(string playerName, int score)
    {
        if (score > BestScore)
        {
            BestScore = score;
            BestPlayerName = playerName;
            SaveHighScore();
            return true;
        }
        return false;
    }

    public (string, int) GetHighScore()
    {
        return (BestPlayerName, BestScore);
    }

    // Save / Load
    [System.Serializable]
    class SaveData
    {
        public string bestPlayerName;
        public int bestScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.bestPlayerName = BestPlayerName;
        data.bestScore = BestScore;

        string json = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestPlayerName = data.bestPlayerName;
            BestScore = data.bestScore;
        }
    }
}