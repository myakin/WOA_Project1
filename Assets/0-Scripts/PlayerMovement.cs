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
    private float preJumpMultiplier;

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

        if (isJumping)
            translationMultiplier = preJumpMultiplier;

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
            transform.SetParent(null);
            preJumpMultiplier=translationMultiplier;
            GetComponent<Rigidbody>().AddForce(transform.up * jumpStrength);
            animator.SetTrigger("jump");
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "MobilePlatform") {
            transform.SetParent(other.transform);
        } else {
            transform.SetParent(null);
        }
    }

}
