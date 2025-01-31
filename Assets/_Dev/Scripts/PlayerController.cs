using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Attributes")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Ground check")]
    [SerializeField] private LayerMask groundCheckLayer;
    [SerializeField] private Transform groundCheckOrigin;
    [SerializeField] private float groundCheckRange = 0.2f;

    [Header("Refernces")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerInput playerInput;

    private bool groundcheck = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(rb == null){ rb = GetComponent<Rigidbody>(); }

        if(playerInput == null){ playerInput = GetComponent<PlayerInput>(); }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        groundCheckOrigin.position = transform.position + (Vector3.down * 0.5f);
        groundCheckOrigin.eulerAngles = Vector3.zero;

        groundcheck = Physics.SphereCast(transform.position, 0.5f ,Vector3.down, out RaycastHit hit, groundCheckRange, groundCheckLayer);
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawWireSphere(groundCheckOrigin.position, 0.5f);
    }
}
