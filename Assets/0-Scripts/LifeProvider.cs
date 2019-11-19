using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeProvider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.tag=="Player") {
            GameController.gameController.IncreaseLives(1);
            Destroy(gameObject);
        }
    }
}
