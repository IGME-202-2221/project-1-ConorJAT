using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    // Speed of ghost
    [SerializeField]
    float speed = 5f;

    // Position of ghost
    Vector3 gPos;

    // Direction of ghost
    Vector3 direction = new Vector3(-1, Random.Range(-0.4f, 0.4f), 0f);

    // Velocity of ghost
    Vector3 velocity = Vector3.zero;

    float totalCamHeight;

    float totalCamWidth;


    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        totalCamHeight = cam.orthographicSize * 2f;
        totalCamWidth = totalCamHeight * cam.aspect;

        gPos = new Vector3(totalCamWidth/2f, Random.Range(-totalCamHeight/2f, totalCamHeight/2f), 0f);

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
