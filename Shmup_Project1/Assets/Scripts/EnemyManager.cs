using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    List<SpriteRenderer> spawnedGhosts = new List<SpriteRenderer>();

    [SerializeField]
    GameObject ghost;

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

        // Only 5 ghosts allowed on screen at a time
        if (spawnedGhosts.Count < 5)
        {
            // Adds spawned ghost to list
            spawnedGhosts.Add(SpawnGhost());
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
