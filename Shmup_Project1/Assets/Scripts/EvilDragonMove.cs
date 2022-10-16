using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilDragonMove : MonoBehaviour
{
    // Speed of dragon
    [SerializeField]
    float speed = 1f;

    // Position of dragon
    Vector3 dPos;

    // Direction of dragon
    Vector3 direction;

    // Velocity of dragon
    Vector3 velocity = Vector3.zero;

    float stopPoint;


    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(-1f, 0f, 0f);

        stopPoint = Random.Range(5f, 7f);

        dPos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (dPos.x > stopPoint)
        {
            // Velocity = Direction * Speed * DeltaTime
            velocity = direction * speed * Time.deltaTime;

            // Adds velocity to position
            dPos += velocity;

            // "Draws" dragon to said position
            transform.position = dPos;
        }
    }
}
