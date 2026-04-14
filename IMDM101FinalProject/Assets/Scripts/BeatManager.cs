using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeatManager : MonoBehaviour
{
    public enum Lane: int {
        ONE = 0, TWO = 1, THREE = 2, FOUR = 3
    }
    [SerializeField] LineRenderer[] lanes;
    [SerializeField] Lane[] beatMap;
    [SerializeField] float spawnTimer;
    private Queue<Lane> beatMapQueue;
    void Start()
    {
        if (beatMap.Length > 0)
        {
           beatMapQueue = new Queue<Lane>(beatMap); 
           Debug.Log("Beatmap exists and is not empty.");
        }

        InvokeRepeating("SpawnBeat", 0, .5f);
    }

    void SpawnBeat()
    {
        if (!(beatMapQueue.Count == 0))
        {
            LineRenderer l = new LineRenderer();
            switch (beatMapQueue.Dequeue())
            {   
                case Lane.ONE:
                    break;
                case Lane.TWO:
                    break;
                case Lane.THREE:
                    break;
                case Lane.FOUR:
                    break;
                default:
                    Debug.Log("** SpawnBeat Error **");
                    break;
            }
        }

        else
        {
            CancelInvoke();
            Debug.Log("No more beats to spawn.");
        }
    }
}
