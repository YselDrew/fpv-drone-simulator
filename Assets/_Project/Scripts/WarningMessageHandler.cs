using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* 
  Maybe this logic should be
  part of ScoutCollision.cs?
*/
public class WarningMessageHandler : MonoBehaviour {
  [SerializeField] GameObject spotZoneText;

  Text warningText;

  string spotZoneTag = "SpotZone";
  string mapBoundariesTag = "MapBoundaries";

  void Start() {
    warningText = spotZoneText.GetComponent<Text>();
  }

  void OnTriggerEnter(Collider collider) {
    if (collider.gameObject.CompareTag(spotZoneTag)) {
      ShowMessage("Enemy spots you");
    }

    if (collider.gameObject.CompareTag(mapBoundariesTag)) {
      ShowMessage();
    }
  }

  void OnTriggerExit(Collider collider) {
    if (collider.gameObject.CompareTag(spotZoneTag)) {
      ShowMessage();
    }

    if (collider.gameObject.CompareTag(mapBoundariesTag)) {
      ShowMessage("You're getting too far");
    }
  }

  void ShowMessage(string message = "") {
    warningText.text = message;
  }
}
