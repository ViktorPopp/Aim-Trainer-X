using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;     // Reference to the target prefab
    public float spawnInterval = 2f;    // Time between spawns
    public float spawnRadius = 5f;      // Radius around the player to spawn targets

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("SpawnTarget", 0f, spawnInterval);
    }

    void SpawnTarget()
    {
        Vector3 randomPosition = player.position + Random.onUnitSphere * spawnRadius;
        randomPosition.y = player.position.y;
        Instantiate(targetPrefab, randomPosition, Quaternion.identity);
    }
}
