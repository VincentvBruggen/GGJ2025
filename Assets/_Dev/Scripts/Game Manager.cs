using System.Collections.Generic;
using System.Collections;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public float matchLength = 120; // In seconds
    public int stockAmount = 3;

    public float itemDropRate = 5; // Amount of seconds that has to pass to drop an item

    public float knockBackMultiplier = 1.0f;
    public float damageMultiplier = 1.0f;

    private static GameManager instance;

    public GameSettingsSO m_defaultGameSettings;

    public string currentScene;
    public List<GameObject> players = new List<GameObject>();

    public bool isPlaying = false;
    [SerializeField] private TextMeshProUGUI startGameCount;
    [SerializeField] private GameObject startCanvas;
    [SerializeField] private GameCanvasManager gameCanvas;
   
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

    private void Start()
    {
        startGameCount.gameObject.SetActive(false);
        gameCanvas.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(players.Count <= 1 && isPlaying)
        {

        }
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
        currentScene = scene.ToString();
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

    public void StartGame()
    {
        StartCoroutine(StartSequence());
    }

    private IEnumerator StartSequence()
    {
        startGameCount.gameObject.SetActive(true);
        float duration = 3f;
        float counter = 0;
        while (counter < duration) 
        {
            startGameCount.SetText(counter.ToString());
            yield return new WaitForSeconds(1);
        }

        startGameCount.gameObject.SetActive(false);
        isPlaying = true;
        gameCanvas.gameObject.SetActive(true);
        startCanvas.SetActive(false);
    }

    private IEnumerator EndgameSequence()
    {
        gameCanvas.gameEndText.SetText("Winner is: Player  " + players[0].GetComponent<PlayerInput>().playerIndex.ToString());
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(0);
    }
}