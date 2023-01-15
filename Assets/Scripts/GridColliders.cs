using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridColliders : MonoBehaviour
{
    private List<Vector3> colliderList;
    public Grid grid;
    private List<Tilemap> tilemaps;
    private float closestTileDistance = 1000f;
    private Vector3 currentTile = new Vector3();
    

    private void Awake()
    {
        tilemaps = grid.gameObject.GetComponentsInChildren<Tilemap>().ToList();
    }

    public Vector3 ScanNearbyTiles(Vector3 scanCenter, Vector3 target)
    {
        var currentTileDistanceFromBody = Vector3.Distance(currentTile, scanCenter);
        //this might be causing the issues
        if (currentTileDistanceFromBody < 100)
            return currentTile;
        
        var nextTile = new Vector3();
        
        foreach (var tilemap in tilemaps)
        {
            foreach (var position in tilemap.cellBounds.allPositionsWithin)
            {
                if (tilemap.GetTile(position))
                {
                    var distanceToTarget = Vector3.Distance(position, target);
                    var distanceFromBody = Vector3.Distance(scanCenter, position);
                    
                    if (distanceToTarget < closestTileDistance)//distanceFromBody < 10 && 
                    {
                        closestTileDistance = distanceToTarget;
                        currentTile = nextTile;
                    }
                }
            }
        }

        return nextTile;
        /*var nextTarget = new Vector3();
        playerGridPosition = tilemap.WorldToCell(scanCenter);

        for (var i = 0; i < 10; i++)
        {
            var nextTileLeft = new Vector3Int(
                playerGridPosition.x - 1, playerGridPosition.y, playerGridPosition.z);
            var nextTileRight = new Vector3Int(
                playerGridPosition.x + 1, playerGridPosition.y, playerGridPosition.z);
            var nextTileUp = new Vector3Int(
                playerGridPosition.x, playerGridPosition.y + 1, playerGridPosition.z);
            var nextTileDown = new Vector3Int(
                playerGridPosition.x, playerGridPosition.y - 1, playerGridPosition.z);
            
            var cellLeft = tilemap.GetTile(nextTileLeft);
            var cellRight = tilemap.GetTile(nextTileRight);
            var cellUp = tilemap.GetTile(nextTileUp);
            var cellDown = tilemap.GetTile(nextTileDown);
            
            if (cellLeft != null)
            {
                return nextTileLeft;
                colliders[nextTileLeft.x][nextTileLeft.y] = grid.CellToWorld(nextTileLeft);
            }
            if (cellRight != null)
            {
                return nextTileRight;
                colliders[nextTileRight.x][nextTileRight.y] = grid.CellToWorld(nextTileRight);
            }
            if (cellUp != null)
            {
                return nextTileUp;
                colliders[nextTileUp.x][nextTileUp.y] = grid.CellToWorld(nextTileUp);
            }
            if (cellDown != null)
            {
                return nextTileDown;
                colliders[nextTileDown.x][nextTileDown.y] = grid.CellToWorld(nextTileDown);
            }
        }

        throw new Exception("no tiles found");*/

        /*foreach (var colliderRow in colliders)
        {
            foreach (var vector3 in colliderRow)
            {
                Debug.Log(vector3);
            }
            
        }*/

    }
    
    /*public void OnDrawGizmos2D()
    {
        Gizmos.color = Color.red;
        var obstacles = colliders.Where(_ => _ != null).ToList();
        foreach (var tile in obstacles.SelectMany(obstacle => obstacle))
        {
            Gizmos.DrawWireSphere(tile, 1);
            tilemaps.GetTile(grid.WorldToCell(tile));
            Debug.Log(tile.ToString());
        }
            
    }*/
}
