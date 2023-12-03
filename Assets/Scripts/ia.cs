using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float minSpeed = 5f;
    public float maxSpeed = 10f;
    public float fireRate = 20.0f;
    public bool shoot;
    public bool haveShoot;
    public bool turn;
    public float time = 5f;


    void LaunchProjectile()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        Vector2 playerPosition = FindObjectOfType<PlayerMovement>().transform.position;

        Vector2 playerDirection = playerPosition - (Vector2)transform.position;

        float angle = Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;

        angle += Random.Range(-60f, -40f);

        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        float speed = Random.Range(minSpeed, maxSpeed);
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.right * speed;

       
    }
    void Update()
    {
        
        

        if (turn && !shoot && !haveShoot)
        {
            LaunchProjectile();
            shoot = true;
        }
        if (shoot)
        {
            time -= Time.deltaTime;
            if(time <= 0)
            {
                haveShoot = true;
                shoot = false;
                time = 5f;
            }

        }
    }





}