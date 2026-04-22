using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Scriptable Objects/BeatSetting")]
public class BeatSetting : ScriptableObject
{
    [SerializeField] BeatManager.Lane spawnLane;
    [SerializeField] float timeBeforeSpawnNext = .5f;
    [SerializeField]  float beatSpeed;

    public BeatManager.Lane GetLane()
    {
        return spawnLane;
    }

    public float GetSpeed()
    {
        return beatSpeed;
    }
}
