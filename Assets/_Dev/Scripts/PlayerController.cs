using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int maxDamage = 300;
    public int currentDamage = 0;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float knockbackForce = 2f;
    public float knockbackResistance = 0f;

    [Header("Ground check")]
    [SerializeField] private LayerMask groundCheckLayer;
    [SerializeField] private Transform groundCheckOrigin;
    [SerializeField] private float groundCheckRange = 0.2f;

    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerUIReferencing uiReference;

    private bool groundcheck = false;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(rb == null){ rb = GetComponent<Rigidbody>(); }

        if(playerInput == null){ playerInput = GetComponent<PlayerInput>(); }

        gameManager = GameManager.Instance;
        if(gameManager == null)
        {
            gameManager = new GameManager();
        }

        if(uiReference == null)
        {
            PlayerUIReferencing[] playerUIs = GameObject.Find("PlayerUI's").GetComponentsInChildren<PlayerUIReferencing>();

            uiReference = playerUIs[playerInput.playerIndex];
        }

        uiReference.playerTitle.SetText("player: " + playerInput.playerIndex.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        uiReference.damageCounter.SetText(currentDamage.ToString() + "%");
        if (Physics.Raycast(transform.position, Vector3.down, groundCheckRange, groundCheckLayer))
        {
            groundcheck = true;
        }
        else
        {
            groundcheck = false;
        }
    }

    private void FixedUpdate()
    {
    }

    public void Move(InputAction.CallbackContext ctx)
    {
          
        Vector2 moveDirection = ctx.action.ReadValue<Vector2>().normalized;

        rb.angularVelocity = new Vector3(moveDirection.y * moveSpeed, rb.angularVelocity.y, -moveDirection.x * moveSpeed);
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (!groundcheck) { return; }

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void Dash(InputAction.CallbackContext ctx)
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            print("collision with: " + collision.collider.name);
            uiReference.shakeFX.shake();

            Vector3 myVelocity = rb.linearVelocity;
            Vector3 otherVelocity = collision.rigidbody.linearVelocity;

            if (myVelocity.magnitude > otherVelocity.magnitude)
            {
                collision.gameObject.GetComponent<PlayerController>().currentDamage += Mathf.RoundToInt((myVelocity.magnitude) * gameManager.damageMultiplier);

                collision.rigidbody.AddForceAtPosition(myVelocity * knockbackForce, transform.position, ForceMode.Impulse);
                Debug.Log("my velocity is: "+ myVelocity + " I am: " + name);
            }
        }
    }
}
