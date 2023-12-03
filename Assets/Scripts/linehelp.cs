using UnityEngine;

public class LineHelp : MonoBehaviour
{

    [SerializeField] Transform projectilesPrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] LineRenderer lineRender;

    [SerializeField] float launcheForce = 1.5f;
    [SerializeField] float trajectoryTimestep = 0.05f;
    [SerializeField] int trajectoryCount = 15;

    Vector2 velocity, startMousePos, currentPosMouse;
    public bool shoot;
    float time = 5;
    public bool turn;

    EnemyAI ennemie;

    public bool haveShoot;

    PlayerMovement player;
    public void Awake()
    {
        player = GameObject.Find("player1").GetComponent<PlayerMovement>();
    }

  

    public void Update()
    {
        if (turn && !shoot && !haveShoot)
        {

            if (Input.GetMouseButtonDown(0))
            {
                startMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.GetMouseButton(0))
            {
                currentPosMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                velocity = (startMousePos - currentPosMouse) * launcheForce;
                DrawTrajectory();
            }

            if (Input.GetMouseButtonUp(0))
            {
                FireProjectile();
                clearTrajectory();
                shoot = true;
                turn = true;
            }
        }

        if (shoot)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                shoot = false;
                time = 5;
                haveShoot = true;
                
            }
        }
    }

    void DrawTrajectory()
    {
        Vector3[] positions = new Vector3[trajectoryCount];
        for (int i = 0; i < trajectoryCount; i++)
        {
            float t = i * trajectoryTimestep;
            Vector3 pos = (Vector2)spawnPoint.position + velocity * t + 0.5f * Physics2D.gravity * t * t;
            positions[i] = pos;
        }

        lineRender.positionCount = trajectoryCount;
        lineRender.SetPositions(positions);
    }

    void RotateLauncher()
    {
        float angle = Mathf.Atan2(velocity.x, velocity.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    public void FireProjectile()
    {

        Transform pr = Instantiate(projectilesPrefab, spawnPoint.position, Quaternion.identity); 
        pr.GetComponent<Rigidbody2D>().velocity = velocity;
    }

    void clearTrajectory()
    {
        lineRender.positionCount = 0;
    }
}