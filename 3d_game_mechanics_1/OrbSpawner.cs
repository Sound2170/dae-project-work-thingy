using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    public GameObject healingOrbPrefab; // Assign healing orb prefab
    public Transform spawnPoint; // Where the orbs spawn
    public int orbCount = 3; // How many orbs to spawn

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Press "E" to spawn orbs
        {
            SpawnHealingOrbs();
        }
    }

    void SpawnHealingOrbs()
    {
        for (int i = 0; i < orbCount; i++)
        {
            Vector3 spawnPos = spawnPoint.position + new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            Instantiate(healingOrbPrefab, spawnPos, Quaternion.identity);
        }
    }
}
