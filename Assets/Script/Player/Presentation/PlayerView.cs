using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public enum PlayerMode
    {
        TopDown
        , Platform
        //,Flying
        //,Swimming
    }
    private Player player;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private MovementSystem movementSystem;
    private FacingSystem facingSystem;
    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;
    private IMovementStrategy topDownMove;
    private IMovementStrategy platformMove;

    private IFacingStrategy topDownFacing;
    private IFacingStrategy platformFacing;

    private PlayerMode currentMode = PlayerMode.TopDown;
    //private bool isTopDown = true;

    void Awake()
    {
        player = new Player();
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
        rb.freezeRotation = true;
        player.Position = transform.position;
        topDownMove = new TopDownMovement();
        platformMove = new PlatformMovement();

        topDownFacing = new TopDownFacing();
        platformFacing = new PlatformFacing();

        movementSystem = new MovementSystem(topDownMove);
        facingSystem = new FacingSystem(topDownFacing);

        SwitchMode(currentMode);

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            CycleMode();
        }

        Vector2 input = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );

        bool jumpPressed = Input.GetKeyDown(KeyCode.Space);
        bool jumpHeld = Input.GetKey(KeyCode.Space);

        UpdateGroundState();
        movementSystem.Update(player, rb, input, jumpHeld, jumpPressed, Time.deltaTime);

        facingSystem.UpdateFacing(player, input, Time.deltaTime);


        ApplyVisualFacing();
    }

    void CycleMode()
    {
        int next = ((int)currentMode + 1) %
                System.Enum.GetValues(typeof(PlayerMode)).Length;

        SwitchMode((PlayerMode)next);
    }
    void UpdateGroundState()
    {
        switch (currentMode)
        {
            case PlayerMode.Platform:
                player.IsGrounded = Physics2D.OverlapCircle(
                    groundCheck.position,
                    groundRadius,
                    groundLayer
                );
                break;

            case PlayerMode.TopDown:
                player.IsGrounded = true;
                break;
        }
    }
    void SwitchMode(PlayerMode mode)
    {
        currentMode = mode;
        switch (currentMode)
        {
            case PlayerMode.TopDown:
                movementSystem.SetStrategy(topDownMove);
                facingSystem.SetStrategy(topDownFacing);
                EnterTopDownMode();
                break;

            case PlayerMode.Platform:
                movementSystem.SetStrategy(platformMove);
                facingSystem.SetStrategy(platformFacing);
                EnterPlatformMode();
                break;
        }
    }
    void ApplyVisualFacing()
    {
        switch (currentMode)
        {
            case PlayerMode.TopDown:
                transform.rotation =
                    Quaternion.AngleAxis(player.FacingAngle, Vector3.forward);
                break;

            case PlayerMode.Platform:
                transform.rotation = Quaternion.identity;
                spriteRenderer.flipX = !player.IsFacingRight;
                break;
        }
    }

    void EnterTopDownMode()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
    }

    void EnterPlatformMode()
    {
        player.FacingAngle = 0f;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 4f;
        rb.velocity = Vector2.zero;
    }
    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
    }
}