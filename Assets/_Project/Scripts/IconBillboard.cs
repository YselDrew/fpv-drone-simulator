using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconBillboard : MonoBehaviour {
  [SerializeField] GameObject scoutDrone;
  [SerializeField] GameObject kamikazeDrone;

  Camera scoutCamera;
  Camera kamikazeCamera;

  void Start() {
    scoutCamera = scoutDrone.GetComponent<Camera>();
    kamikazeCamera = kamikazeDrone.GetComponent<Camera>();
  }

  void Update() {
    if (scoutDrone.activeSelf) {
      transform.rotation = scoutCamera.transform.rotation;
      return;
    }

    transform.rotation = kamikazeCamera.transform.rotation;
  }
}
