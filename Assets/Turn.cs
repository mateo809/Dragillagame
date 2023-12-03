using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    public LineHelp player;
    public EnemyAI ennemie;

    private void Start()
    {
        int chooser = Random.Range(1, 2);

        if (chooser == 1)
        {
            player.turn = true;
            ennemie.turn = false;
        }
        else if (chooser == 2)
        {
            player.turn = false;
            ennemie.turn = true;
        }
    }

    private void Update()
    {
        if (player.turn && player.haveShoot)
        {
            player.turn = false;
            player.haveShoot = false;
            ennemie.turn = true;
        }
        if (ennemie.turn && ennemie.haveShoot)
        {
            ennemie.turn = false;
            ennemie.haveShoot = false;
            player.turn = true;
        }
    }
}
