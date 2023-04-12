using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSwitch : MonoBehaviour {
  [SerializeField] GameObject scoutDrone;
  [SerializeField] GameObject kamikazeDrone;

  void Start() {
    scoutDrone.SetActive(true);
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.E)) SwitchDrone();
  }

  void SwitchDrone() {
    scoutDrone.SetActive(false);
    kamikazeDrone.SetActive(true);
  }
}
