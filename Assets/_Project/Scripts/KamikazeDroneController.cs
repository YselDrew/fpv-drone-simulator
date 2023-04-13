using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeDroneController : MonoBehaviour {
  [SerializeField] float droneSpeed = 25f;
  [SerializeField] int rotationSensitivity = 250;

  bool isLaunched = false;
  bool test = true;

  Camera droneCamera;
  Vector2 cameraRotation;

  void Start() { 
    Cursor.lockState = CursorLockMode.Locked;
    droneCamera = this.GetComponent<Camera>();

    Debug.Log("start " + transform.eulerAngles);

    // somewhere here problem with start rotation
    cameraRotation = new Vector2(
      transform.eulerAngles.y, 
      transform.eulerAngles.x
    );
  }

  void Update() {
    // -- debug log -- 
    if (test && isLaunched) {
      Debug.Log("update" + transform.eulerAngles);
      test = false;
    }

    if (Input.GetKeyDown(KeyCode.Space)) isLaunched = true;

    if (isLaunched) {
      MoveDrone();
      RotateDrone();
    }
  }

  void RotateDrone() {
    /* 
      If I'm using 90/-90 degrees
      MoveForward function stops working
      for some reason. I guess, vector
      projected on plane doesn't 
      point to any direction. 
    */
    float maxRotation = 89.9f;

    cameraRotation.x += Input.GetAxis("Mouse X") * rotationSensitivity * Time.deltaTime;
    cameraRotation.y += Input.GetAxis("Mouse Y") * rotationSensitivity * Time.deltaTime;

    cameraRotation.y = Mathf.Clamp(cameraRotation.y, -maxRotation, maxRotation);

    transform.localRotation = Quaternion.Euler(
      -cameraRotation.y,
      cameraRotation.x,
      0
    );
  }

  void MoveDrone() {
    transform.localPosition = transform.localPosition + droneCamera.transform.forward * droneSpeed * Time.deltaTime;
  }
}
