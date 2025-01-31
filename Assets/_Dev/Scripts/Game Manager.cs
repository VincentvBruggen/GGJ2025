using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float matchLength = 120; // In seconds
    public int stockAmount = 3;

    public float itemDropRate = 5; // Amount of seconds that has to pass to drop an item

    public float knockBackMultiplier = 1.0f;
    public float damageMultiplier = 1.0f;

    private static GameManager instance;

    public GameSettingsSO m_defaultGameSettings;

    public Scene currentScene;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<GameManager>();

                if (instance == null)
                {
                    GameObject gameManagerObj = new GameObject("GameManager");
                    instance = gameManagerObj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        ResetToDefaultMatchSettings();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentScene = scene;
    }

    public void ResetToDefaultMatchSettings()
    {
        matchLength = m_defaultGameSettings.matchLength;
        stockAmount = m_defaultGameSettings.stockAmount;
        itemDropRate = m_defaultGameSettings.itemDropRate;
        knockBackMultiplier = m_defaultGameSettings.knockBackMultiplier;
        damageMultiplier = m_defaultGameSettings.damageMultiplier;
    }

    public void ChangeScene(string _scene)
    {
        SceneManager.LoadScene(_scene);
    }
}