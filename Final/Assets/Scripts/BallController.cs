using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D ballRB;
    private float ballSpeed = 50f;

    private void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();
        MoveBall();
    }

    private void MoveBall()
    {
        float randomAng = Random.Range(0f, 360f);
        Vector2 randomDir = new Vector2(Mathf.Cos(randomAng), Mathf.Sin(randomAng));
        ballRB.velocity = randomDir * ballSpeed * Time.fixedDeltaTime;
    }
}
