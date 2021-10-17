using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D ballRB;
    Vector2 keyboardInputAxis;
    Vector2 balltoMouseDir;
    [SerializeField] private float ballSpeed = 50f;
    [SerializeField] private MovementType movementType;

    private void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();
        //if we chose to let the ball without control
        if(movementType == MovementType.RANDOM)
        {
            Vector2 ballDir = GetRandomDir();
            MoveBall(ballDir);
        }
        
    }

    private void Update()
    {
        //if we chose to use keyboard
        keyboardInputAxis = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        //if we chose to use mouse
        if(movementType == MovementType.MOUSE_CONTROLLED)
        {
            Vector3 mousePositionInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(Vector2.Distance(mousePositionInWorld, transform.position) < 0.1f)
            {
                balltoMouseDir = Vector2.zero;
            }
            else
            {
                balltoMouseDir = ((Vector2)(mousePositionInWorld - transform.position)).normalized;
            }
        }

    }

    private void FixedUpdate()
    {
        if (movementType == MovementType.KEYBOARD_CONTROLLED)
        {
            MoveBall(keyboardInputAxis);
        }
        else if(movementType == MovementType.MOUSE_CONTROLLED)
        {
            MoveBall(balltoMouseDir);
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
    KEYBOARD_CONTROLLED,
    MOUSE_CONTROLLED
}
