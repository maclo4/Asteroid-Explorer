using System;
using System.Collections.Generic;
using System.Linq;
using Pathfinding;
using UnityEngine;

public class TentacleAi : MonoBehaviour
{
    private Transform target;
    private Vector3 closestSurfaceToTarget;
    public float speed;
    public float nextWaypointDistance = 3f;

    private RandomTileSelector randomTileSelector;
    public Transform body;
     
    private Path path;
    private int currentWaypoint;
    private bool reachedEndOfPath = true;

    private Seeker seeker;
    private Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        randomTileSelector = GetComponent<RandomTileSelector>();
        var player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        
        closestSurfaceToTarget = randomTileSelector.ScanNearTarget(target.position, body.position);
        
        InvokeRepeating("UpdatePath", 0f, 1f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            closestSurfaceToTarget = randomTileSelector.ScanNearTarget(target.position, body.position);
            seeker.StartPath(transform.position, closestSurfaceToTarget, OnPathComplete);
        }

    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        var direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        var force = direction * speed * Time.deltaTime;
        rb.AddForce(force);
        
        
        var distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }
}
