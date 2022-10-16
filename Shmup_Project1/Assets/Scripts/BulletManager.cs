using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Controls bullet management, including:
///  - Player fireball controls.
///  - Player fireball spawn and deletion.
///  - Enemy skull spawn and deletion.
/// </summary>
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

    // Enemy Bullets (Blue Fire)
    List<SpriteRenderer> spawnedEvilFire = new List<SpriteRenderer>();

    [SerializeField]
    GameObject evilFireball;

    // Screen Borders
    float totalCamHeight;

    float totalCamWidth;


    // Properties
    public List<SpriteRenderer> Fireballs
    {
        get { return spawnedFire; }
        set { spawnedFire = value; }
    }

    public List<SpriteRenderer> Skulls
    {
        get { return spawnedSkulls; }
        set { spawnedSkulls = value; }
    }

    public List<SpriteRenderer> EvilFire
    {
        get { return spawnedEvilFire; }
        set { spawnedEvilFire = value; }
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


        // Destroy and remove any out of bound evil fireballs
        for (int i = spawnedEvilFire.Count - 1; i > -1; i--)
        {
            // Checks if skull is out of bounds
            if (spawnedEvilFire[i].bounds.center.x < -totalCamWidth / 2f)
            {
                // Destroy skull object
                Destroy(spawnedEvilFire[i].gameObject);

                // Remove skull from list
                spawnedEvilFire.RemoveAt(i);
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


    // Ghost enemy shoots a skull
    public void GhostFire(SpriteRenderer ghost)
    {
        SpriteRenderer newSkull;

        Vector3 skullPos = new Vector3(ghost.bounds.center.x - ghost.bounds.extents.x,
                                       ghost.bounds.center.y, 0f);

        newSkull = Instantiate(skull, skullPos, Quaternion.identity).GetComponent<SpriteRenderer>();

        spawnedSkulls.Add(newSkull);
    }


    // Evil Dragon enemy shoots a fireball trio
    public void DrakeFire(SpriteRenderer drake)
    {
        SpriteRenderer newFire1;
        SpriteRenderer newFire2;
        SpriteRenderer newFire3;

        Vector3 firePos = new Vector3(drake.bounds.center.x - drake.bounds.extents.x,
                                      drake.bounds.center.y, 0f);

        newFire1 = Instantiate(evilFireball, firePos, Quaternion.Euler(0, 0, -15)).GetComponent<SpriteRenderer>();
        newFire2 = Instantiate(evilFireball, firePos, Quaternion.identity).GetComponent<SpriteRenderer>();
        newFire3 = Instantiate(evilFireball, firePos, Quaternion.Euler(0, 0, 15)).GetComponent<SpriteRenderer>();

        newFire1.gameObject.GetComponent<EvilFireMove>().Direction = new Vector3(-1f, 0.268f, 0f);
        newFire2.gameObject.GetComponent<EvilFireMove>().Direction = Vector3.left;
        newFire3.gameObject.GetComponent<EvilFireMove>().Direction = new Vector3(-1f, -0.268f, 0f);

        spawnedEvilFire.Add(newFire1);
        spawnedEvilFire.Add(newFire2);
        spawnedEvilFire.Add(newFire3);
    }
}
