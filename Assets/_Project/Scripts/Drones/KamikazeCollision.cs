using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeCollision : MonoBehaviour {
  [SerializeField] ParticleSystem explosion;

  string enemyTag = "Enemy";
  string environmentTag = "Environment";
  string mapBoundariesTag = "MapBoundaries";

  /* 
    This and same method in ScoutCollision
    may be good candidates for abstract 
    class method
  */
  void OnTriggerEnter(Collider collider) {
    if (
      collider.gameObject.CompareTag(enemyTag) ||
      collider.gameObject.CompareTag(environmentTag)
    ) {
      DisableDrone();
    }
  }

  private void OnTriggerExit(Collider collider) {
    if(collider.gameObject.CompareTag(mapBoundariesTag)) DisableDrone();
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
