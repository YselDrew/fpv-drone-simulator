using UnityEngine;

public class ScoutDroneCollisions : MonoBehaviour {
  ScoutDroneController scoutController;
  Rigidbody rb;
  BoxCollider boxCollider;

  SphereCollider spotZoneCollider;

  string enemyTag = "Enemy";
  string spotZoneTag = "SpotZone";
  string environmentTag = "Environment";

  void Start() {
    scoutController = this.GetComponent<ScoutDroneController>();
    rb = this.GetComponent<Rigidbody>();
    boxCollider = this.GetComponent<BoxCollider>();

    GameObject spotZone = GameObject.FindWithTag(spotZoneTag).gameObject;
    spotZoneCollider = spotZone.GetComponent<SphereCollider>();
  }

  private void OnTriggerEnter(Collider collider) {
    if (collider.gameObject.CompareTag(spotZoneTag)) Invoke("DropDrone", 3);

    if (
      collider.gameObject.CompareTag(environmentTag) ||
      collider.gameObject.CompareTag(enemyTag)
    ) {
      DropDrone();
    }
  }

  void OnTriggerExit(Collider collider) {
    if (collider.gameObject.CompareTag(spotZoneTag)) CancelInvoke();
  }

  void DropDrone() {
    /* 
      disabling area collider is permanently-temporary 
      workaround, since I have no idea
      how to fix drone jittering when
      its being destroyed inside spot zone 
    */
    spotZoneCollider.enabled = false;

    scoutController.enabled = false;

    boxCollider.isTrigger = false;
    rb.isKinematic = false;
    rb.useGravity = true;
  }
}
