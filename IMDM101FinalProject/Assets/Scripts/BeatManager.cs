using System.Collections.Generic;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    public enum Lane: int {
        ONE = 0, TWO = 1, THREE = 2, FOUR = 3
    }

    [Header("Initialization")]
    // Initialize this with the lanes 1-4 in order.
    [SerializeField] LineRenderer[] lanes;
    [SerializeField] GameObject beatPrefab;
    [SerializeField] BeatMap beatMapContainer;
    private Queue<Lane> beatMapQueue;

    // These mirror the variables in BeatMap
    // There are private references here so you can easily switch out beatmaps
    private Lane[] beatMap;
    private float timeBeforeStart;
    private float spawnInterval;
    private float beatSpeed;

    void Start()
    {   
        if (beatMapContainer)
        {   
            // Init the private vars from beatMapContainer
            beatMap = beatMapContainer.GetBeatMap();
            timeBeforeStart = beatMapContainer.GetTimeBeforeStart();
            spawnInterval = beatMapContainer.GetSpawnInterval();
            beatSpeed = beatMapContainer.GetBeatSpeed();

            // Just a simple check to ensure that you created a beatmap.
            if (beatMap.Length > 0)
            {
                // Conv the array to a queue.
                beatMapQueue = new Queue<Lane>(beatMap); 
                Debug.Log("Beatmap exists and is not empty.");

                // Calls SpawnBeat every spawnInterval and timeBeforeStart has elapsed
                InvokeRepeating("SpawnBeat", timeBeforeStart, spawnInterval);
            }
        }
    }

    void SpawnBeat()
    {   
        // Check to make sure the beatmap hasn't finished.
        if (!(beatMapQueue.Count == 0))
        {   
            // Dequeue the enum and convert it to an int that corresponds to which lane it is for
            int laneNumber = (int)beatMapQueue.Dequeue();
            LineRenderer lane = lanes[laneNumber];

            // Create a new beat and initialize it
            GameObject newBeat = Instantiate(beatPrefab);
            newBeat.GetComponent<Beat>().Initialize(lane, beatSpeed);
        }

        // If the beatmap is finished then we CancelInvoke. 
        // CancelInvoke essentially turns off the InvokeRpeating() call from Start()
        else
        {
            CancelInvoke();
            Debug.Log("No more beats to spawn.");
        }
    }
}
