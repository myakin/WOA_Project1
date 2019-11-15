using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteAnimations : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] idleSprites;
    public Sprite[] walkingSprites;
    public float animationSpeed = 0.05f;
    private int indexNo;

    private bool isWalking;


    private void Start() {
        StartCoroutine(AnimateIdle());
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.D)) {
            if (!isWalking) {
                isWalking=true;
                indexNo=0;
                StartCoroutine(AnimateWalk());
            }
                
        }
    }

    public IEnumerator AnimateIdle() {
        spriteRenderer.sprite = idleSprites[indexNo];
        indexNo++;
        if (indexNo==14) 
            indexNo = 0;
        yield return new WaitForSeconds(animationSpeed);
        if (isWalking) {
            StopCoroutine(AnimateIdle());
        } else {
            yield return AnimateIdle();
        }
        
    }

    public IEnumerator AnimateWalk() {
        spriteRenderer.sprite = walkingSprites[indexNo];
        indexNo++;
        if (indexNo==15) 
            indexNo = 0;
        yield return new WaitForSeconds(animationSpeed);
        if(!isWalking) {
            StopCoroutine(AnimateWalk());
        } else {
            yield return AnimateWalk();
        }
        
    }

}
