using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutCollision : DroneCollision {
  ScoutController scoutController;
  Rigidbody rb;
  BoxCollider boxCollider;

  void Start() {
    scoutController = this.GetComponent<ScoutController>();
    rb = this.GetComponent<Rigidbody>();
    boxCollider = this.GetComponent<BoxCollider>();
  }

  protected override void DisableDrone() {
    scoutController.enabled = false;

    boxCollider.isTrigger = false;
    rb.isKinematic = false;
    rb.useGravity = true;
  }
}







