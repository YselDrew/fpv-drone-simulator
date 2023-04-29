using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingProjectile: MonoBehaviour {
  [SerializeField] GameObject projectile;
  [SerializeField] float offset = 0.5f;
  [SerializeField] int timeToLive = 3;

  Vector3 dronePosition;

  void OnTriggerEnter(Collider collider) {
    if (collider.gameObject.CompareTag("ScoutDrone")) {
      Invoke("ChangeProjectilePosition", timeToLive);
    }
  }

  void OnTriggerStay(Collider collider) {
    if (collider.gameObject.CompareTag("ScoutDrone")) {
      dronePosition = collider.gameObject.transform.position;
    }
  }

  void OnTriggerExit(Collider collider) {
    if (collider.gameObject.CompareTag("ScoutDrone")) {
      CancelInvoke();
    }
  }

  void ChangeProjectilePosition() {
    projectile.transform.position = new Vector3(
        dronePosition.x,
        dronePosition.y - offset,
        dronePosition.z
    );

    gameObject.GetComponent<SphereCollider>().enabled = false;
    Destroy(projectile, 1f);
  }
}
