using UnityEngine;

public class AIMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private SpriteRenderer _renderer;
    private Rigidbody2D body;
    private Animator anim;
    private bool moving;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(speed, body.velocity.y);
        FlipBody();

        anim.SetBool("Moving", moving);

        if (body.velocity.x == 0f)
        {
            moving = false;
        }
        else
        {
            moving = true;
        }

    }


    private void FlipBody()
    {
        float direction = body.velocity.x;
        if (direction < 0)
        {
            _renderer.flipX = false;
        }
        else if (direction > 0)
        {
            _renderer.flipX = true;
        }
    }
}

