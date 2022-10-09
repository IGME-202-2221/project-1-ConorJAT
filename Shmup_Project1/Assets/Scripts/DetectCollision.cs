using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides algorithm for AABB Collision checking.
/// </summary>
public class DetectCollision : MonoBehaviour
{
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
