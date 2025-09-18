using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Instance
    public static GameManager Instance;

    //========================================================================
    // Player data
    //========================================================================
    public string LastPlayedLevel { get; set; }
    int _levelsCompleted;

    //========================================================================
    // Encapsulation
    //========================================================================

    public int LevelsCompleted
    {
        get { return _levelsCompleted; }
        set { _levelsCompleted = Mathf.Clamp(value, 0, 10); }
    }

    //========================================================================
    // Awake, Start and Update
    //========================================================================
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        if (Instance == null)
        {
            LoadPlayerData();
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    //========================================================================
    // Managing levels
    //========================================================================
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    //========================================================================
    // Managing player save data
    //========================================================================
    [System.Serializable]
    class SaveData
    {
        public string lastPlayedLevel;
        public int levelsCompleted;
    }

    public void SavePlayerData()
    {
        SaveData data = new();
        data.lastPlayedLevel = LastPlayedLevel;
        data.levelsCompleted = LevelsCompleted;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            LastPlayedLevel = data.lastPlayedLevel;
            LevelsCompleted = data.levelsCompleted;
        }
        else
        {
            SetDefaultData();
        }
    }

    void SetDefaultData()
    {
        LastPlayedLevel = "Level1";
        LevelsCompleted = 0;
    }
}
