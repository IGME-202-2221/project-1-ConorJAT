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
    EnemyManager myEnemies;

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

        // Player v. Blue Fire
        for (int i = myBullets.EvilFire.Count - 1; i > -1; i--)
        {
            if (Collide.AABBCollision(player, myBullets.EvilFire[i].gameObject))
            {
                Destroy(myBullets.EvilFire[i].gameObject);

                myBullets.EvilFire.RemoveAt(i);

                gameStats.TakeDamage(20);

                health.text = "Health: " + gameStats.Health.ToString() + "%";
                lives.text = "Lives: " + gameStats.Lives.ToString() + "x";
            }
        }

        // Fire v. Ghosts
        for (int i = myEnemies.Ghosts.Count - 1; i > -1; i--)
        {
            for (int j = myBullets.Fireballs.Count - 1; j > -1; j--)
            {
                if (Collide.AABBCollision(myBullets.Fireballs[j].gameObject, myEnemies.Ghosts[i].gameObject))
                {
                    Destroy(myBullets.Fireballs[j].gameObject);
                    Destroy(myEnemies.Ghosts[i].gameObject);

                    myBullets.Fireballs.RemoveAt(j);
                    myEnemies.Ghosts.RemoveAt(i);

                    gameStats.Score += 30;

                    score.text = "Score: " + gameStats.Score.ToString();
                }
            }
        }

        // Fire v. Evil Dragons
        for (int i = myEnemies.Dragons.Count - 1; i > -1; i--)
        {
            for (int j = myBullets.Fireballs.Count - 1; j > -1; j--)
            {
                if (Collide.AABBCollision(myBullets.Fireballs[j].gameObject, myEnemies.Dragons[i].gameObject))
                {
                    Destroy(myBullets.Fireballs[j].gameObject);
                    Destroy(myEnemies.Dragons[i].gameObject);

                    myBullets.Fireballs.RemoveAt(j);
                    myEnemies.Dragons.RemoveAt(i);

                    gameStats.Score += 60;

                    score.text = "Score: " + gameStats.Score.ToString();
                }
            }
        }

        // Player v. Ghosts
        for (int i = myEnemies.Ghosts.Count - 1; i > -1; i--)
        {
            if (Collide.AABBCollision(player, myEnemies.Ghosts[i].gameObject))
            {
                Destroy(myEnemies.Ghosts[i].gameObject);

                myEnemies.Ghosts.RemoveAt(i);

                gameStats.TakeDamage(20);

                health.text = "Health: " + gameStats.Health.ToString() + "%";
                lives.text = "Lives: " + gameStats.Lives.ToString() + "x";
            }
        }

        // Player v. Evil Dragons
        for (int i = myEnemies.Dragons.Count - 1; i > -1; i--)
        {
            if (Collide.AABBCollision(player, myEnemies.Dragons[i].gameObject))
            {
                Destroy(myEnemies.Dragons[i].gameObject);

                myEnemies.Dragons.RemoveAt(i);

                gameStats.TakeDamage(40);

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
