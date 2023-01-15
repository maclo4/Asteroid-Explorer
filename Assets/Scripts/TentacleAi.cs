using System;
using System.Collections.Generic;
using System.Linq;
using Pathfinding;
using UnityEngine;

public class TentacleAi : MonoBehaviour
{
    private Transform target;
    private Vector3 closestSurfaceToTarget;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;

    private RandomTileSelector randomTileSelector;
    public Transform body;
     
    private Path path;
    private int currentWaypoint;
    private bool reachedEndOfPath;

    private Seeker seeker;
    public Seeker bodyToTentacleSeeker;
    private Path bodyToTentaclePath;

    private Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        randomTileSelector = GetComponent<RandomTileSelector>();
        bodyToTentacleSeeker = GetComponentInChildren<Seeker>();
        var player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        
        closestSurfaceToTarget = randomTileSelector.ScanNearTarget(transform.position, target.position);
        
        InvokeRepeating("UpdatePath", 0f, .5f);
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
        {
            closestSurfaceToTarget = randomTileSelector.ScanNearTarget(transform.position, target.position);
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
    
    void UpdateBodyToTentaclePath()
    {
        if (bodyToTentacleSeeker.IsDone())
        {
            bodyToTentacleSeeker.StartPath(body.position, rb.position, OnBodyToTentaclePathComplete);
        }

    }
    void OnBodyToTentaclePathComplete(Path p)
    {
        if (!p.error)
        {
            bodyToTentaclePath = p;
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

        
        //DrawTentacle();
        
        var direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        var force = direction * speed * Time.deltaTime;
        rb.AddForce(force);
        
        
        var distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }
    }

    /*
    private void DrawTentacle()
    {
        if (bodyToTentaclePath == null) return;
        
        lineRenderer.positionCount = bodyToTentaclePath.path.Count;
        for (var i = 0; i < lineRenderer.positionCount; i++)
        {
            lineRenderer.SetPosition(i, (Vector3)bodyToTentaclePath.path[i].position);
        }
    }*/
    
}
