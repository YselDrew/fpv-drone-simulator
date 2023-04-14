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
    if (kamikazeDrone == null) scoutDrone.SetActive(true);

    if (Input.GetKeyDown(KeyCode.E)) SwitchDrone();
  }

  void ActivateDrone() {
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

    ActivateDrone();
  }
}
