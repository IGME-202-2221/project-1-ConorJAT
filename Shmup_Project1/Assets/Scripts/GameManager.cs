using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    BulletManager removeBullets;

    [SerializeField]
    EnemyManager removeEnemies;

    [SerializeField]
    GameObject removePlayer;

    [SerializeField]
    GameObject turnOffEnemies;

    [SerializeField]
    GameObject hudPanel;

    [SerializeField]
    GameObject goPanel;

    [SerializeField]
    Text finalScore;


    int playerScore;
    
    int playerHealth;

    int playerLives;
    

    public int Score
    {
        get { return playerScore; }
        set { playerScore = value; }
    }

    public int Health
    {
        get { return playerHealth; }
        set { playerHealth = value; }
    }

    public int Lives
    {
        get { return playerLives; }
        set { playerLives = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        playerScore = 0;

        playerHealth = 100;

        playerLives = 3;

        goPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(playerLives == 0)
        {
            GameOver();
        }
    }

    public void TakeDamage(int damage)
    {
        if (playerLives != 0)
        {
            if (playerHealth <= damage)
            {
                playerLives--;
                playerHealth = 100;
            }

            else if (playerHealth > damage)
            {
                playerHealth -= damage;
            }
        }
    }

    void GameOver()
    {
        // Turn off enemy manager
        turnOffEnemies.SetActive(false);
        
        // Remove the player
        Destroy(removePlayer);

        // Remove all enemies
        for (int i = removeEnemies.Ghosts.Count - 1; i > -1; i--)
        {
            Destroy(removeEnemies.Ghosts[i].gameObject);
            removeEnemies.Ghosts.RemoveAt(i);
        }

        for (int i = removeEnemies.Dragons.Count - 1; i > -1; i--)
        {
            Destroy(removeEnemies.Dragons[i].gameObject);
            removeEnemies.Dragons.RemoveAt(i);
        }

        // Remove all bullets
        for (int i = removeBullets.Fireballs.Count - 1; i > -1; i--)
        {
            Destroy(removeBullets.Fireballs[i].gameObject);
            removeBullets.Fireballs.RemoveAt(i);
        }

        for (int i = removeBullets.Skulls.Count - 1; i > -1; i--)
        {
            Destroy(removeBullets.Skulls[i].gameObject);
            removeBullets.Skulls.RemoveAt(i);
        }

        for (int i = removeBullets.EvilFire.Count - 1; i > -1; i--)
        {
            Destroy(removeBullets.EvilFire[i].gameObject);
            removeBullets.EvilFire.RemoveAt(i);
        }

        // Turn off HUD
        hudPanel.SetActive(false);

        // Turn on Game Over
        goPanel.SetActive(true);

        // Display final score
        finalScore.text = "Final Score: " + playerScore.ToString();

    }
}
