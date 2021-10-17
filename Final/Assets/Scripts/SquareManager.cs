using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareManager : MonoBehaviour
{
    [SerializeField] private GameObject square;
    [SerializeField] private int maxSquareCount = 5;
    private Collider2D spawnCollider;

    private Vector2 maxSpawnPos;
    private Vector2 minSpawnPos;

    [SerializeField] private Vector2 minSquareScale;
    [SerializeField] private Vector2 maxSquareScale;

    private void Start()
    {
        spawnCollider = GetComponent<Collider2D>();
        maxSpawnPos = spawnCollider.bounds.max;
        minSpawnPos = spawnCollider.bounds.min;
        SpawnSquare();
    }

    private void SpawnSquare()
    {
        float squareSpawn = Random.Range(1, maxSquareCount + 1);
        for(int i = 0; i < squareSpawn; i++)
        {
            GameObject newSquare = Instantiate(square, square.transform.position, Quaternion.identity);
            newSquare.transform.localScale = new Vector3(Random.Range(minSquareScale.x, maxSquareScale.x), Random.Range(minSquareScale.y, maxSquareScale.y), 1f);
            newSquare.transform.position = GetRandomSpawnPos();
        }
    }

    private Vector2 GetRandomSpawnPos()
    {
        float randomX = Random.Range(minSpawnPos.x, maxSpawnPos.x);
        float randomY = Random.Range(minSpawnPos.y, maxSpawnPos.y);
        return new Vector2(randomX, randomY);
    }

}
