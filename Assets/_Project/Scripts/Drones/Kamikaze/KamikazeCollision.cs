using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeCollision : DroneCollision {
  [SerializeField] ParticleSystem explosion;

  protected override void DisableDrone() {
    PlayExplode();

    Destroy(gameObject);
  }

  void PlayExplode() {
    Quaternion defaultExplosionRotation = Quaternion.Euler(-90, 0, 0);
    Instantiate(explosion, transform.position, defaultExplosionRotation).Play();
  }
}






