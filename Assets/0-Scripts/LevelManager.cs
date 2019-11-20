using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.tag=="Player") {
            GameObject myUIManagerGameObject = GameObject.FindGameObjectWithTag("UserInterface");
            myUIManagerGameObject.GetComponent<UIController>().ShowEndLevelPanel();
        }
    }
}
