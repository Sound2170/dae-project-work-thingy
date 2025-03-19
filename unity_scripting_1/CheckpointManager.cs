using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance;
    private Vector3 lastCheckpoint;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void SetCheckpoint(Vector3 position)
    {
        lastCheckpoint = position;
        Debug.Log("Checkpoint set at: " + position);
    }

    public Vector3 GetCheckpoint()
    {
        return lastCheckpoint;
    }
}
