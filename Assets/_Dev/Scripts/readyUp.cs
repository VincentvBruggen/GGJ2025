using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class readyUp : MonoBehaviour
{
    private bool player1;
    private bool player2;
    private bool player3;
    private bool player4;

    [SerializeField] private GameObject[] readyChecks;

    public GameObject[] playerIcons;
    public UnityEvent ifPlayersReady;

    private void Start()
    {
        foreach (GameObject check in readyChecks)
        {
            check.SetActive(false);
        }
        foreach(GameObject icon in playerIcons)
        {
            icon.SetActive(false);
        }
    }
    public void toggleready(PlayerInput playerInput)
    {
        int nummber = 0;

        nummber = playerInput.playerIndex;
        Debug.Log(nummber);
        switch (nummber+1)
        {
            case 1:
                player1 = !player1;
                break;
            case 2:
                player2 = !player2;
                break;
            case 3:
                player3 = !player3;
                break;
            case 4:
                player4 = !player4;
                break;
        }
        readyChecks[nummber].SetActive(true);
        if (player1 && player2 && player3 && player4)
        {
            Debug.Log("All players are ready");
            ifPlayersReady.Invoke();
        }
    }
}
