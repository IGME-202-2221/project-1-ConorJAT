using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AABBCollision(GameObject player, GameObject obstacle)
    {
        SpriteInfo playerSprite = player.GetComponent<SpriteInfo>();
        SpriteInfo collideSprite = obstacle.GetComponent<SpriteInfo>();


        if ((playerSprite.MinX < collideSprite.MaxX &&
            playerSprite.MaxX > collideSprite.MinX) &&
            (playerSprite.MinY < collideSprite.MaxY &&
            playerSprite.MaxY > collideSprite.MinY))
        {
            return true;
        }

        else
        {
            return false;
        }
    }
}
