using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RespawnManager respawnManager = FindObjectOfType<RespawnManager>();
            if (respawnManager != null)
            {
                respawnManager.SetCheckpoint(transform.position, transform.rotation);
            }
        }
    }
}
