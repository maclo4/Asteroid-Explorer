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
    private Rigidbody2D rigidbody2d;

    private InputActions_AsteroidExplorer inputActions;
    private CharacterStates characterState;
    private InputStates inputStates;

    private SpaceShipAudioController spaceShipAudioController;
    
    [SerializeField] private ContactFilter2D ContactFilter;
    private bool IsGrounded => rigidbody2d.IsTouching(ContactFilter);
    
    public float projectileSpeed;
    private int jumpFloatFrameCounter = 0;
    [SerializeField] private int totalHealth;
    
    
    [SerializeField] private FuelGaugeController fuelGaugeController;
    [SerializeField] private bool lowFuelIsActive;
    
    [SerializeField] private int nitroBoosterStrength;
    [SerializeField] private int boosterStrength;
    private int baseBoosterStrength;
    [SerializeField] private int dashStrength;
    [SerializeField] private int maxFloatSpeed;
    private static readonly int LeftPressed = Animator.StringToHash("leftPressed");
    private static readonly int RightPressed = Animator.StringToHash("rightPressed");
    private static readonly int UpPressed = Animator.StringToHash("upPressed");
    private static readonly int DownPressed = Animator.StringToHash("downPressed");
    private static readonly int Die1 = Animator.StringToHash("Die");
    private static readonly int BoostPressed = Animator.StringToHash("boostPressed");

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
        
        rigidbody2d = GetComponent<Rigidbody2D>();
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
            
            //Set anim for nitro booster
            if (lowFuelIsActive || inputStates == null || leftBoosterAnimator == null || !leftBoosterAnimator.isActiveAndEnabled ||
                rightBoosterAnimator == null || !rightBoosterAnimator.isActiveAndEnabled || upBoosterAnimator == null ||
                !upBoosterAnimator.isActiveAndEnabled || downBoosterAnimator == null ||
                !downBoosterAnimator.isActiveAndEnabled) return;
            
            leftBoosterAnimator.SetBool(BoostPressed, true);
            rightBoosterAnimator.SetBool(BoostPressed, true);
            upBoosterAnimator.SetBool(BoostPressed, true);
            downBoosterAnimator.SetBool(BoostPressed, true);
        }
        else if (context.performed){}
        else if (context.canceled)
        {
            if(inputStates != null)
                inputStates.boost = Raised;
            
            //Set anim for nitro booster
            if (inputStates == null || leftBoosterAnimator == null || !leftBoosterAnimator.isActiveAndEnabled ||
                rightBoosterAnimator == null || !rightBoosterAnimator.isActiveAndEnabled || upBoosterAnimator == null ||
                !upBoosterAnimator.isActiveAndEnabled || downBoosterAnimator == null ||
                !downBoosterAnimator.isActiveAndEnabled) return;
            
            leftBoosterAnimator.SetBool(BoostPressed, false);
            rightBoosterAnimator.SetBool(BoostPressed, false);
            upBoosterAnimator.SetBool(BoostPressed, false);
            downBoosterAnimator.SetBool(BoostPressed, false);
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

    private void SelectActionFromIdle()
    {
        if (Boost())
        {
            return;
        }
        if (Move(boosterStrength))        
        {
        }
    }
    
    private bool Move(float boosterDefaultStrength)
    {
        //TODO: Account for keyboards holding both directions
        var isMoving = false;
        if (inputStates.left == Pressed)
        {
            if(rigidbody2d.velocity.x > -maxFloatSpeed)
                rigidbody2d.AddForce(new Vector2(-boosterDefaultStrength,0));
            isMoving = true;
        }
        if(inputStates.right == Pressed)
        {
            if(rigidbody2d.velocity.x < maxFloatSpeed)
                rigidbody2d.AddForce(new Vector2(boosterDefaultStrength,0));
            isMoving = true;
        }
        if(inputStates.up == Pressed)
        {
            if(rigidbody2d.velocity.y < maxFloatSpeed)
                rigidbody2d.AddForce(new Vector2(0,boosterDefaultStrength));
            isMoving = true;
        }
        if(inputStates.down == Pressed)
        {
            if(rigidbody2d.velocity.y > -maxFloatSpeed)
                rigidbody2d.AddForce(new Vector2(0,-boosterDefaultStrength));
            isMoving = true;
        }

        if(isMoving)
            spaceShipAudioController.PlayBoosterSoundEffect();
        else
            spaceShipAudioController.StopBoosterSoundEffect();
        
        return isMoving;
    }

    private bool Boost()
    {
        //if (inputStates.boost != Pressed) return false;

        if (lowFuelIsActive || inputStates.boost != Pressed || 
            (inputStates.up != Pressed && inputStates.down != Pressed && 
            inputStates.left != Pressed && inputStates.right != Pressed)) return false;

        Move(nitroBoosterStrength);
        fuelGaugeController.DecreaseFuel();

        if (fuelGaugeController.IsFuelEmpty() && !lowFuelIsActive)
        {
            lowFuelIsActive = true;
        }

        return true;

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
        OnDisable();
        Destroy(gameObject);
    }

}
