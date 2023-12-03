using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Bullet2;

public class Bullet2 : MonoBehaviour
{
    Rigidbody2D rb;
    int damageBullet = 40;

    public GameObject explosionPrefab;
    public float explosionDuration = 0.5f;
    PlayerMovement player;
    private void Awake()
    {
        player = GameObject.Find("player1").GetComponent<PlayerMovement>();
    }

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "coucou")
        {
            Debug.Log("plrpferpiverbivbermpinbermpi");
            health.HitPlayer(damageBullet);
            Destroy(gameObject);
        }


        if (collision.gameObject.name == "dirt" || collision.gameObject.name == "grass" || collision.gameObject.name == "stone")
        {
            CreateExplosion();
            player.playerturn = true;
            Destroy(gameObject);

        }



    }

    void CreateExplosion()
    {
        if (explosionPrefab != null)
        {
            


            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.Euler(0, 0, 360));

            Destroy(explosion, explosionDuration);
        }
    }

    void Update()
    {

        float angle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }






}