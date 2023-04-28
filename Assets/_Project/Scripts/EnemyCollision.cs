using UnityEngine;

public class EnemyCollision : MonoBehaviour {
  [SerializeField] ParticleSystem smoke;

  SphereCollider spotZoneCollider;

  string kamikazeDroneTag = "KamikazeDrone";
  string spotZoneTag = "SpotZone";

  void Start() {
    GameObject spotZone = GameObject.FindWithTag(spotZoneTag).gameObject;
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
