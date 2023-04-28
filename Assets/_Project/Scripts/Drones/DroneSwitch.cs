using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSwitch : MonoBehaviour {
  [SerializeField] GameObject scoutDrone;
  [SerializeField] GameObject kamikazeDrone;

  bool isDroneActive = true;

  void Start() {
    ActivateDrone();
  }

  void Update() {
    bool isKamikazeDestroyed = kamikazeDrone == null;

    if (isKamikazeDestroyed) scoutDrone.SetActive(true);
    if (Input.GetKeyDown(KeyCode.E) && !isKamikazeDestroyed) SwitchDrone();
  }

  void ActivateDrone() {
    scoutDrone.SetActive(isDroneActive);
    kamikazeDrone.SetActive(!isDroneActive);
  }

  void SwitchDrone() {
    /* 
      Toggle is only for development purposes.
      In final version player won't be able
      switch back until kamikaze drone will be 
      destroyed
    */
    isDroneActive = !isDroneActive;

    ActivateDrone();
  }
}
