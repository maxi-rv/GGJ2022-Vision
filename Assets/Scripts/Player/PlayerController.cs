using UnityEngine;
using UnityEngine.InputSystem;
using Koffie.SimpleTasks;

public class PlayerController : MonoBehaviour
{
    //Components
    private Transform transform;
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private PlayerInputActions playerInputActions;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    //Required variables
    [SerializeField] [Range(0.0f, 10.0f)] private float movementSpeed;
    public float collectables;
    [SerializeField] private Material matWhite;
    private Material matDefault;


    private void Awake()
    {
        //Get gameObject components
        transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        //Setup Inputs
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        //Getting the dafault material for later use.
        matDefault = spriteRenderer.material;
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        rb.velocity = new Vector2(inputVector.x, inputVector.y) * movementSpeed;

        animator.SetFloat("MoveX", inputVector.x);
        animator.SetFloat("MoveY", inputVector.y);

        if (Mathf.Abs(inputVector.x) < 0.1f && Mathf.Abs(inputVector.y) < 0.1f)
        {
            animator.SetBool("IsIdle", true);
        } else
        {
            animator.SetBool("IsIdle", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            collectables++;
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            GetHurt();
        }
    }

    private void GetHurt()
    {
        // Make a knockback or some hurting effect!!!
        FlashWhite();
        playerInputActions.Player.Disable();
        STasks.Do(() => playerInputActions.Player.Enable(), after: 0.6f);

        Invoke("FlashBack", 0.1f);
        Invoke("FlashWhite", 0.2f);
        Invoke("FlashBack", 0.3f);
        Invoke("FlashWhite", 0.4f);
        Invoke("FlashBack", 0.5f);
    }

    private void FlashWhite()
    {
        spriteRenderer.material = matWhite;
    }

    private void FlashBack()
    {
        spriteRenderer.material = matDefault;
    }
}
