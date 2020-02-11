using UnityEngine;

public class Ball : MonoBehaviour
{
    // serialized paras
    [SerializeField] Paddle paddle;
    [SerializeField] float force = 1000f;
    [SerializeField] AudioClip[] collisionSounds;
    [SerializeField] float screenWidthInUnit = 16f;

    // state
    Vector3 ballToPaddleVector;
    bool hasStarted = false;
    Vector2 forceDirection;

    // cached components
    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;
    LineRenderer myLineRenderer;

    LoseTrigger loseTrigger;


    void Start()
    {
        ballToPaddleVector = transform.position - paddle.transform.position;

        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myLineRenderer = GetComponent<LineRenderer>();

        loseTrigger = FindObjectOfType<LoseTrigger>();
        loseTrigger.AddOneBall();
    }

    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            DrawProjectionLine();
            ClickToLaunchTheBall();
        }
    }

    private void LockBallToPaddle()
    {
        transform.position = paddle.transform.position + ballToPaddleVector;
    }

    private void ClickToLaunchTheBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            Destroy(myLineRenderer);
            myRigidbody2D.AddForce(forceDirection * force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip audioClip = collisionSounds[UnityEngine.Random.Range(0, collisionSounds.Length)];
            myAudioSource.PlayOneShot(audioClip);
        }
    }

    public void SetStart(bool start)
    {
        hasStarted = start;
    }

    public void DrawProjectionLine()
    {
        var moustPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        forceDirection = moustPos - gameObject.transform.position;
        forceDirection.Normalize();
        // for some unknown, .Normalize() and .normalized do not work the same

        myLineRenderer.SetPosition(0, gameObject.transform.position);
        myLineRenderer.SetPosition(1, moustPos); 
    }
}