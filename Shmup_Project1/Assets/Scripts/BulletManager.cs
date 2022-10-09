using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BulletManager : MonoBehaviour
{
    List<SpriteRenderer> spawnedFire = new List<SpriteRenderer>();

    [SerializeField]
    GameObject playerFire;

    [SerializeField]
    GameObject player;

    SpriteInfo dragPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }


    // Player shoots a fireball
    public void Fire(InputAction.CallbackContext context)
    {
        SpriteRenderer newFireball;

        Vector3 firePos = Vector3.zero;

        dragPos = player.GetComponent<SpriteInfo>();
        firePos = new Vector3(dragPos.Center.x + dragPos.RadiusX,
                              dragPos.Center.y, 0);

        newFireball = Instantiate(playerFire, firePos, Quaternion.identity).GetComponent<SpriteRenderer>();

        spawnedFire.Add(newFireball);
    }
}
