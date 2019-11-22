using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
    public  GameObject followTarget;
    public float dampeningFactor = 0.01f;
    
    private Vector3 offset;
    
    void Update() {
        Vector3 newCamPos = new Vector3 (
            followTarget.transform.position.x, 
            followTarget.transform.position.y, 
            transform.position.z);
        SmoothMovemet(newCamPos);   
    }
    public void SmoothMovemet(Vector3 aTargetPosition) {
        offset += aTargetPosition;
        Vector3 oldPos = transform.position;
        Vector3 newPos = Vector3.LerpUnclamped(oldPos, aTargetPosition, dampeningFactor);
        transform.position = newPos;
        offset -= newPos - oldPos;
    }
}
