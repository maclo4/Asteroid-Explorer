using System;
using Scripts;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using static Scripts.InputStatesEnum;

    
public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Animator upBoosterAnimator;
    [SerializeField] private Animator downBoosterAnimator;
    [SerializeField] private Animator leftBoosterAnimator;
    [SerializeField] private Animator rightBoosterAnimator;
    [SerializeField] private Animator spaceShipAnimator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask	platformLayerMask;

    private InputActions_AsteroidExplorer inputActions;
    private CharacterStates characterState;
    private InputStates inputStates;

    private SpaceShipAudioController spaceShipAudioController;
    
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
    [SerializeField] private int totalHealth;
    
    
    [SerializeField] private FuelGaugeController fuelGaugeController;
    [SerializeField] private float lowFuelSeconds;
    [SerializeField] private int lowFuelBoosterStrength;
    [SerializeField] private bool lowFuelIsActive;
    
    [SerializeField] private int boosterStrength;
    private int baseBoosterStrength;
    [SerializeField] private int dashStrength;
    [SerializeField] private int maxFloatSpeed;
    private static readonly int LeftPressed = Animator.StringToHash("leftPressed");
    private static readonly int RightPressed = Animator.StringToHash("rightPressed");
    private static readonly int UpPressed = Animator.StringToHash("upPressed");
    private static readonly int DownPressed = Animator.StringToHash("downPressed");
    private static readonly int Die1 = Animator.StringToHash("Die");
    private static readonly int FuelAmount = Animator.StringToHash("FuelAmount");

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
        spaceShipAudioController = gameObject.GetComponent<SpaceShipAudioController>();
        characterState = CharacterStates.Idle;
        inputStates = new InputStates();
        inputActions = new InputActions_AsteroidExplorer();
        inputActions.SpaceShipActionMap.Aim.performed += AimActionCallback;

        baseBoosterStrength = boosterStrength;
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


    private void AimActionCallback(InputAction.CallbackContext context)
    {
        inputStates.aim = context.ReadValue<Vector2>();
        if (inputStates.aim.x > .5 || inputStates.aim.y > .5 || inputStates.aim.x < -.5 || inputStates.aim.y < -.5)
        {
            inputStates.defaultAim = inputStates.aim;
        }
    }

    public void LeftActionCallback(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if(inputStates != null)
                inputStates.left = Pressed;
            if (leftBoosterAnimator != null && leftBoosterAnimator.isActiveAndEnabled)
                leftBoosterAnimator.SetBool(LeftPressed, true);
        }
        else if (context.performed){}
        else if (context.canceled)
        {
            if(inputStates != null)
                inputStates.left = Raised;
            if (leftBoosterAnimator != null && leftBoosterAnimator.isActiveAndEnabled)
                leftBoosterAnimator.SetBool(LeftPressed, false);
        }
        
    }

    public void RightActionCallback(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if(inputStates != null)
                inputStates.right = Pressed;
            if (rightBoosterAnimator != null && rightBoosterAnimator.isActiveAndEnabled)
                rightBoosterAnimator.SetBool(RightPressed, true);
        }
        else if (context.performed) {}
        else if (context.canceled)
        {
            if(inputStates != null)
                inputStates.right = Raised;
            if (rightBoosterAnimator != null && rightBoosterAnimator.isActiveAndEnabled)
                rightBoosterAnimator.SetBool(RightPressed, false);
        }
    }
    
    public void UpActionCallback(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if(inputStates != null)
                inputStates.up = Pressed;
            if (upBoosterAnimator != null && upBoosterAnimator.isActiveAndEnabled)
                upBoosterAnimator.SetBool(UpPressed, true);
        }
        else if (context.performed){}
        else if (context.canceled)
        {
            if(inputStates != null)
                inputStates.up = Raised;
            if (upBoosterAnimator != null && upBoosterAnimator.isActiveAndEnabled)
                upBoosterAnimator.SetBool(UpPressed, false);
        }

    }
    public void DownActionCallback(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if(inputStates != null)
                inputStates.down = Pressed;
            if (downBoosterAnimator != null && downBoosterAnimator.isActiveAndEnabled)
                downBoosterAnimator.SetBool(DownPressed, true);
        }
        else if (context.performed){}
        else if (context.canceled)
        {
            if(inputStates != null)
                inputStates.down = Raised;
            if (downBoosterAnimator != null && downBoosterAnimator.isActiveAndEnabled)
                downBoosterAnimator.SetBool(DownPressed, false);
        }

    }
    
    public void JumpActionCallback(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if(inputStates != null)
                inputStates.boost = Started;
        }
        else if (context.performed){}
        else if (context.canceled)
        {
            if(inputStates != null)
                inputStates.boost = Raised;
        }
    }
    public void BoostActionCallback(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if(inputStates != null)
                inputStates.boost = Started;
        }
        else if (context.performed){}
        else if (context.canceled)
        {
            if(inputStates != null)
                inputStates.boost = Raised;
        }
    }
    
    public void ShootActionCallback(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (inputStates != null)
            {
                var projectileInstance = Instantiate(projectile, transform);
                var projectileRigidbody = projectileInstance.GetComponent<Rigidbody2D>();
                var aimDirection = inputStates.aim;
                if (aimDirection.x < .05 && aimDirection.x > -.05 ||
                    aimDirection.y < .05 && aimDirection.y > -.05)
                {
                    projectileRigidbody.AddForce(inputStates.defaultAim.normalized * projectileSpeed);
                    return;
                }

                projectileRigidbody.AddForce(inputStates.aim.normalized * projectileSpeed);
            }
        }
        else if (context.performed){}
        else if (context.canceled)
        {
            
        }
    }

    // Update is called once per frame
    private void Update()
    {
        switch (characterState)
        {
            case CharacterStates.Idle:
                SelectActionFromIdle();
                break;
            case CharacterStates.Dead:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        if (inputStates.boost == Started)
        {
            inputStates.boost = Pressed;
        }
    }

    public void TakeDamage(int damage)
    {
        totalHealth -= damage;
        if (totalHealth <= 0)
        {
            rigidbody2d.velocity = Vector2.zero;
            characterState = CharacterStates.Dead;
            inputActions.Disable();
            spaceShipAnimator.SetBool(Die1, true);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }


    private void SelectActionFromIdle()
    {
        if (Boost())
        {
            return;
        }
        if (Move())        
        {
        }
    }
    private void SelectActionFromMove()
    {
        if (Boost())
        {
            return;
        }
        if (Move())
        {
        }
    }
    
    private bool Move()
    {
        //TODO: Account for keyboards holding both directions
        var isMoving = false;
        if (inputStates.left == Pressed)
        {
            if(rigidbody2d.velocity.x > -maxFloatSpeed)
                rigidbody2d.AddForce(new Vector2(-boosterStrength,0));
            isMoving = true;
        }
        if(inputStates.right == Pressed)
        {
            if(rigidbody2d.velocity.x < maxFloatSpeed)
                rigidbody2d.AddForce(new Vector2(boosterStrength,0));
            isMoving = true;
        }
        if(inputStates.up == Pressed)
        {
            if(rigidbody2d.velocity.y < maxFloatSpeed)
                rigidbody2d.AddForce(new Vector2(0,boosterStrength));
            isMoving = true;
        }
        if(inputStates.down == Pressed)
        {
            if(rigidbody2d.velocity.y > -maxFloatSpeed)
                rigidbody2d.AddForce(new Vector2(0,-boosterStrength));
            isMoving = true;
        }

        if(isMoving)
            spaceShipAudioController.PlayBoosterSoundEffect();
        else
            spaceShipAudioController.StopBoosterSoundEffect();
        
        return isMoving;
    }
    
    IEnumerator LowFuelTimer()
    {
        lowFuelIsActive = true;
        lowFuelBoosterStrength = 10;
        boosterStrength = lowFuelBoosterStrength;
        
        yield return new WaitForSeconds(lowFuelSeconds);
        
        boosterStrength = baseBoosterStrength;
        fuelGaugeController.SetGaugeFull();
        lowFuelIsActive = false;
    }
    
    private bool Boost()
    {
        //if (inputStates.boost != Pressed) return false;

        if (lowFuelIsActive || inputStates.boost != Pressed || 
            (inputStates.up != Pressed && inputStates.down != Pressed && 
            inputStates.left != Pressed && inputStates.right != Pressed)) return false;
        
        fuelGaugeController.DecreaseFuel();

        if (fuelGaugeController.IsFuelEmpty() && !lowFuelIsActive)
        {
            lowFuelIsActive = true;
        }

        return false;
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
            switch (inputStates.boost)
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
