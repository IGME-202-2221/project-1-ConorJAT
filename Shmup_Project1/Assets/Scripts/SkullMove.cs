using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullMove : MonoBehaviour
{
    // Speed of skull projectile
    [SerializeField]
    float speed = 10f;

    // Position of skull projectile
    Vector3 skullPos;

    // Direction of skull projectile
    Vector3 direction = new Vector3(-1f, 0f, 0f);

    // Velocity of skull projectile
    Vector3 velocity = Vector3.zero;

    [SerializeField]
    GameObject ghost;

    SpriteInfo gPos;


    // Start is called before the first frame update
    void Start()
    {
        gPos = ghost.GetComponent<SpriteInfo>();

        skullPos = new Vector3(gPos.Center.x - gPos.RadiusX,
                               gPos.Center.y, 0);

        skullPos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        // Velocity = Direction * Speed * DeltaTime
        velocity = direction * speed * Time.deltaTime;

        // Adds velocity to position
        skullPos += velocity;

        // "Draws" skull projectile to said position
        transform.position = skullPos;
    }
}
