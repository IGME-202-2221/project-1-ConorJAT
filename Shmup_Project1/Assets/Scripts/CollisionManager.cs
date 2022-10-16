using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Controls all collision scenarios that may occur in game:
///  - Player touching skull bullet.
///  - Player touching an enemy.
///  - Fireball touching skull bullet.
///  - Fireball touching an enemy.
/// </summary>
public class CollisionManager : MonoBehaviour
{
    [SerializeField]
    BulletManager myBullets;

    [SerializeField]
    EnemyManager myGhosts;

    [SerializeField]
    DetectCollision Collide;

    [SerializeField]
    GameManager gameStats;

    [SerializeField]
    GameObject player;


    [SerializeField]
    Text score;

    [SerializeField]
    Text health;

    [SerializeField]
    Text lives;


    // Update is called once per frame
    void Update()
    {
        // Player v. Skulls
        for (int i = myBullets.Skulls.Count - 1; i > -1; i--)
        {
            if (Collide.AABBCollision(player, myBullets.Skulls[i].gameObject))
            {
                Destroy(myBullets.Skulls[i].gameObject);

                myBullets.Skulls.RemoveAt(i);

                gameStats.TakeDamage(10);

                health.text = "Health: " + gameStats.Health.ToString() + "%";
                lives.text = "Lives: " + gameStats.Lives.ToString() + "x";
            }
        }

        // Fire v. Ghosts
        for (int i = myGhosts.Ghosts.Count - 1; i > -1; i--)
        {
            for (int j = myBullets.Fireballs.Count - 1; j > -1; j--)
            {
                if (Collide.AABBCollision(myBullets.Fireballs[j].gameObject, myGhosts.Ghosts[i].gameObject))
                {
                    Destroy(myBullets.Fireballs[j].gameObject);
                    Destroy(myGhosts.Ghosts[i].gameObject);

                    myBullets.Fireballs.RemoveAt(j);
                    myGhosts.Ghosts.RemoveAt(i);

                    gameStats.Score += 30;

                    score.text = "Score: " + gameStats.Score.ToString();
                }
            }
        }

        // Player v. Ghosts
        for (int i = myGhosts.Ghosts.Count - 1; i > -1; i--)
        {
            if (Collide.AABBCollision(player, myGhosts.Ghosts[i].gameObject))
            {
                Destroy(myGhosts.Ghosts[i].gameObject);

                myGhosts.Ghosts.RemoveAt(i);

                gameStats.TakeDamage(10);

                health.text = "Health: " + gameStats.Health.ToString() + "%";
                lives.text = "Lives: " + gameStats.Lives.ToString() + "x";
            }
        }

        // Fire v. Skulls
        for (int i = myBullets.Skulls.Count - 1; i > -1; i--)
        {
            for (int j = myBullets.Fireballs.Count - 1; j > -1; j--)
            {
                if (Collide.AABBCollision(myBullets.Fireballs[j].gameObject, myBullets.Skulls[i].gameObject))
                {
                    Destroy(myBullets.Fireballs[j].gameObject);
                    Destroy(myBullets.Skulls[i].gameObject);

                    myBullets.Fireballs.RemoveAt(j);
                    myBullets.Skulls.RemoveAt(i);
                }
            }
        }
    }
}
