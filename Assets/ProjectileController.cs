using System;
using Scripts;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private InputStates inputStates;
    private InputActions_AsteroidExplorer inputActions;
    private Rigidbody2D rigidbody2d;
    public float projectileSpeed;
    
    // Start is called before the first frame update
    private void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        inputStates = new InputStates();
        inputActions = new InputActions_AsteroidExplorer();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
        }
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        /*inputStates.aim = inputSystem.@default.Aim.ReadValue<Vector2>();
        rigidbody2d.AddForce(inputStates.aim * projectileSpeed);
        Debug.Log(inputStates.aim);
        Debug.Log(projectileSpeed);*/
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }
    
    private void OnDisable()
    {
        inputActions.Disable();
    }
}
