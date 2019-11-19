using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdManager : MonoBehaviour
{
    public string id;

    private void Start() {
        GenerateId();
        if (GameController.gameController.CheckItemIdInCollectedItemsList(id)) {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag=="Player") {
            GameController.gameController.AddToItemsCollected(id);
        }
    }

    private void GenerateId() {
        string nameOfThis = gameObject.name;
        string posString = transform.position.ToString();
        id = nameOfThis + posString;
    }
}
