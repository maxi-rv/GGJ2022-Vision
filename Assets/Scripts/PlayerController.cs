using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;

    private Animator animator;

    [SerializeField] [Range(0.0f, 10.0f)] private float movementSpeed;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        rb.velocity = new Vector2(inputVector.x, inputVector.y) * movementSpeed;

        animator.SetFloat("MoveX", inputVector.x);
        animator.SetFloat("MoveY", inputVector.y);

        if (inputVector.x < Mathf.Abs(0.1f) && inputVector.y < Mathf.Abs(0.1f))
        {
            animator.SetBool("IsIdle", true);
        } else
        {
            animator.SetBool("IsIdle", false);
        }
    }

}
