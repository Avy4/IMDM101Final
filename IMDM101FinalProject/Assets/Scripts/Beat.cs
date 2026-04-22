using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Beat : MonoBehaviour
{   
    private float speed;
    private LineRenderer line;
    private Vector3[] lerpPoints;
    private Vector3 startingPos;
    private Vector3 nextPoint;
    private int idx;
    private int currentLayer;
    private bool gotScore = false;
    
    void Start()
    {   
        // CHANGE IN FINAL IMPLEMENTATION
        startingPos = line.transform.position;

        // Need to create an array large enough to hold all the positions
        lerpPoints = new Vector3[line.positionCount];

        // Gets the positions of each point of the line
        line.GetPositions(lerpPoints);

        // Init idx
        idx = lerpPoints.Length - 1;

        // Set starting pos, sub idx by 1, set next pos, sub idx by 1
        transform.position = lerpPoints[idx--] + startingPos;
        nextPoint = lerpPoints[idx--] + startingPos;
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
                nextPoint = lerpPoints[idx--] + startingPos;
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {   
        String currentLayerTag = collision.gameObject.name;
        if (!gotScore) {
            if (currentLayerTag == "Inner")
            {
                currentLayer = 0;
            }
            else if (currentLayerTag == "Middle")
            {
                currentLayer = 2;
            }
            else if (currentLayerTag == "Outer")
            {
                currentLayer = 1;
            }
        }   
    }

    public void Initialize(LineRenderer ln, float spd)
    {
        line = ln;
        speed = spd;

        // Can add implementation to change the sprite of the gameobject here too
    }
    public void GetScore()
    {
        gotScore = true;
        Debug.Log(currentLayer);
        gameObject.SetActive(false);
    }
}
