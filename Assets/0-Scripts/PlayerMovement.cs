using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        float hor = Input.GetAxis("Horizontal");
        if (hor<0) {
            transform.rotation = Quaternion.Euler(0,180,0);
        } else {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        animator.SetFloat("move", hor);
        

        // muratyakin@muratyakin.com

        // if (Input.GetKey(KeyCode.D)) {
        //     animator.SetBool("isWalking", true);
        // }
        // if (Input.GetKey(KeyCode.A)) {
        //     animator.SetBool("isWalkingLeft", true);
        //     transform.rotation = Quaternion.Euler(0,180,0);
        // }
        // if (Input.GetKeyUp(KeyCode.D)) {
        //     animator.SetBool("isWalking", false);
        // }
        // if (Input.GetKeyUp(KeyCode.A)) {
        //     animator.SetBool("isWalkingLeft", false);
        //      transform.rotation = Quaternion.Euler(0,0,0);
        // }
    }

}
