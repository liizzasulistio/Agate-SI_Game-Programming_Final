using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : Spawner
{
    [SerializeField] private float spawnDelay = 5f;
    [SerializeField] private GameObject[] obstaclesPrefab;
    [SerializeField] private Collider2D obstacleArea;
    [SerializeField] private int difficultyIncrementScore = 20;

    private List<GameObject> spawnedObstacles = new List<GameObject>();
    private int lastScoreDifficultyIncrement = 0;
    float[,] position;

    protected override void Start()
    {
        base.Start();
        position = new float[,] { { obstacleArea.bounds.min.x, obstacleArea.bounds.max.x }, { obstacleArea.bounds.min.y, obstacleArea.bounds.max.y } };
        StartCoroutine(SpawnObstacles());
    }

    private void Update()
    {
        int curScore = ScoreController.Instance.GetScore();
        if (curScore != lastScoreDifficultyIncrement && curScore % difficultyIncrementScore == 0)
        {
            spawnDelay = Mathf.Clamp(spawnDelay - 0.5f, 1f, 100f);
            lastScoreDifficultyIncrement = curScore;
        }
    }

    private IEnumerator SpawnObstacles()
    {
        while (true)
        {
            float randomTime = Random.Range(spawnDelay - 1f, spawnDelay + 1f);
            yield return new WaitForSeconds(randomTime);
            GameObject newObstacle = GetOrCreateObstacle();
            SetObstacleSpawnPosition(newObstacle);
            newObstacle.SetActive(true);
        }
    }

    private GameObject GetOrCreateObstacle()
    {
        int randomObstacleIndex = Random.Range(0, obstaclesPrefab.Length);
        GameObject obstacle = spawnedObstacles.Find(o => !o.activeSelf && o.name.Contains(obstaclesPrefab[randomObstacleIndex].name));
        if (obstacle == null)
        {
            obstacle = Instantiate(obstaclesPrefab[randomObstacleIndex]);
            spawnedObstacles.Add(obstacle);
        }

        return obstacle;
    }

    private void SetObstacleSpawnPosition(GameObject obstacle)
    {
        obstacle.transform.position = GetRandomSpawnPosition();
    }

}
