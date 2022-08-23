using System;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject teleportDestination;
    public bool teleporterSouth;
    public bool teleporterNorth;
    public bool teleporterEast;
    public bool teleporterWest;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player") &&
            !other.CompareTag("Projectile")) return;
        
            var rigidbody2D = other.GetComponent<Rigidbody2D>();
            
            // check if moving in the correct direction for each possible teleporter
            if ((teleporterSouth && rigidbody2D.velocity.y < 0) ||
                (teleporterNorth && rigidbody2D.velocity.y > 0))
            {
                var transform1 = other.transform;
                var position = transform1.position;
                position = new Vector3(position.x, teleportDestination.transform.position.y, position.z);
                transform1.position = position;
            } 
            
            // check if moving in the correct direction for each possible teleporter
            if((teleporterEast && !(rigidbody2D.velocity.x < 0)) || 
               (teleporterWest && !(rigidbody2D.velocity.x > 0)))
            {               
                var transform1 = other.transform;
                var position = transform1.position;
                position = new Vector3(teleportDestination.transform.position.x, position.y, position.z);
                transform1.position = position;
            }


    }

}
