using System;
using Scripts;
using UnityEngine;
using UnityEngine.InputSystem;
using static Scripts.InputStatesEnum;

    
public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Animator upBoosterAnimator;
    [SerializeField] private Animator downBoosterAnimator;
    [SerializeField] private Animator leftBoosterAnimator;
    [SerializeField] private Animator rightBoosterAnimator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask	platformLayerMask;
    
    private InputActions_AsteroidExplorer inputActions;
    private CharacterStates characterState;
    private InputStates inputStates;
    
    [SerializeField] private ContactFilter2D ContactFilter;
    private bool IsGrounded => rigidbody2d.IsTouching(ContactFilter);
    
    [SerializeField] private float maxAirdriftSpeed;
    [SerializeField] private float airdriftMultiplier;
    [SerializeField] private float airfloatMultiplier;
    [SerializeField] private float airfallSlowdown;
    [SerializeField] private int jumpFloatMaxFrames;
    [SerializeField] private float airdriftSlowdown;
    [SerializeField] private int minimumJumpFrames;
    public float projectileSpeed;
    private int jumpFloatFrameCounter = 0;
    
    [SerializeField] private int boosterStrength;
    [SerializeField] private int dashStrength;
    [SerializeField] private int maxFloatSpeed;
    private static readonly int LeftPressed = Animator.StringToHash("leftPressed");
    private static readonly int RightPressed = Animator.StringToHash("rightPressed");
    private static readonly int UpPressed = Animator.StringToHash("upPressed");
    private static readonly int DownPressed = Animator.StringToHash("downPressed");


    private void OnEnable()
    {
        inputActions.Enable();
    }
    
    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Awake()
    {
        characterState = CharacterStates.Idle;
        inputStates = new InputStates();
        inputActions = new InputActions_AsteroidExplorer();
        inputActions.@default.Left.started += LeftActionStarted;
        inputActions.@default.Right.started += RightActionStarted;
        inputActions.@default.Up.started += UpActionStarted;
        inputActions.@default.Down.started += DownActionStarted;
        inputActions.@default.Jump.started += JumpActionStarted;
        inputActions.@default.Shoot.started += ShootActionStarted;
        
        inputActions.@default.Left.canceled += LeftActionCanceled;
        inputActions.@default.Right.canceled += RightActionCanceled;
        inputActions.@default.Up.canceled += UpActionCanceled;
        inputActions.@default.Down.canceled += DownActionCanceled;
        inputActions.@default.Jump.canceled += JumpActionCanceled;
        inputActions.@default.Shoot.canceled += ShootActionCanceled;
    }


    public void LeftActionStarted(InputAction.CallbackContext context)
    {
        inputStates.left = Pressed;
        leftBoosterAnimator.SetBool(LeftPressed, true);
    }

    public void LeftActionCanceled(InputAction.CallbackContext context)
    {
        inputStates.left = Raised;
        leftBoosterAnimator.SetBool(LeftPressed, false);
    }

    public void RightActionStarted(InputAction.CallbackContext context)
    {
        inputStates.right = Pressed;
        rightBoosterAnimator.SetBool(RightPressed, true);
    }

    public void RightActionCanceled(InputAction.CallbackContext context)
    {
        inputStates.right = Raised;
        rightBoosterAnimator.SetBool(RightPressed, false);
    }
    public void UpActionStarted(InputAction.CallbackContext context)
    {
        inputStates.up = Pressed;
        upBoosterAnimator.SetBool(UpPressed, true);
    }

    public void UpActionCanceled(InputAction.CallbackContext context)
    {
        inputStates.up = Raised;
        upBoosterAnimator.SetBool(UpPressed, false);
    }
    public void DownActionStarted(InputAction.CallbackContext context)
    {
        inputStates.down = Pressed;
        downBoosterAnimator.SetBool(DownPressed, true);
    }

    public void DownActionCanceled(InputAction.CallbackContext context)
    {
        inputStates.down = Raised;
        downBoosterAnimator.SetBool(DownPressed, false);
    }
    
    public void JumpActionStarted(InputAction.CallbackContext context)
    {
        inputStates.jump = Started;
    }

    public void JumpActionCanceled(InputAction.CallbackContext context)
    {
        inputStates.jump = Raised;
    }
    
    public void ShootActionStarted(InputAction.CallbackContext context)
    {
        var projectileInstance = Instantiate(projectile, transform);
        var projectileRigidbody = projectileInstance.GetComponent<Rigidbody2D>();
        var aimDirection = inputActions.@default.Aim.ReadValue<Vector2>();
        if (aimDirection.x < .05 && aimDirection.x > -.05 ||
            aimDirection.y < .05 && aimDirection.y > -.05)
        {
        }

        inputStates.aim = aimDirection;
        projectileRigidbody.AddForce(inputStates.aim * projectileSpeed);
    }
    public void ShootActionCanceled(InputAction.CallbackContext context)
    {

    }
    
    // Start is called before the first frame update
    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        inputStates.aim = inputActions.@default.Aim.ReadValue<Vector2>();
        
        switch (characterState)
        {
            case CharacterStates.Idle:
                SelectActionFromIdle();
                break;
            case CharacterStates.MoveRight:
                SelectActionFromMove();
                break;
            case CharacterStates.MoveLeft:
                SelectActionFromMove();
                break;
            case CharacterStates.MoveUp:
                SelectActionFromMove();
                break;
            case CharacterStates.MoveDown:
                SelectActionFromMove();
                break;
            case CharacterStates.Dash:
                break;
            case CharacterStates.Jump:
                //SetJumpAnimation();
                SelectActionFromJump();
                break;

            default:
                throw new ArgumentOutOfRangeException();
        }

        if (inputStates.jump == Started)
        {
            inputStates.jump = Pressed;
        }
    }


    private void SelectActionFromIdle()
    {
        if (Jump())
        {
            return;
        }
        if (Move())        
        {
        }
    }
    private void SelectActionFromMove()
    {
        if (Jump())
        {
            return;
        }
        if (Move())
        {
            return;
        }
        characterState = CharacterStates.Idle;
    }
    
    private void SelectActionFromJump()
    {
        if (IsGrounded && rigidbody2d.velocity.y <= 0)
        {
            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
            jumpFloatFrameCounter = 0;

            
            if (inputStates.left == Pressed)
                characterState = CharacterStates.MoveLeft;
            else if (inputStates.right == Pressed)
                characterState = CharacterStates.MoveRight;
            else
                characterState = CharacterStates.Idle;
            return;
        }

        AerialDrift();
        JumpFloat();
    }



    private bool Move()
    {
        //TODO: Account for keyboards holding both directions
        var isMoving = false;
        if (inputStates.left == Pressed)
        {
            characterState = CharacterStates.MoveLeft;
            if(rigidbody2d.velocity.x > -maxFloatSpeed)
                rigidbody2d.AddForce(new Vector2(-boosterStrength,0));
        }
        if(inputStates.right == Pressed)
        {
            characterState = CharacterStates.MoveRight;
            if(rigidbody2d.velocity.x < maxFloatSpeed)
                rigidbody2d.AddForce(new Vector2(boosterStrength,0));
            isMoving = true;
        }
        if(inputStates.up == Pressed)
        {
            characterState = CharacterStates.MoveUp;
            if(rigidbody2d.velocity.y < maxFloatSpeed)
                rigidbody2d.AddForce(new Vector2(0,boosterStrength));
            isMoving = true;
        }
        if(inputStates.down == Pressed)
        {
            characterState = CharacterStates.MoveDown;
            if(rigidbody2d.velocity.y > -maxFloatSpeed)
                rigidbody2d.AddForce(new Vector2(0,-boosterStrength));
            isMoving = true;
        }
        
        return isMoving;
    }
    private bool Jump()
    {
        if (inputStates.jump != Started || characterState == CharacterStates.Jump) return false;
        
        if (inputStates.left == Pressed)
        {
            characterState = CharacterStates.MoveLeft;
            spriteRenderer.flipX = true;
            if(rigidbody2d.velocity.x > -maxFloatSpeed)
                rigidbody2d.AddForce(new Vector2(-dashStrength,0));
        }
        if(inputStates.right == Pressed)
        {
            characterState = CharacterStates.MoveRight;
            spriteRenderer.flipX = false;
            if(rigidbody2d.velocity.x < maxFloatSpeed)
                rigidbody2d.AddForce(new Vector2(dashStrength,0));
        }
        if(inputStates.up == Pressed)
        {
            characterState = CharacterStates.MoveUp;
            spriteRenderer.flipY = true;
            if(rigidbody2d.velocity.y < maxFloatSpeed)
                rigidbody2d.AddForce(new Vector2(0,dashStrength));
        }
        if(inputStates.down == Pressed)
        {
            characterState = CharacterStates.MoveDown;
            spriteRenderer.flipY = false;
            if(rigidbody2d.velocity.y > -maxFloatSpeed)
                rigidbody2d.AddForce(new Vector2(0,-dashStrength));
        }

        return true;
    }
    
    private void AerialDrift()
    {
        if (inputStates.left == Pressed && inputStates.right == Raised && rigidbody2d.velocity.x > -1 * maxAirdriftSpeed)
        {
            rigidbody2d.velocity += Vector2.left * airdriftMultiplier;
            spriteRenderer.flipX = true;
        }
        else if (inputStates.right == Pressed && inputStates.left == Raised && rigidbody2d.velocity.x < maxAirdriftSpeed)
        {
            rigidbody2d.velocity += Vector2.right * airdriftMultiplier;
            spriteRenderer.flipX = false;
        }
        else if (inputStates.right == Raised && inputStates.left == Raised)
        {
            
            if (rigidbody2d.velocity.x > 0)
            {
                if (rigidbody2d.velocity.x < airdriftSlowdown)
                {
                    rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
                }
                else
                {
                    var velocity = rigidbody2d.velocity;
                    velocity = new Vector2(velocity.x - airdriftSlowdown, velocity.y);
                    rigidbody2d.velocity = velocity;
                }
            }
            else if(rigidbody2d.velocity.x < 0)
            {
                if (rigidbody2d.velocity.x > -airdriftSlowdown)
                {
                    rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
                }
                else
                {
                    var velocity = rigidbody2d.velocity;
                    velocity = new Vector2(velocity.x + airdriftSlowdown, velocity.y);
                    rigidbody2d.velocity = velocity;
                }
            }
        }
    }

    private void JumpFloat()
    {
        if(jumpFloatFrameCounter < jumpFloatMaxFrames)
        {
            switch (inputStates.jump)
            {
                case Pressed:
                    rigidbody2d.velocity += Vector2.up * airfloatMultiplier;
                    break;
                case Raised:
                    AirfallSlowdown();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            jumpFloatFrameCounter++;
        }
        else
        {
            AirfallSlowdown();
        }
    }

    private void AirfallSlowdown()
    {
        if (jumpFloatFrameCounter < minimumJumpFrames) return;
        if (rigidbody2d.velocity.y < airfallSlowdown && rigidbody2d.velocity.y > 0)
        {
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, 0);
        }
        else if(rigidbody2d.velocity.y > 0)
        {
            var velocity = rigidbody2d.velocity;
            velocity = new Vector2(velocity.x, velocity.y - airfallSlowdown);
            rigidbody2d.velocity = velocity;
        }
    }


    private bool IsGroundedRaycast()
    {
        const float extraHeight = .05f;
        var bounds = boxCollider2D.bounds;
        var raycastHit = Physics2D.BoxCast(bounds.center, bounds.size, 0f, Vector2.down,
            extraHeight, platformLayerMask);

        var rayColor = raycastHit.collider != null ? Color.green : Color.red;
        
        Debug.DrawRay(bounds.center + new Vector3(bounds.extents.x, 0),
            Vector2.down * (bounds.extents.y + extraHeight), rayColor);
        
        Debug.DrawRay(boxCollider2D.bounds.center - new Vector3(bounds.extents.x, 0),
            Vector2.down * (bounds.extents.y + extraHeight), rayColor);
        
        Debug.DrawRay(boxCollider2D.bounds.center - new Vector3(bounds.extents.x,
            bounds.extents.y + extraHeight), Vector2.right * (bounds.extents.x * 2f), rayColor);

        return raycastHit.collider != null;
    }

}
