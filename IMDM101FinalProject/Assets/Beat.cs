using Unity.VisualScripting;
using UnityEngine;

public class Beat : MonoBehaviour
{   
    public LineRenderer line;
    private Vector3[] lerpPoints;
    private Vector3 nextPoint;
    private int idx;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        lerpPoints = new Vector3[line.positionCount];
        line.GetPositions(lerpPoints);
        idx = lerpPoints.Length - 1;
        transform.position = lerpPoints[idx];
        idx -= 1;
        nextPoint = lerpPoints[idx];
        idx -= 1;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPoint, 3 * Time.deltaTime);

        if (Vector3.Distance(transform.position, nextPoint) < .2)
        {   
            if (idx >= 0)
            {
                nextPoint = lerpPoints[idx];
                idx -= 1;   
            }
        }
    }
}
