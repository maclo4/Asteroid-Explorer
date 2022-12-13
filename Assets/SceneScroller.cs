using UnityEngine;

public class SceneScroller : MonoBehaviour
{
    public GameObject mapOne;
    public float[] mapScrollSpeed;
    public Vector3[] wayPoints;
    private int wayPointsIterator = 0;


    private void Update()
    {
        if (wayPointsIterator >= wayPoints.Length)
            return;
        
        var currentMapPosition = mapOne.transform.position;

        mapOne.transform.position = Vector3.MoveTowards(currentMapPosition, 
            wayPoints[wayPointsIterator], mapScrollSpeed[wayPointsIterator] * Time.deltaTime);
        
        if ((int)wayPoints[wayPointsIterator].x == (int)currentMapPosition.x &&
            (int)wayPoints[wayPointsIterator].y == (int)currentMapPosition.y)
        {
           // mapScrollSpeed 
            wayPointsIterator++;
        }
    }
}
