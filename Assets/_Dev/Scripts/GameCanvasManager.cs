using TMPro;
using UnityEngine;

public class GameCanvasManager : MonoBehaviour
{
    [SerializeField] GameObject[] playerIcons;
    public TextMeshProUGUI gameEndText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameEndText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0;i < GameManager.Instance.players.Count;i++)
        {
            playerIcons[i].SetActive(true);
        }
    }
}
