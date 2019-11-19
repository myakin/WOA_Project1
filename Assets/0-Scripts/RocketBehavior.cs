using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBehavior : MonoBehaviour
{
    public float forceMagnitude = 500f;
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            // Vector3 entranceVector = other.transform.position - transform.position;
            // float entranceAngle = Vector3.SignedAngle(entranceAngle, transform.up,transform.forward);

            other.GetComponent<Rigidbody>().AddForce(transform.up * forceMagnitude);
            Destroy(gameObject);
        }
    }
}
