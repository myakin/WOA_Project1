using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class PlayerMovement : MonoBehaviour
{
    public float walkRate;
    public float runRate;
    public float jumpStrength;
    public GameObject cameraFollowDummy;
    private Vector3 cameraFollowDummyOriginalPos;
    private bool byPass;
    private Animator animator;
    private float multiplier = 1f;
    private bool isJumping;
    private float translationMultiplier=1;
    private float preJumpMultiplier;


    private void Start() {
        animator = GetComponent<Animator>();
        cameraFollowDummyOriginalPos = cameraFollowDummy.transform.localPosition;
    }

    private void Update() {
        if (!byPass) {

            // get input
            // float hor = Input.GetAxis("Horizontal");
            // bool shouldRun = Input.GetKey(KeyCode.LeftShift);
            // bool shouldJump = Input.GetKeyDown(KeyCode.Space);

            float hor = CrossPlatformInputManager.GetAxis("Horizontal");
            float ver = CrossPlatformInputManager.GetAxis("Vertical");
            bool shouldJump = CrossPlatformInputManager.GetButton("Jump");
            
            
            
            bool shouldRun = false;
            if (ver>0)
                shouldRun = true;
            
            //Debug.Log("shouldRun="+shouldRun + " ver="+ver+" hor="+hor);

            // do things with input
            if (shouldRun) {
                multiplier = 2f;
            } else {
                multiplier = 1f;
            }
            hor *= multiplier;
             
            if (hor<0) {
                //transform.rotation = Quaternion.Euler(0,180,0);
                GetComponent<SpriteRenderer>().flipX=true;
                //translationMultiplier = -1f;
                cameraFollowDummy.transform.localPosition = new Vector3(
                    -cameraFollowDummyOriginalPos.x,
                    cameraFollowDummyOriginalPos.y,
                    cameraFollowDummyOriginalPos.z
                );
            } else  if (hor>0) {
                //transform.rotation = Quaternion.Euler(0,0,0);
                GetComponent<SpriteRenderer>().flipX=false;
                translationMultiplier = 1f;
                cameraFollowDummy.transform.localPosition = cameraFollowDummyOriginalPos;
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

            if (!isJumping && shouldJump) {
                isJumping = true;
                transform.SetParent(null);
                preJumpMultiplier=translationMultiplier;
                GetComponent<Rigidbody>().AddForce(transform.up * jumpStrength);
                animator.SetTrigger("jump");
            }
        }
        
    }

    private void OnCollisionEnter(Collision other) {
        if (other.collider.tag == "MobilePlatform") {
            transform.SetParent(other.transform);
        } else {
            transform.SetParent(null);
        }
    }

    public void DisablePlayerMovement() {
        byPass = true;
    }
    public void EnablePlayerMovement() {
        byPass = false;
    }

}
