using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DragonMove : MonoBehaviour
{
    // Speed of dragon
    [SerializeField]
    float speed = 1f;

    // Position of dragon
    Vector3 dragPos = Vector3.zero;

    // Direction of dragon
    Vector3 direction = Vector3.zero;

    // Velocity of dragon
    Vector3 velocity = Vector3.zero;

    float totalCamHeight;

    float totalCamWidth;


    // Start is called before the first frame update
    void Start()
    {
        dragPos = transform.position;

        Camera cam = Camera.main;
        totalCamHeight = cam.orthographicSize * 2f;
        totalCamWidth = totalCamHeight * cam.aspect;
    }


    // Update is called once per frame
    void Update()
    {
        // Velocity = Direction * Speed * DeltaTime
        velocity = direction * speed * Time.deltaTime;

        // Adds velocity to position
        dragPos += velocity;

        // Prevents movement outside x border
        if (dragPos.x > totalCamWidth / 2f)
        {
            dragPos = new Vector3(totalCamWidth / 2f, dragPos.y, 0);
        }
        else if (dragPos.x < -totalCamWidth / 2f)
        {
            dragPos = new Vector3(-totalCamWidth / 2f, dragPos.y, 0);
        }

        // Prevents movement outside y border
        if (dragPos.y > totalCamHeight / 2f)
        {
            dragPos = new Vector3(dragPos.x, totalCamHeight / 2f, 0);
        }
        else if (dragPos.y < -totalCamHeight / 2f)
        {
            dragPos = new Vector3(dragPos.x, -totalCamHeight / 2f, 0);
        }

        // "Draws" dragon to said position
        transform.position = dragPos;
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        direction = context.ReadValue<Vector2>();
    }
}
