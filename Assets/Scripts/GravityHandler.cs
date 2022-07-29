using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityHandler : MonoBehaviour
{
    [SerializeField] private float xGravity;
    [SerializeField] private float yGravity;
    [SerializeField] private float projectileGravityMultiplier;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.TryGetComponent(out Rigidbody2D rigidbody2D);
            rigidbody2D.gravityScale = 0;
            rigidbody2D.AddForce(new Vector2(xGravity, yGravity));
        }
        if (other.CompareTag("Projectile"))
        {
            var projectileRigidBody = other.gameObject.GetComponent<Rigidbody2D>();
            projectileRigidBody.gravityScale = 0;
            projectileRigidBody.AddForce(new Vector2(xGravity * projectileGravityMultiplier, yGravity * projectileGravityMultiplier));
        }
    }
}
