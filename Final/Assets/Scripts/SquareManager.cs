using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareManager : MonoBehaviour
{
    [SerializeField] private GameObject squarePrefab;
    [SerializeField] private int maxSquareCount = 5;
    private Collider2D spawnCollider;

    private Vector2 maxSpawnPos;
    private Vector2 minSpawnPos;

    [SerializeField] private Vector2 minSquareScale;
    [SerializeField] private Vector2 maxSquareScale;

    public bool SquareRespawn;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
            GameObject newSquare = Instantiate(squarePrefab, squarePrefab.transform.position, Quaternion.identity);
            newSquare.transform.localScale = new Vector3(Random.Range(minSquareScale.x, maxSquareScale.x), Random.Range(minSquareScale.y, maxSquareScale.y), 1f);
            //newSquare.transform.position = GetRandomSpawnPos();

            if(SquareRespawn)
            {
                SquareController squareController = newSquare.GetComponent<SquareController>();
                squareController.OnSquareDestroyed += RespawnSquare;
            }
            SetRandomSquarePosition(newSquare);
        }
    }

    private Vector2 GetRandomSpawnPos()
    {
        float randomX = Random.Range(minSpawnPos.x, maxSpawnPos.x);
        float randomY = Random.Range(minSpawnPos.y, maxSpawnPos.y);
        return new Vector2(randomX, randomY);
    }

    public void RespawnSquare(SquareController square)
    {
        StartCoroutine(RespawnSquareAfterSeconds(square));
    }

    private IEnumerator RespawnSquareAfterSeconds(SquareController square)
    {
        yield return new WaitForSeconds(3f);
        square.gameObject.SetActive(true);
        SetRandomSquarePosition(square.gameObject);
    }

    private void SetRandomSquarePosition(GameObject squareGO)
    {
        Vector2 randomSquarePosition = GetRandomSpawnPos();

        float playerRadius = player.GetComponent<SpriteRenderer>().bounds.size.x / 2f;
        SpriteRenderer squareRenderer = squareGO.GetComponent<SpriteRenderer>();
        float squareDiagonal = Mathf.Sqrt(Mathf.Pow(squareRenderer.bounds.extents.x, 2) + Mathf.Pow(squareRenderer.bounds.extents.y, 2));

        while (Vector2.Distance(player.position, randomSquarePosition) < playerRadius + squareDiagonal)
        {
            Debug.Log(Vector2.Distance(player.position, randomSquarePosition));
            randomSquarePosition = GetRandomSpawnPos();
        }

        squareGO.transform.position = randomSquarePosition;
    }

}
