using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutDroneCollisions : MonoBehaviour {
  ScoutDroneController scoutController;
  Rigidbody rb;
  BoxCollider boxCollider;

  SphereCollider dangerAreaCollider;

  string enemyTag = "Enemy";
  string dangerAreaTag = "DangerArea";
  string environmentTag = "Environment";

  void Start() {
    scoutController = this.GetComponent<ScoutDroneController>();
    rb = this.GetComponent<Rigidbody>();
    boxCollider = this.GetComponent<BoxCollider>();

    GameObject dangerArea = GameObject.FindWithTag(dangerAreaTag).gameObject;
    dangerAreaCollider = dangerArea.GetComponent<SphereCollider>();
  }

  private void OnTriggerEnter(Collider collider) {
    if (collider.gameObject.CompareTag(dangerAreaTag)) {
      Debug.Log("You're in dangerous area");
      Invoke("DropDrone", 3);
    }

    /* 
      This requires refactoring
    */
    if (
      collider.gameObject.CompareTag(environmentTag) ||
      collider.gameObject.CompareTag(enemyTag)
    ) {
      Debug.Log("You've hit environment");
      DropDrone();
    }
  }

  void OnTriggerExit(Collider collider) {
    if (collider.gameObject.CompareTag(dangerAreaTag)) {
      Debug.Log("You're leaving danger zone");
      CancelInvoke();
    }
  }

  void DropDrone() {
    /* 
      area collider is permanently-temporary 
      workaround, since I have no idea
      how to fix drone jittering when
      its being destroyd inside danger area
    */
    dangerAreaCollider.enabled = false;

    scoutController.enabled = false;

    boxCollider.isTrigger = false;
    rb.isKinematic = false;
    rb.useGravity = true;
  }
}
