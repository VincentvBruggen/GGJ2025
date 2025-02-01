using UnityEngine;

public class DeathManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerController player;
    private GameManager manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathZone"))
        {
            player.stocks += 1;
            player.uiReference.stockChanger.removeStock();

            transform.position = GameManager.Instance.transform.position;
            if(player.stocks <= 0)
            {
                GameManager.Instance.players.Remove(gameObject);
            }
        }
    }
}
