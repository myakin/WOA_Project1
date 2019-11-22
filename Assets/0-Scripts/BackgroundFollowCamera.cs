using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundFollowCamera : MonoBehaviour
{
    
    private GameObject cam;

    public float dampeningFactor = 0.01f;
    
    private Vector3 offset;

    void Start()
    {
        cam = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 bgPos = new Vector3(
                                            cam.transform.position.x,
                                            cam.transform.position.y,
                                            transform.position.z
                                        );
        SmoothMovemet(bgPos);                              
          
    }
    public void SmoothMovemet(Vector3 aTargetPosition) {
        offset += aTargetPosition;
        Vector3 oldPos = transform.position;
        Vector3 newPos = Vector3.LerpUnclamped(oldPos, aTargetPosition, dampeningFactor);
        transform.position = newPos;
        offset -= newPos - oldPos;
    }
}
