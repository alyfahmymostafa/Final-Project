using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Spawn Timing")]
    public float minInterval = 0.8f;
    public float maxInterval = 1.6f;

    [Header("Coin Prefabs")]
    public GameObject[] coinPrefabs;

    [Header("Lane Positions")]
    public Transform[] lanes;   // same lanes as obstacles

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
            player.position.x + forwardOffset,
            74f,
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
            case 0:
                SpawnSingleCoin();
                break;
            case 1:
                SpawnDoubleCoin();
                break;
            case 2:
                SpawnCoinWall();
                break;
        }
    }

    void SpawnSingleCoin()
    {
        int laneIndex = Random.Range(0, lanes.Length);
        SpawnCoinAtLane(laneIndex);
    }

    void SpawnDoubleCoin()
    {
        int firstLane = Random.Range(0, lanes.Length);
        int secondLane;

        do
        {
            secondLane = Random.Range(0, lanes.Length);
        }
        while (secondLane == firstLane);

        SpawnCoinAtLane(firstLane);
        SpawnCoinAtLane(secondLane);
    }

    void SpawnCoinWall()
    {
        for (int i = 0; i < lanes.Length; i++)
            SpawnCoinAtLane(i);
    }

    void SpawnCoinAtLane(int laneIndex)
{
    GameObject prefab = coinPrefabs[Random.Range(0, coinPrefabs.Length)];
    Transform lane = lanes[laneIndex];

    // Base ground height (same as obstacles) – adjust if your ground Y changes
    float groundY = 70f;

    // Extra height to keep coin above ground
    float coinHeightOffset = 2.0f; // you can tweak this

    Vector3 spawnPos = new Vector3(
        transform.position.x,
        groundY + coinHeightOffset,
        lane.position.z
    );

    Instantiate(prefab, spawnPos, Quaternion.identity);
}
}
