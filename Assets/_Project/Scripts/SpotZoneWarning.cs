using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpotZoneWarning : MonoBehaviour {
  [SerializeField] GameObject spotZoneText;

  Text warningText;

  string spotZoneTag = "SpotZone";

  void Start() {
    warningText = spotZoneText.GetComponent<Text>();
  }

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
    warningText.enabled = isActive;
  }
}
