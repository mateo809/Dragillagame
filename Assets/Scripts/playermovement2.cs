using UnityEngine;
using System.Collections;

public class PlayerMovementennemi : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float speed = 5f;
    public float jumpSpeed = 10f;
    public float jumpCooldown = 1.0f;
    public Sprite jumpSprite;
    public Sprite originalSprite;

    private float lastJumpTime;
    private bool isFacingRight = true;
    private bool isJumping = false;
    private bool isMoving = false;
    private Vector2 targetPosition;

    PlayerMovement player;

    void Awake()
    {
        player = GameObject.Find("player1").GetComponent<PlayerMovement>();
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        lastJumpTime = -jumpCooldown;
        Jump();
      
    }

    void Update()
    {
        if (player.playerturn == false)
        {
            if (!isJumping && !isMoving)
            {
                MoveRandomly();
            }

            if (CanJump())
            {
                Jump();
            }

            UpdateSprite();
        }
    }

    void MoveRandomly()
    {
        float h = Random.Range(-1f, 1f) * speed;
        rb2D.velocity = new Vector2(h, rb2D.velocity.y);

        if (h < 0 && isFacingRight)
        {
            Flip();
        }
        else if (h > 0 && !isFacingRight)
        {
            Flip();
        }
    }

    void SetRandomTargetPosition()
    {
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);
        targetPosition = new Vector2(randomX, randomY);
    }

    void Jump()
    {
        rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);
        lastJumpTime = Time.time;
        isJumping = true;
    }

    void UpdateSprite()
    {
        if (isJumping)
        {
            GetComponent<SpriteRenderer>().sprite = jumpSprite;
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = originalSprite;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            GetComponent<SpriteRenderer>().sprite = originalSprite;
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    bool CanJump()
    {
        return Time.time - lastJumpTime > jumpCooldown;
    }
}
