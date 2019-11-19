using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelReloader : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            GameController.gameController.ReduceLives(1);
            if (GameController.gameController.GetNumberOfLives()>0) {
                GameController.gameController.ReLoadCurrentScene();
            } else {
                Destroy(other.GetComponent<Rigidbody>());
            }
        }
    }
}
