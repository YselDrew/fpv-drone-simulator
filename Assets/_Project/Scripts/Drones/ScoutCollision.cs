using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutCollision : MonoBehaviour {
  ScoutController scoutController;
  Rigidbody rb;
  BoxCollider boxCollider;

  string enemyTag = "Enemy";
  string environmentTag = "Environment";
  string mapBoundariesTag = "MapBoundaries";

  void Start() {
    scoutController = this.GetComponent<ScoutController>();
    rb = this.GetComponent<Rigidbody>();
    boxCollider = this.GetComponent<BoxCollider>();
  }

  private void OnTriggerEnter(Collider collider) {
    if (
      collider.gameObject.CompareTag(environmentTag) ||
      collider.gameObject.CompareTag(enemyTag)
    ) {
      DisableDrone();
    }

    if(collider.gameObject.CompareTag(mapBoundariesTag)) CancelInvoke();
  }

  private void OnTriggerExit(Collider collider) {
    if(collider.gameObject.CompareTag(mapBoundariesTag)) Invoke("DisableDrone", 2f);
  }

  void DisableDrone() {
    scoutController.enabled = false;

    boxCollider.isTrigger = false;
    rb.isKinematic = false;
    rb.useGravity = true;
  }
}
