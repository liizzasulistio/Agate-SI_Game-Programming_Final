using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D ballRB;
    [SerializeField] private float ballSpeed = 50f;

    private void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();
        Vector2 ballDir = GetRandomDir();
        MoveBall(ballDir);
    }

    public void MoveBall(Vector3 randomDir)
    {
        ballRB.velocity = randomDir * ballSpeed * Time.fixedDeltaTime;
    }

    private Vector2 GetRandomDir()
    {
        float randomAng = Random.Range(0f, 360f);
        Vector2 randomDir = new Vector2(Mathf.Cos(randomAng), Mathf.Sin(randomAng));
        return randomDir;
    }

}
