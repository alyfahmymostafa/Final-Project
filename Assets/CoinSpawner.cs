using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public float minInterval = 0.8f;
    public float maxInterval = 1.6f;

    public GameObject[] coinPrefabs;
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
            case 0: SpawnSingleCoin(); break;
            case 1: SpawnDoubleCoin(); break;
            case 2: SpawnCoinWall(); break;
        }
    }

    void SpawnSingleCoin()
    {
        SpawnCoinAtLane(Random.Range(0, lanes.Length));
    }

    void SpawnDoubleCoin()
    {
        int a = Random.Range(0, lanes.Length);
        int b;
        do { b = Random.Range(0, lanes.Length); } while (b == a);

        SpawnCoinAtLane(a);
        SpawnCoinAtLane(b);
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

        Vector3 pos = new Vector3(transform.position.x, 71.5f + 1.5f, lane.position.z);

        GameObject coin = Instantiate(prefab, pos, Quaternion.identity);
        coin.tag = "Collectible";
    }
}
