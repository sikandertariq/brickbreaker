using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ball : MonoBehaviour
{   
    private AudioSource audioSource;
    public new Rigidbody2D rigidbody { get; private set; }
    public float speed = 10f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        ResetBall();
    }

    public void ResetBall()
    {
        rigidbody.velocity = Vector2.zero;
        transform.position = new Vector2(0f,-7f);

        Invoke(nameof(SetRandomTrajectory), 1f);
    }

    private void SetRandomTrajectory()
    {
        Vector2 force = new Vector2();
        force.x = Random.Range(-1f, 1f);
        force.y = -1f;

        rigidbody.AddForce(force.normalized * speed);
    }

    private void FixedUpdate()
    {
        rigidbody.velocity = rigidbody.velocity.normalized * speed;
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {   if (collision.gameObject.name == "Brick") {
            
            audioSource.enabled = true;
        audioSource.Play();
        }
        
    }

}
