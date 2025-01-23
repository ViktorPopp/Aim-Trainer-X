using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;         // Reference to the target prefab
    public float spawnInterval = 2f;        // Time between spawns
    public float minSpawnDistance = 8f;     // Minimum distance from the player to spawn targets
    public float maxSpawnDistance = 12f;    // Maximum distance from the player to spawn targets
    public float minSpawnHeight = 1.2f;     // Minimum height at which targets spawn
    public float maxSpawnHeight = 2.0f;     // Maximum height at which targets spawn

    private Camera playerCamera;

    void Start()
    {
        playerCamera = Camera.main;
        InvokeRepeating("SpawnTarget", 0f, spawnInterval);
    }

    void SpawnTarget()
    {
        float randomX = Random.Range(-0.35f, 0.35f);
        float randomY = Random.Range(-0.225f, 0.225f);

        // Convert viewport coordinates to world coordinates
        Vector3 spawnDirection = new Vector3(randomX, randomY, 1).normalized;
        float spawnDistance = Random.Range(minSpawnDistance, maxSpawnDistance);
        Vector3 spawnPosition = playerCamera.transform.position + spawnDirection * spawnDistance;

        spawnPosition.y = Random.Range(minSpawnHeight, maxSpawnHeight);

        Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
    }
}
