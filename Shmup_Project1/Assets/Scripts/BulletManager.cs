using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletManager : MonoBehaviour
{
    // Player Bullets (Fireballs)
    List<SpriteRenderer> spawnedFire = new List<SpriteRenderer>();

    [SerializeField]
    GameObject fireball;

    [SerializeField]
    GameObject player;

    SpriteInfo dragPos;


    // Enemy Bullets (Skulls)
    List<SpriteRenderer> spawnedSkulls = new List<SpriteRenderer>();

    [SerializeField]
    GameObject skull;


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
        // Destroy and remove any out of bound fireballs
        for (int i = spawnedFire.Count - 1; i > -1; i--)
        {
            // Checks if fireball is out of bounds
            if (spawnedFire[i].bounds.center.x > totalCamWidth / 2f)
            {
                // Destroy fireball object
                Destroy(spawnedFire[i].gameObject);

                // Remove fireball from list
                spawnedFire.RemoveAt(i);
            }
        }


        // Destroy and remove any out of bound skulls
        for (int i = spawnedSkulls.Count - 1; i > -1; i--)
        {
            // Checks if skull is out of bounds
            if (spawnedSkulls[i].bounds.center.x < -totalCamWidth / 2f)
            {
                // Destroy skull object
                Destroy(spawnedSkulls[i].gameObject);

                // Remove skull from list
                spawnedSkulls.RemoveAt(i);
            }
        }
    }


    // Player shoots a fireball
    public void Fire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SpriteRenderer newFireball;

            Vector3 firePos = Vector3.zero;

            dragPos = player.GetComponent<SpriteInfo>();
            firePos = new Vector3(dragPos.Center.x + dragPos.RadiusX,
                                  dragPos.Center.y, 0f);

            newFireball = Instantiate(fireball, firePos, Quaternion.identity).GetComponent<SpriteRenderer>();

            spawnedFire.Add(newFireball);
        }
    }


    public void EnemyFire(SpriteRenderer ghost)
    {
        SpriteRenderer newSkull;

        Vector3 skullPos = new Vector3(ghost.bounds.center.x - ghost.bounds.extents.x,
                                       ghost.bounds.center.y, 0f);

        newSkull = Instantiate(skull, skullPos, Quaternion.identity).GetComponent<SpriteRenderer>();

        spawnedSkulls.Add(newSkull);
    }
}
