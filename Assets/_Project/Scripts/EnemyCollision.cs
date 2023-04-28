using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {
  [SerializeField] ParticleSystem smoke;
  [SerializeField] GameObject spotZone;

  SphereCollider spotZoneCollider;

  string kamikazeDroneTag = "KamikazeDrone";

  void Start() {
    spotZoneCollider = spotZone.GetComponent<SphereCollider>();
  }

  void OnTriggerEnter(Collider collider) {
    bool isTriggeredByKamikaze = collider.gameObject.CompareTag(kamikazeDroneTag);

    if (isTriggeredByKamikaze) DisableEnemy();
  }

  void DisableEnemy() {
    spotZoneCollider.enabled = false;

    smoke.Play();
  }
}
