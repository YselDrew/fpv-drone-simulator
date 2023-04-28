using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeCollision : MonoBehaviour {
  [SerializeField] ParticleSystem explosion;

  string enemyTag = "Enemy";
  string environmentTag = "Environment";

  void OnTriggerEnter(Collider collider) {
    if (
      collider.gameObject.CompareTag(enemyTag) ||
      collider.gameObject.CompareTag(environmentTag)
    ) {
      DisableDrone();
    }
  }

  void DisableDrone() {
    PlayExplode();

    Destroy(gameObject);
  }

  void PlayExplode() {
    Quaternion defaultExplosionRotation = Quaternion.Euler(-90, 0, 0);
    Instantiate(explosion, transform.position, defaultExplosionRotation).Play();
  }
}
