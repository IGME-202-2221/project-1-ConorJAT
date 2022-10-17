using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BkgdManager : MonoBehaviour
{
    List<SpriteRenderer> envir = new List<SpriteRenderer>();
    
    [SerializeField]
    GameObject bckgd;

    float totalCamHeight;

    float totalCamWidth;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = Camera.main;
        totalCamHeight = cam.orthographicSize * 2f;
        totalCamWidth = totalCamHeight * cam.aspect;


        SpriteRenderer newBckgd;
        
        Vector3 newPos = new Vector3(0f, 0f, 20f);
        newBckgd = Instantiate(bckgd, newPos, Quaternion.identity).GetComponent<SpriteRenderer>();
        envir.Add(newBckgd); 
    }

    // Update is called once per frame
    void Update()
    {
        if (envir.Count <= 1)
        {
            SpriteRenderer newBckgd2;
            
            Vector3 newPos2 = new Vector3(envir[0].gameObject.GetComponent<SpriteInfo>().Center.x +
                             (2f * envir[0].gameObject.GetComponent<SpriteInfo>().RadiusX) - 1f, 0f, 20f);
            newBckgd2 = Instantiate(bckgd, newPos2, Quaternion.identity).GetComponent<SpriteRenderer>();
            envir.Add(newBckgd2);
        }
        

        if ((envir[0].gameObject.GetComponent<SpriteInfo>().Center.x + 
             envir[0].gameObject.GetComponent<SpriteInfo>().RadiusX) <= (-totalCamWidth / 2f))
        {
            envir[0] = envir[1];

            envir[1] = Instantiate(bckgd,
                                   new Vector3(envir[0].gameObject.GetComponent<SpriteInfo>().Center.x +
                                              (2f * envir[0].gameObject.GetComponent<SpriteInfo>().RadiusX), 0f, 20f),
                                   Quaternion.identity).GetComponent<SpriteRenderer>();
        }
    }
}
