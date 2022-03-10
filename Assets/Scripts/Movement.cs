using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private SpriteRenderer _renderer;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private bool faling;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        FlipBody();

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
            grounded = false;
        }
        anim.SetBool("Run", horizontalInput != 0);
        anim.SetBool("Grounded", grounded);
        anim.SetBool("Faling", faling);

        IsFaling();
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
    }

    private void IsFaling()
    {
        if ((body.velocity.y) < 0)
        {
            faling = true;
        }
        else
        {
            faling = false;
        }
    }
    private void FlipBody()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0)
        {
            _renderer.flipX = false;
        }
        else if (horizontalInput < 0)
        {
            _renderer.flipX = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            faling = false;
        }
    }
}