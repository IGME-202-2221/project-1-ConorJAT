using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    List<SpriteRenderer> spawnedGhosts = new List<SpriteRenderer>();

    [SerializeField]
    GameObject ghost;

    [SerializeField]
    BulletManager ghostBullets;

    float totalCamHeight;

    float totalCamWidth;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        totalCamHeight = cam.orthographicSize * 2f;
        totalCamWidth = totalCamHeight * cam.aspect;
    }


    // Update is called once per frame
    void Update()
    {
        // Spawn Ghost Phase
        float spawnChance = Random.Range(0f, 1f);

        // Max of 5 ghosts at a time
        // The more ghosts, the less likely another will spawn
        switch (spawnedGhosts.Count)
        {
            case 0:
                spawnedGhosts.Add(SpawnGhost());
                break;

            case 1:
                if (spawnChance < .9f * Time.deltaTime)
                {
                    spawnedGhosts.Add(SpawnGhost());
                }
                break;

            case 2:
                if (spawnChance < .65f * Time.deltaTime)
                {
                    spawnedGhosts.Add(SpawnGhost());
                }
                break;

            case 3:
                if (spawnChance < .4f * Time.deltaTime)
                {
                    spawnedGhosts.Add(SpawnGhost());
                }
                break;

            case 4:
                if (spawnChance < .2f * Time.deltaTime)
                {
                    spawnedGhosts.Add(SpawnGhost());
                }
                break;

            default:
                break;
        }


        // Clear Ghost Phase
        for (int i = spawnedGhosts.Count - 1; i > -1; i--)
        {
            // Checks if ghost is out of bounds
            if (OutOfBounds(spawnedGhosts[i]))
            {
                // Destroy ghost object
                Destroy(spawnedGhosts[i].gameObject);

                // Remove ghost from list
                spawnedGhosts.RemoveAt(i);
            }
        }


        // Ghost Attack Phase
        for (int i = 0; i < spawnedGhosts.Count; i++)
        {
            float attackChance = Random.Range(0f, 1f);

            if (attackChance < 0.15f * Time.deltaTime)
            {
                ghostBullets.EnemyFire(spawnedGhosts[i]);
            }
        }
    }


    // Spawns new ghost enemies
    SpriteRenderer SpawnGhost()
    {
        SpriteRenderer spawnedGhost;

        Vector3 gPos = new Vector3((totalCamWidth / 2f) + 1f, Random.Range(-totalCamHeight / 2f, totalCamHeight / 2f), 0f);

        spawnedGhost = Instantiate(ghost, gPos, Quaternion.identity).GetComponent<SpriteRenderer>();

        return spawnedGhost;
    }


    // Tests if ghost enemy is out of bounds
    bool OutOfBounds(SpriteRenderer gPos)
    {
        if (gPos.bounds.center.x < (-totalCamWidth / 2f) - 1f ||
            gPos.bounds.center.y > (totalCamHeight / 2f) + 1f ||
            gPos.bounds.center.y < (-totalCamHeight / 2f) - 1f)
        {
            return true;
        }

        return false;
    }
}
