using System;
using Scripts;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && 
            other.gameObject.GetInstanceID() != gameObject.transform.parent.gameObject.GetInstanceID())
        {
            other.TryGetComponent(out PlayerController playerController);
            playerController.TakeDamage(1);
            Destroy(gameObject);
        }
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
