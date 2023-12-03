using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float Speed = 5;
    public float jumpSpeed;
    public float jumpCooldown = 1.0f;
    public Sprite jumpSprite;
    public Sprite originalSprite;
    private float lastJumpTime;
    private bool isFacingRight = true;
    private bool isJumping = false;
    public bool playerturn = true;
    bool shoot;
    public int playerLives = 1;
    


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        lastJumpTime = -jumpCooldown;

    }

    void Update()
    {
        if (playerturn  && !shoot )
        {
            float h = Input.GetAxis("Horizontal") * Speed;
            rb2D.velocity = new Vector2(h, rb2D.velocity.y);

            if (h > 0)
            {
                if (!isFacingRight)
                {
                    Flip();
                }
            }
            else if (h < 0)
            {
                if (isFacingRight)
                {
                    Flip();
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && CanJump())
            {
                Jump();
            }
        }


        UpdateSprite();
    }

    void Jump()
    {
        rb2D.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse);
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
        if (collision.gameObject.name == "grass")
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