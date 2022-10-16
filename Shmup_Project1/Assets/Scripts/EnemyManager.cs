using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls Enemy management, including:
///  - How enemies are spawned.
///  - How enemies attack.
///  - How enemies are removed.
/// </summary>
public class EnemyManager : MonoBehaviour
{
    // Ghosts
    List<SpriteRenderer> spawnedGhosts = new List<SpriteRenderer>();

    [SerializeField]
    GameObject ghost;


    // Evil Dragons
    List<SpriteRenderer> spawnedDrakes = new List<SpriteRenderer>();

    [SerializeField]
    GameObject dragon;


    [SerializeField]
    BulletManager bullets;

    float totalCamHeight;

    float totalCamWidth;


    public List<SpriteRenderer> Ghosts
    {
        get { return spawnedGhosts; } 
        set { spawnedGhosts = value; }
    }

    public List<SpriteRenderer> Dragons
    {
        get { return spawnedDrakes; }
        set { spawnedDrakes = value; }
    }


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
        // Spawn Enemy Phase
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


        // Max of 3 evil dragons at a time
        // The more dragons, the less likely another will spawn
        switch (spawnedDrakes.Count)
        {
            case 0:
                if (spawnChance < .6f * Time.deltaTime)
                {
                    spawnedDrakes.Add(SpawnDrake());
                }
                break;

            case 1:
                if (spawnChance < .25f * Time.deltaTime)
                {
                    spawnedDrakes.Add(SpawnDrake());
                }
                break;

            case 2:
                if (spawnChance < .05f * Time.deltaTime)
                {
                    spawnedDrakes.Add(SpawnDrake());
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
                bullets.GhostFire(spawnedGhosts[i]);
            }
        }


        // Evil Dragon Attack Phase
        for (int i = 0; i < spawnedDrakes.Count; i++)
        {
            float attackChance = Random.Range(0f, 1f);

            if (attackChance < 0.15f * Time.deltaTime)
            {
                bullets.DrakeFire(spawnedDrakes[i]);
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


    // Spawns new evil dragon enemies
    SpriteRenderer SpawnDrake()
    {
        SpriteRenderer spawnedDrake;

        Vector3 dPos = new Vector3((totalCamWidth / 2f) + 1f, Random.Range(-totalCamHeight / 2f, totalCamHeight / 2f), 0f);

        spawnedDrake = Instantiate(dragon, dPos, Quaternion.identity).GetComponent<SpriteRenderer>();

        return spawnedDrake;
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
