
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour
{

    public static float healthPlayer = 120f;
    public static float healthAi = 120f;
    public float minhealth = 0.0f;
    public float maxHealth = 120.0f;

    void Start()
    {
        healthPlayer = maxHealth;
        healthAi = maxHealth;
    }

    private void Update()
    {

        if (healthPlayer == minhealth)
        {
            SceneManager.LoadScene(4);

        }
        else if (healthAi == minhealth)
        {
           
            SceneManager.LoadScene("win");
        }




    }

     

    public static void HitPlayer(int damageAmount)
    {
        healthPlayer -= damageAmount;
    }
    public static void HitAI(int damageAmount)
    {
        healthAi -= damageAmount;
    }


}
