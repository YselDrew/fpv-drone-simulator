using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutMarkerController : MonoBehaviour {

  [SerializeField] float rayLength = 50f;
  RaycastHit hit;

  void Update() {
    Debug.DrawRay(transform.position, transform.forward * rayLength, Color.red);

    if (Physics.Raycast(transform.position, transform.forward, out hit)) {
      if (hit.collider != null) {
        Debug.Log("hit");
      }
    }
  }
}
