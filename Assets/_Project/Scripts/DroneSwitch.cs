using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSwitch : MonoBehaviour {
  [SerializeField] GameObject scoutDrone;
  [SerializeField] GameObject kamikazeDrone;

  bool isDroneActive = true;

  void Start() {
    activateDrone();
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.E)) SwitchDrone();
  }

  void activateDrone() {
    scoutDrone.SetActive(isDroneActive);
    kamikazeDrone.SetActive(!isDroneActive);
  }

  void SwitchDrone() {
    /* 
      Toggle is only for development purposes.
      In final version you won't be able
      switch back until kamikaze drone will be 
      destroyed
    */
    isDroneActive = !isDroneActive;

    activateDrone();
  }
}
