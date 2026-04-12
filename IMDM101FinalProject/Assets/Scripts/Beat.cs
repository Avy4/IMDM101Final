using Unity.VisualScripting;
using UnityEngine;

public class Beat : MonoBehaviour
{   
    [SerializeField] LineRenderer line;
    [SerializeField] float speed = 3;
    private Vector3[] lerpPoints;
    private Vector3 nextPoint;
    private int idx;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        // Need to create an array large enough to hold all the positions
        lerpPoints = new Vector3[line.positionCount];
        // Gets the positions of each point of the line
        line.GetPositions(lerpPoints);
        // Init idx
        idx = lerpPoints.Length - 1;
        // Set starting pos, sub idx by 1, set next pos, sub idx by 1
        transform.position = lerpPoints[idx--];
        nextPoint = lerpPoints[idx--];
    }

    void Update()
    {   
        // Update the position everyframe, base speed is 3
        transform.position = Vector3.MoveTowards(transform.position, nextPoint, speed * Time.deltaTime);

        // If its close enough, then we can start going to the next point
        if (Vector3.Distance(transform.position, nextPoint) < .2)
        {   
            // Out of bounds check
            if (idx >= 0)
            {
                nextPoint = lerpPoints[idx--];
            }
        }
    }
}
