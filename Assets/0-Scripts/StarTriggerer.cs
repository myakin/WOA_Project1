using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarTriggerer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.tag=="Player") {
            GameController.gameController.IncreaseStarCount();
            Destroy(gameObject);
        }
    }
}
