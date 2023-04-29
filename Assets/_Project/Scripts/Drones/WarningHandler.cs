using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningHandler : MonoBehaviour {
  [SerializeField] GameObject spotZoneText;

  Text warningText;

  string mapBoundariesTag = "MapBoundaries";

  void Start() {
    warningText = spotZoneText.GetComponent<Text>();
  }

  protected virtual void OnTriggerEnter(Collider collider) {
    if (collider.gameObject.CompareTag(mapBoundariesTag)) {
      ShowMessage();
    }
  }

  protected virtual void OnTriggerExit(Collider collider) {
    if (collider.gameObject.CompareTag(mapBoundariesTag)) {
      ShowMessage("You're getting too far");
    }
  }

  protected void ShowMessage(string message = "") {
    warningText.text = message;
  }
}
