using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteInfo : MonoBehaviour
{
    private SpriteRenderer mySprite;
    

    // Sprite Size
    public Vector3 Size
    {
        get { return mySprite.bounds.size; }
    }


    // AABB Collision Box Related
    public float MinX
    {
        get { return mySprite.bounds.min.x; }
    }

    public float MinY
    {
        get { return mySprite.bounds.min.y; }
    }

    public float MaxX
    {
        get { return mySprite.bounds.max.x; }
    }

    public float MaxY
    {
        get { return mySprite.bounds.max.y; }
    }


    // Circle Collision Box Related
    public Vector3 Center
    {
        get { return mySprite.bounds.center; }
    }

    public float RadiusY
    {
        get { return mySprite.bounds.extents.y; }
    }

    public float RadiusX
    {
        get { return mySprite.bounds.extents.x; }
    }


    // Sprite Color
    public Color Color
    {
        get { return mySprite.color; }
        set { mySprite.color = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        mySprite = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update() {}
}
