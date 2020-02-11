using UnityEngine;

public class Ball : MonoBehaviour
{
    // serialized paras
    [SerializeField] Paddle paddle;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] collisionSounds;

    // state
    Vector3 ballToPaddleVector;
    bool hasStarted = false;

    // cached components
    AudioSource myAudioSource;
    Rigidbody2D myRigidbody2D;
    

    // Start is called before the first frame update
    void Start()
    {
        ballToPaddleVector = transform.position - paddle.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        if(!hasStarted)
        {
            LockBallToPaddle();
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
            myRigidbody2D.velocity = new Vector2(xPush, yPush);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(hasStarted)
        {
            AudioClip audioClip = collisionSounds[UnityEngine.Random.Range(0, collisionSounds.Length)];
            myAudioSource.PlayOneShot(audioClip);
        }
    }
}
