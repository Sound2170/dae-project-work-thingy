using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public GameObject playerPrefab; // Assign the player prefab
    public Transform spawnPoint; // Default respawn position
    public Camera freeCam; // Assign the freecam (Main Camera or a separate one)

    private bool isDead = false;
    private Vector3 lastCheckpointPos;
    private Quaternion lastCheckpointRot;
    private GameObject currentPlayer; // Store the current player reference

    void Start()
    {
        freeCam.gameObject.SetActive(false); // Disable freecam at start
        lastCheckpointPos = spawnPoint.position; // Default respawn position
        lastCheckpointRot = spawnPoint.rotation;
        currentPlayer = GameObject.FindGameObjectWithTag("Player"); // Get the initial player reference
    }

    public void PlayerDied(Transform playerTransform)
    {
        if (isDead) return;
        isDead = true;

        // Hide player before destroying it
        playerTransform.gameObject.SetActive(false);

        // Move freecam to player's last position
        freeCam.transform.position = playerTransform.position;
        freeCam.transform.rotation = playerTransform.rotation;

        // Enable freecam
        freeCam.gameObject.SetActive(true);

        // Destroy player after a short delay
        Destroy(playerTransform.gameObject, 0.1f);

        // Nullify player reference so it doesn't try to access a destroyed object
        currentPlayer = null;
    }

    public void RespawnPlayer()
    {
        if (!isDead) return;

        // Use the last checkpoint position if available
        Vector3 respawnPos = lastCheckpointPos != Vector3.zero ? lastCheckpointPos : spawnPoint.position;
        Quaternion respawnRot = lastCheckpointRot;

        // Instantiate a new player at the checkpoint position
        currentPlayer = Instantiate(playerPrefab, respawnPos, respawnRot);

        // Reassign the main camera to the new player
        Camera.main.transform.SetParent(currentPlayer.transform);
        Camera.main.transform.localPosition = Vector3.zero;

        freeCam.gameObject.SetActive(false); // Disable freecam
        isDead = false; // Reset death status
    }

    void Update()
    {
        if (isDead && Input.GetKeyDown(KeyCode.Space))
        {
            RespawnPlayer();
        }
    }

    // Called from the checkpoint script to update the checkpoint position
    public void SetCheckpoint(Vector3 position, Quaternion rotation)
    {
        lastCheckpointPos = position;
        lastCheckpointRot = rotation;
        Debug.Log("Checkpoint updated: " + position);
    }
}
