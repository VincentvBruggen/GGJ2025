using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Attributes")]
    public float moveSpeed = 5f;

    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerInput playerInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(rb == null){ rb = GetComponent<Rigidbody>(); }

         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Move(InputAction.CallbackContext ctx)
    {
        Vector2 moveDirection = ctx.action.ReadValue<Vector2>().normalized;

        rb.angularVelocity = new Vector3(moveDirection.y * moveSpeed, rb.angularVelocity.y, -moveDirection.x * moveSpeed);
    }

}
