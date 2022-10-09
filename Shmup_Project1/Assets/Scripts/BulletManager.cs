using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletManager : MonoBehaviour
{
    List<SpriteRenderer> spawnedFire = new List<SpriteRenderer>();

    [SerializeField]
    GameObject fireball;

    [SerializeField]
    GameObject player;

    SpriteInfo dragPos;

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
                              dragPos.Center.y, 0);

            newFireball = Instantiate(fireball, firePos, Quaternion.identity).GetComponent<SpriteRenderer>();

            spawnedFire.Add(newFireball);
        }
    }
}
