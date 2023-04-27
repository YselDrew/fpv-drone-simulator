using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {
  [SerializeField] ParticleSystem smoke;

  SphereCollider dangerAreaCollider;

  string kamikazeDroneTag = "KamikazeDrone";
  string dangerAreaTag = "DangerArea";

  void Start() {
    GameObject dangerArea = GameObject.FindWithTag(dangerAreaTag).gameObject;
    dangerAreaCollider = dangerArea.GetComponent<SphereCollider>();
  }

  void OnTriggerEnter(Collider collider) {
    bool isTriggeredByKamikaze = collider.gameObject.CompareTag(kamikazeDroneTag);

    if (isTriggeredByKamikaze) DisableEnemy();
  }

  void DisableEnemy() {
    dangerAreaCollider.enabled = false;

    smoke.Play();
  }
}
