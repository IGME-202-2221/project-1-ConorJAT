using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilFireMove : MonoBehaviour
{
    // Speed of fireball projectile
    [SerializeField]
    float speed = 10f;

    // Position of fireball projectile
    Vector3 fPos;

    // Direction of fireball projectile
    Vector3 direction = Vector3.zero;

    // Velocity of fireball projectile
    Vector3 velocity = Vector3.zero;

    // Rotation of fireball projectile
    Quaternion rotation = Quaternion.identity;


    public Vector3 Direction
    {
        get { return direction; }
        set { direction = value; }
    }

    public Quaternion Rotate
    {
        get { return rotation; }
        set { rotation = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        fPos = transform.position;

        rotation = transform.rotation;
    }


    // Update is called once per frame
    void Update()
    {
        // Velocity = Direction * Speed * DeltaTime
        velocity = direction * speed * Time.deltaTime;

        // Adds velocity to position
        fPos += velocity;

        // "Draws" skull projectile to said position
        transform.position = fPos;
    }
}
