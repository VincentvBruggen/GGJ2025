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
    public UnityEvent ifPlayersReady;
    public void toggleready(PlayerInput playerInput)
    {
        int nummber = 0;

        nummber = playerInput.playerIndex;
        Debug.Log(nummber);
        switch (nummber)
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
        if (player1 && player2 && player3 && player4)
        {
            Debug.Log("All players are ready");
            ifPlayersReady.Invoke();
        }
    }
}
