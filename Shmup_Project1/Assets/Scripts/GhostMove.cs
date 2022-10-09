using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    // Speed of ghost
    [SerializeField]
    float speed = 2f;

    // Position of ghost
    Vector3 gPos;

    // Direction of ghost
    Vector3 direction;

    // Velocity of ghost
    Vector3 velocity = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        direction = new Vector3(-1f, Random.Range(-0.30f, 0.30f), 0f);
        
        gPos = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        // Velocity = Direction * Speed * DeltaTime
        velocity = direction * speed * Time.deltaTime;

        // Adds velocity to position
        gPos += velocity;

        // "Draws" ghost to said position
        transform.position = gPos;
    }
}
