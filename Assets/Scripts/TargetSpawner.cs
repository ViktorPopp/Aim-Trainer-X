using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab; 
    public float gridSize = 5f; 
    public float spawnDepth = 2f; // Depth from spawner (for visibility from the side)
    public float respawnDelay = 1f; 

    private bool[,] gridOccupied = new bool[5, 5]; 
    private int targetCount = 0; 
    private const int maxTargets = 3; 
    private bool isRespawning = false; 

    void Start()
    {
        for (int i = 0; i < maxTargets; i++)
        {
            SpawnTarget();
        }
    }

    void Update()
    {
        if (targetCount < maxTargets && !isRespawning)
        {
            isRespawning = true;
            Invoke("DelayedSpawn", respawnDelay);
        }
    }

    void DelayedSpawn()
    {
        isRespawning = false;
        SpawnTarget();
    }

    void SpawnTarget()
    {
        if (targetCount >= maxTargets) return;

        int gridX, gridY;
        int attempts = 0;
        do
        {
            gridX = Random.Range(0, 5);
            gridY = Random.Range(0, 5);
            attempts++;
            if (attempts > 25) return;
        } while (gridOccupied[gridX, gridY]);

        gridOccupied[gridX, gridY] = true;

        float gridSpacing = gridSize / 5f;
        // Vertical grid layout (X for horizontal, Y for vertical)
        float offsetX = (gridX - 2) * gridSpacing; 
        float offsetY = (gridY - 2) * gridSpacing; 

        // Position: X (horizontal), Y (vertical), Z (depth for side visibility)
        Vector3 spawnPosition = transform.position + 
            new Vector3(offsetX, offsetY, spawnDepth);

        // Rotate target 90° around X-axis to make it upright
        Quaternion spawnRotation = Quaternion.Euler(90f, 0f, 0f); 
        GameObject target = Instantiate(targetPrefab, spawnPosition, spawnRotation);

        TargetController targetController = target.AddComponent<TargetController>();
        targetController.Initialize(gridX, gridY, this);

        targetCount++;
    }

    public void FreeGridPosition(int gridX, int gridY)
    {
        gridOccupied[gridX, gridY] = false;
        targetCount--;
    }
}

public class TargetController : MonoBehaviour
{
    private int gridX, gridY;
    private TargetSpawner spawner;

    public void Initialize(int x, int y, TargetSpawner spawner)
    {
        gridX = x;
        gridY = y;
        this.spawner = spawner;
    }

    void OnDestroy()
    {
        spawner.FreeGridPosition(gridX, gridY);
    }
}