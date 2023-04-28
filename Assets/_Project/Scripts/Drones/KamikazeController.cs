using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeController : MonoBehaviour {
  [SerializeField] float droneSpeed = 15f;
  [SerializeField] int rotationSensitivity = 250;

  bool isLaunched = false;

  Camera droneCamera;
  Vector2 cameraRotation;

  void Start() {
    Cursor.lockState = CursorLockMode.Locked;
    droneCamera = this.GetComponent<Camera>();
  }

  void Update() {
    if (Input.GetKeyDown(KeyCode.Space)) isLaunched = true;

    if (isLaunched) {
      MoveDrone();
      RotateDrone();
    }
  }

  /* 
    This function makes glitches
    when drone moves 90 degrees
    up or down. I don't know why.
  */
  void RotateDrone() {
    float updatedRotationX =
      transform.localEulerAngles.x -
      (Input.GetAxis("Mouse Y") * rotationSensitivity * Time.deltaTime);

    float updatedRotationY =
      transform.localEulerAngles.y +
      (Input.GetAxis("Mouse X") * rotationSensitivity * Time.deltaTime);

    transform.localEulerAngles = new Vector3(
      updatedRotationX,
      updatedRotationY,
      0
    );
  }

  void MoveDrone() {
    transform.localPosition +=
      droneCamera.transform.forward * droneSpeed * Time.deltaTime;
  }
}
