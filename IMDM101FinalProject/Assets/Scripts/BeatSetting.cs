using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Scriptable Objects/BeatSetting")]
public class BeatSetting : ScriptableObject
{
    [SerializeField] BeatManager.Lane spawnLane;
    [SerializeField] float timeBeforeSpawnNext = -1;
    [SerializeField] float beatSpeed = -1;

    public BeatManager.Lane GetLane()
    {
        return spawnLane;
    }

    public float GetSpeed()
    {
        return beatSpeed;
    }

    public float GetSpawnInterval()
    {
        return timeBeforeSpawnNext;
    }
}
