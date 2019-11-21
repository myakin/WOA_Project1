using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollowCamera : MonoBehaviour
{
    
    private GameObject cam;

    void Start()
    {
        cam = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
                                            cam.transform.position.x,
                                            cam.transform.position.y,
                                            transform.position.z
                                        );
          
    }
}
