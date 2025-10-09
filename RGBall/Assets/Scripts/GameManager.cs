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
    int _levelsCompleted;

    //========================================================================
    // Encapsulation
    //========================================================================

    public int LevelsCompleted
    {
        get { return _levelsCompleted; }
        set {
            if (value >= _levelsCompleted)
            {
                _levelsCompleted = Mathf.Clamp(value, 0, 2); // Change to max 10 in the full version 
            }
        }
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
    
    // Update is called once per frame
    void Update()
    {
        HandleInputs();
    }

    //========================================================================
    // Custom methods
    //========================================================================
    void HandleInputs()
    {
        if (Input.GetKeyDown(KeyCode.R) && SceneManager.GetActiveScene().name != "TitleScreen")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void LoadLevel(string levelName, int completedLevelNumber)
    {
        LevelsCompleted = completedLevelNumber;
        SceneManager.LoadScene(levelName);
    }

    //========================================================================
    // Managing player save data
    //========================================================================
    [System.Serializable]
    class SaveData
    {
        public int levelsCompleted;
    }

    public void SavePlayerData()
    {
        SaveData data = new();
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

            LevelsCompleted = data.levelsCompleted;
        }
        else
        {
            SetDefaultData();
        }
    }

    void SetDefaultData()
    {
        LevelsCompleted = 0;
    }
}
