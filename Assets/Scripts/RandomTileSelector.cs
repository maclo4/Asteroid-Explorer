using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Tilemaps;

public class RandomTileSelector : MonoBehaviour
{
    public Tilemap tilemap;

    private List<Vector3Int> selectedTiles;
    private float closestTileDistance = 10000;
    private Vector3 nextWaypoint;
    private Vector3 currentWaypoint;

    public Vector3 GetRandomTiles(Vector3 target, int numberOfTiles = 10)
    {
        selectedTiles = new List<Vector3Int>();

        for (var i = 0; i < numberOfTiles; i++)
        {
            var randomTile = new Vector3Int(Random.Range(tilemap.cellBounds.xMin, tilemap.cellBounds.xMax), 
                Random.Range(tilemap.cellBounds.yMin, tilemap.cellBounds.yMax), 0);
            
            if (!selectedTiles.Contains(randomTile) && tilemap.HasTile(randomTile))
            {
                selectedTiles.Add(randomTile);
            }
            else
            {
                i--;
            }
        }

        foreach (var cellPosition in selectedTiles)
        {
            var worldPosition = tilemap.CellToWorld(cellPosition);
            var distanceToTarget = Vector3.Distance(worldPosition, target);
                    
            if (distanceToTarget < closestTileDistance)//distanceFromBody < 10 && 
            {
                closestTileDistance = distanceToTarget;
                nextWaypoint = worldPosition;
            }
        }
        
        return nextWaypoint;
    }

    public Vector3 ScanNearTarget(Vector3 searchLocation, Vector3 target, int searchRadius = 15, int maxTiles = 5)
    {
        var closestTile = 100f;
        var foundTiles = new List<Vector3Int>();

        Vector3Int searchLocationCell = tilemap.WorldToCell(searchLocation);

        for (int i = 0; i < 15; i++)
        {
            var randomX = Random.Range(searchLocationCell.x - searchRadius, searchLocationCell.x + searchRadius);
            var randomY = Random.Range(searchLocationCell.y - searchRadius, searchLocationCell.y + searchRadius);
            Vector3Int currentCell = new Vector3Int(randomX, randomY, searchLocationCell.z);
            
            if (tilemap.HasTile(currentCell) && !foundTiles.Contains(currentCell))
            {
                foundTiles.Add(currentCell);  
            }

            if (foundTiles.Count >= maxTiles)
            {
                break;
            }
        }
        
        /*for (int x = searchLocationCell.x - searchRadius; x <= searchLocationCell.x + searchRadius; x++)
        {
            for (int y = searchLocationCell.y - searchRadius; y <= searchLocationCell.y + searchRadius; y++)
            {
                Vector3Int currentCell = new Vector3Int(x, y, searchLocationCell.z);

                if (tilemap.HasTile(currentCell) && !foundTiles.Contains(currentCell))
                {
                    foundTiles.Add(currentCell);
                }

                if (foundTiles.Count >= maxTiles)
                {
                    break;
                }
            }

            if (foundTiles.Count >= maxTiles)
            {
                break;
            }
        }*/

        foreach (var tile in foundTiles)
        {
            var distanceToTarget = Vector3.Distance(tile, target);
            if (distanceToTarget < closestTile)
                currentWaypoint = tilemap.CellToWorld(tile);
        }

        return currentWaypoint;
    }
}