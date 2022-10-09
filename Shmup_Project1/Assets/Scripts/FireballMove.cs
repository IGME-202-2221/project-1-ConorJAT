using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls movement for fireball projectiles.
/// </summary>
public class FireballMove : MonoBehaviour
{
    // Speed of fireball
    [SerializeField]
    float speed = 10f;

    // Position of fireball
    Vector3 firePos;

    // Direction of fireball
    Vector3 direction = new Vector3(1f, 0f, 0f);

    // Velocity of fireball
    Vector3 velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        firePos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        // Velocity = Direction * Speed * DeltaTime
        velocity = direction * speed * Time.deltaTime;

        // Adds velocity to position
        firePos += velocity;

        // "Draws" fireball to said position
        transform.position = firePos;
    }
}
