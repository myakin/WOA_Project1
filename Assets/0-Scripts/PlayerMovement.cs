using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkRate;
    public float runRate;
    public float jumpStrength;
    private Animator animator;
    private float multiplier = 1f;
    private bool isJumping;
    private float translationMultiplier=1;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            multiplier = 2f;
        } else {
            multiplier = 1f;
        }
        
        float hor = Input.GetAxis("Horizontal") * multiplier;
        
        if (hor<0) {
            transform.rotation = Quaternion.Euler(0,180,0);
            translationMultiplier = -1f;
        } else {
            transform.rotation = Quaternion.Euler(0,0,0);
            translationMultiplier = 1f;
        }
        animator.SetFloat("move", hor);
        if (multiplier==1) {
            transform.position += transform.right * (hor * walkRate * translationMultiplier);
        } else {
            transform.position += transform.right * (hor * runRate * translationMultiplier);
        }
        //transform.position = new Vector3(transform.position.x+walkRate, transform.position.y, transform.position.z);
        
        if (!animator.GetAnimatorTransitionInfo(0).anyState && !animator.GetCurrentAnimatorStateInfo(0).IsName("Ellen_Jump_Animation")) {
            isJumping = false;
        }

        if (!isJumping && Input.GetKeyDown(KeyCode.Space)) {
            isJumping = true;
            GetComponent<Rigidbody>().AddForce(transform.up * jumpStrength);
            animator.SetTrigger("jump");
        }
        
        

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
