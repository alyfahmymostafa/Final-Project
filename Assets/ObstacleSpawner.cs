using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Spawn Timing")]
    public float minInterval = 1.2f;
    public float maxInterval = 2.5f;

    [Header("Obstacle Prefabs")]
    public GameObject[] obstaclePrefabs;

    [Header("Lane Positions")]
    public Transform[] lanes;   // 0 = Left (Z=15), 1 = Middle (Z=10), 2 = Right (Z=5)

    [Header("Player Reference")]
    public Transform player;
    public float forwardOffset = 30f;

    private float nextSpawnTime;

    void Start()
    {
        ScheduleNextSpawn();
    }

    void Update()
    {
        FollowPlayer();

        if (Time.time >= nextSpawnTime)
        {
            SpawnRandomPattern();
            ScheduleNextSpawn();
        }
    }

    void FollowPlayer()
    {
        transform.position = new Vector3(
            player.position.x + forwardOffset,   // stay ahead on +X
            71.5f,                               // ground height
            10f                                  // middle lane Z
        );
    }

    void ScheduleNextSpawn()
    {
        nextSpawnTime = Time.time + Random.Range(minInterval, maxInterval);
    }

    void SpawnRandomPattern()
    {
        int pattern = Random.Range(0, 3);

        switch (pattern)
        {
            case 0:
                SpawnSingleObstacle();
                break;
            case 1:
                SpawnDoubleObstacle();
                break;
            case 2:
                SpawnWall();
                break;
        }
    }

    void SpawnSingleObstacle()
    {
        int laneIndex = Random.Range(0, lanes.Length);
        SpawnObstacleAtLane(laneIndex);
    }

    void SpawnDoubleObstacle()
    {
        int firstLane = Random.Range(0, lanes.Length);
        int secondLane;

        do
        {
            secondLane = Random.Range(0, lanes.Length);
        }
        while (secondLane == firstLane);

        SpawnObstacleAtLane(firstLane);
        SpawnObstacleAtLane(secondLane);
    }

    void SpawnWall()
    {
        for (int i = 0; i < lanes.Length; i++)
            SpawnObstacleAtLane(i);
    }

    void SpawnObstacleAtLane(int laneIndex)
    {
        GameObject prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
        Transform lane = lanes[laneIndex];

        Vector3 spawnPos = new Vector3(
            transform.position.x,   // ahead of player
            70f,                  // ground height
            lane.position.z         // ✅ correct lane Z (fix applied)
        );

        GameObject obstacle = Instantiate(prefab, spawnPos, Quaternion.identity);

        float scale = Random.Range(1.2f, 2.0f);
        obstacle.transform.localScale = Vector3.one * scale;
    }
}
