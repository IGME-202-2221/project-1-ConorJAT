using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BkgdMove : MonoBehaviour
{
    // Speed of dragon
    [SerializeField]
    float speed = 0.5f;

    // Position of dragon
    Vector3 bkgdPos;

    // Direction of dragon
    Vector3 direction = Vector3.left;

    // Velocity of dragon
    Vector3 velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        bkgdPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Velocity = Direction * Speed * DeltaTime
        velocity = direction * speed * Time.deltaTime;

        // Adds velocity to position
        bkgdPos += velocity;

        // "Draws" dragon to said position
        transform.position = bkgdPos;
    }
}
