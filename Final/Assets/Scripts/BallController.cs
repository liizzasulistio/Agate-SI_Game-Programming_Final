using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D ballRB;
    Vector2 keyboardInputAxis;

    [SerializeField] private float ballSpeed = 50f;
    [SerializeField] private MovementType movementType;

    private void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();
       
        if(movementType == MovementType.RANDOM)
        {
            Vector2 ballDir = GetRandomDir();
            MoveBall(ballDir);
        }
        
    }

    private void Update()
    {
        keyboardInputAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }

    private void FixedUpdate()
    {
        if (movementType == MovementType.KEYBOARD_CONTROLLED)
        {
            MoveBall(keyboardInputAxis);
        }
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

public enum MovementType
{
    RANDOM,
    KEYBOARD_CONTROLLED
}
