using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutDroneController : MonoBehaviour {
  [SerializeField] int verticalSpeed = 10;
  [SerializeField] int rotationSensitivity = 250;

  [SerializeField] int scrollSensitivity = 7000;
  [SerializeField, Tooltip("The lower value, the highest zoom")] int minFieldOfView = 30;
  int maxFieldOfView = 60;

  Vector3 startPosition = new Vector3(25, 1, 10);
  Quaternion startRotation = Quaternion.Euler(0, 0, 0);

  Vector2 cameraRotation;

  void Start() {
    Cursor.lockState = CursorLockMode.Locked;
  }

  void Update() {
    MoveDrone();
    RotateDrone();
    ZoomView();
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
      -cameraRotation.y, // why -y on x???
      cameraRotation.x,
      0
    );
  }

  void MoveDrone() {
    int direction = 1;

    if (Input.GetKey(KeyCode.D)) MoveAside(direction);
    if (Input.GetKey(KeyCode.A)) MoveAside(-direction);
    if (Input.GetKey(KeyCode.W)) MoveForward(direction);
    if (Input.GetKey(KeyCode.S)) MoveForward(-direction);

    if (Input.GetKey(KeyCode.Space)) MoveVertical(direction);
    if (Input.GetKey(KeyCode.LeftControl)) MoveVertical(-direction);
  }

  void MoveForward(int direction) {
    Vector3 cameraForward = Vector3.ProjectOnPlane(
      Camera.main.transform.forward,
      Vector3.up
    ).normalized;

    Vector3 updatedPosition = transform.localPosition
      + (cameraForward * verticalSpeed * Time.deltaTime * direction);

    /* 
      When drone rotates camera
      we don't want to MOVE drone
      in horizontal axis (up/down)
    */
    float lockedY = transform.localPosition.y;

    transform.localPosition = new Vector3(
      updatedPosition.x,
      lockedY,
      updatedPosition.z
    );
  }

  void MoveAside(int direction) {
    Vector3 cameraRight = Vector3.ProjectOnPlane(
      Camera.main.transform.right,
      Vector3.up
    ).normalized;

    transform.localPosition += cameraRight * verticalSpeed * Time.deltaTime * direction;
  }

  void MoveVertical(int direction) {
    float updatedY = transform.localPosition.y
      + (verticalSpeed * Time.deltaTime * direction);

    transform.localPosition = new Vector3(
      transform.localPosition.x,
      updatedY,
      transform.localPosition.z
    );
  }

  void ZoomView() {
    float zoom = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity * Time.deltaTime;
    float cameraFieldOfView = Camera.main.fieldOfView - zoom;

    Camera.main.fieldOfView = Mathf.Clamp(
      cameraFieldOfView,
      minFieldOfView,
      maxFieldOfView
    );
  }
}
