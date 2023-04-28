using UnityEngine;

public class ShowDangerAreaWarning : MonoBehaviour {
  [SerializeField] GameObject spotZoneWarningText;

  string spotZoneTag = "SpotZone";

  void OnTriggerEnter(Collider collider) {
    if (collider.gameObject.CompareTag(spotZoneTag)) {
      toggleSpotZoneWarning(true);
    }
  }

  void OnTriggerExit(Collider collider) {
    if (collider.gameObject.CompareTag(spotZoneTag)) {
      toggleSpotZoneWarning(false);
    }
  }

  void toggleSpotZoneWarning(bool isActive) {
    spotZoneWarningText.SetActive(isActive);
  }
}
