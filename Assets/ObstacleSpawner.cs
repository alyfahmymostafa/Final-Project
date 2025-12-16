using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public float minInterval = 1.2f;
    public float maxInterval = 2.5f;

    public GameObject[] obstaclePrefabs;
    public Transform[] lanes;

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
            player.position.x + forwardOffset,
            71.5f,
            10f
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
            case 0: SpawnSingleObstacle(); break;
            case 1: SpawnDoubleObstacle(); break;
            case 2: SpawnWall(); break;
        }
    }

    void SpawnSingleObstacle()
    {
        SpawnObstacleAtLane(Random.Range(0, lanes.Length));
    }

    void SpawnDoubleObstacle()
    {
        int a = Random.Range(0, lanes.Length);
        int b;
        do { b = Random.Range(0, lanes.Length); } while (b == a);

        SpawnObstacleAtLane(a);
        SpawnObstacleAtLane(b);
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

        Vector3 pos = new Vector3(transform.position.x, 71.5f, lane.position.z);

        GameObject obj = Instantiate(prefab, pos, Quaternion.identity);
        obj.tag = "Obstacle";
    }
}
