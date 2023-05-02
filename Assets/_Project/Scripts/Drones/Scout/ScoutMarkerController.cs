using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutMarkerController : MonoBehaviour {

  [SerializeField] GameObject icon;
  [SerializeField] float rayLength = 50f;
  [SerializeField] float iconVerticalOffset = 1f;

  RaycastHit hit;

  void Update() {
    Debug.DrawRay(transform.position, transform.forward * rayLength, Color.red);

    if(Input.GetKeyDown(KeyCode.F)) {
      if (Physics.Raycast(transform.position, transform.forward, out hit)) {
        if (hit.collider != null) {
          icon.transform.position = new Vector3(
            hit.point.x, 
            hit.point.y + iconVerticalOffset,
            hit.point.z
          );
        }
      }
    }
  }
}
