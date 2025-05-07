using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public GameObject playerPrefab; // Assign the player prefab in the inspector
    public Transform spawnPoint;    // Default spawn location
    public Camera freeCam;          // Assign your freecam camera

    private bool isDead = false;
    private Vector3 lastCheckpointPos;
    private Quaternion lastCheckpointRot;
    private GameObject currentPlayer;
    public bool IsPlayerDead() 
    {
        return isDead;
    }

    void Start()
    {
        freeCam.gameObject.SetActive(false);
        lastCheckpointPos = spawnPoint.position;
        lastCheckpointRot = spawnPoint.rotation;

        currentPlayer = GameObject.FindGameObjectWithTag("Player");
    }

    public void PlayerDied(Transform playerTransform)
    {
        if (isDead) return;
        isDead = true;

        // Hide player and enable freecam
        playerTransform.gameObject.SetActive(false);
        freeCam.transform.position = playerTransform.position;
        freeCam.transform.rotation = playerTransform.rotation;
        freeCam.gameObject.SetActive(true);

        Destroy(playerTransform.gameObject, 0.1f);
        currentPlayer = null;
    }

    public void RespawnPlayer()
    {
        if (!isDead) return;

        Vector3 spawnPos = lastCheckpointPos != Vector3.zero ? lastCheckpointPos : spawnPoint.position;
        Quaternion spawnRot = lastCheckpointRot;

        currentPlayer = Instantiate(playerPrefab, spawnPos, spawnRot);

        // Re-parent main camera to new player
        Camera.main.transform.SetParent(currentPlayer.transform);
        Camera.main.transform.localPosition = Vector3.zero;

        freeCam.gameObject.SetActive(false);
        isDead = false;
    }

    public void SetCheckpoint(Vector3 position, Quaternion rotation)
    {
        lastCheckpointPos = position;
        lastCheckpointRot = rotation;
        Debug.Log("Checkpoint updated: " + position);
    }

    void Update()
    {
        if (isDead && Input.GetKeyDown(KeyCode.Space))
        {
            RespawnPlayer();
        }

        // Debug: Check if multiple players exist
        if (GameObject.FindGameObjectsWithTag("Player").Length > 1)
        {
            Debug.LogWarning("More than one player exists in the scene!");
        }
    }
}
