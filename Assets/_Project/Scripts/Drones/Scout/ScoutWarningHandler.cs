using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutWarningHandler : WarningHandler {
  string spotZoneTag = "SpotZone";

  protected override void OnTriggerEnter(Collider collider) {
    base.OnTriggerEnter(collider);

    if (collider.gameObject.CompareTag(spotZoneTag)) {
      ShowMessage("Enemy spots you");
    }
  }

  protected override void OnTriggerExit(Collider collider) {
    base.OnTriggerExit(collider);

    if (collider.gameObject.CompareTag(spotZoneTag)) {
      base.ShowMessage();
    }
  }
}
