using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCollision : MonoBehaviour {
  [SerializeField] float timeToLive = 2f;

  string enemyTag = "Enemy";
  string environmentTag = "Environment";
  string mapBoundariesTag = "MapBoundaries";

  protected virtual void DisableDrone() { }

  void OnTriggerEnter(Collider collider) {
    if (
      collider.gameObject.CompareTag(enemyTag) ||
      collider.gameObject.CompareTag(environmentTag)
    ) {
      DisableDrone();
    }

    if (collider.gameObject.CompareTag(mapBoundariesTag)) CancelInvoke();
  }

  void OnTriggerExit(Collider collider) {
    if (collider.gameObject.CompareTag(mapBoundariesTag)) Invoke("DisableDrone", timeToLive);
  }
}
