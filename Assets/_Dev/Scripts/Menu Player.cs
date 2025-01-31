using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuPlayer : MonoBehaviour
{
    private PlayerInput m_playerInput;
    private int m_playerNum;

    private GameManager m_gameManager;
    private PlayerController m_playerController;

    private void Awake()
    {
        m_playerInput = GetComponent<PlayerInput>();
        m_playerController = GetComponent<PlayerController>();

        m_gameManager = FindFirstObjectByType<GameManager>();

        m_playerNum = m_playerInput.playerIndex;

        Debug.Log(m_playerInput.GetDevice<InputDevice>());

        Debug.Log(m_playerNum);

        EnableOrDisablePlayerScript();
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
        EnableOrDisablePlayerScript();
    }

    private void EnableOrDisablePlayerScript()
    {
        if (m_gameManager.currentScene == "Noah") // Should be the lobby scene but just make this any test scene you want
        {
            m_playerController.enabled = false;
        }
        else
        {
            m_playerController.enabled = true;
        }
    }
}
