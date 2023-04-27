using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeDroneCollision : MonoBehaviour {
  [SerializeField] ParticleSystem explosion;

  string enemyTag = "Enemy";
  string environmentTag = "Environment";

  void OnTriggerEnter(Collider collider) {
    if (collider.gameObject.CompareTag(enemyTag)) {
      Debug.Log("Enemy Collision");
      Explode();
    }

    if (collider.gameObject.CompareTag(environmentTag)) {
      Debug.Log("You've hit environment");
      Explode();
    }
  }

  void Explode() {
    Quaternion defaultExplosionRotation = Quaternion.Euler(-90, 0, 0);
    Instantiate(explosion, transform.position, defaultExplosionRotation).Play();

    Destroy(gameObject);
  }
}
