using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    public GameObject healingOrbPrefab; // Assign healing orb prefab
    public Transform spawnPoint; // Where the orbs spawn
    public int orbCount = 3; // How many orbs to spawn
    public float spawnInterval = 3f; // Time between spawns

    private bool playerNearby = false;
    private float spawnTimer = 0f;

    [System.Obsolete]
    void Update()
{
    RespawnManager respawnManager = FindObjectOfType<RespawnManager>();

    if (playerNearby && respawnManager != null && !respawnManager.IsPlayerDead())
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            SpawnHealingOrbs();
            spawnTimer = 0f;
        }
    }
}

    void SpawnHealingOrbs()
    {
        for (int i = 0; i < orbCount; i++)
        {
            Vector3 spawnPos = spawnPoint.position + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            Instantiate(healingOrbPrefab, spawnPos, Quaternion.identity);
            Rigidbody rb = healingOrbPrefab.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse); // Play with the 5f value to get the bounce you like
        }
        }
    }

    // Player enters the spawner trigger zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            spawnTimer = 0f; 
        }
    }

    // Player exits the spawner trigger zone
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
            spawnTimer = 0f; // Optional: reset timer when player leaves
        }
    }
}
