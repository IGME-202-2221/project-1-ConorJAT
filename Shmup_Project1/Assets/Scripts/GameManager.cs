using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
