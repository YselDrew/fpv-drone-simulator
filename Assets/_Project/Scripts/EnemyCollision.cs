using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {
  [SerializeField] ParticleSystem smoke;
  [SerializeField] ParticleSystem explosion;

  void OnTriggerEnter(Collider other) {
    explosion.Play();
    smoke.Play();
  }
}
