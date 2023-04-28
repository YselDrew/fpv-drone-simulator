using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {
    int prototypeSceneIndex = 0;

  void Update() {
    if (Input.GetKey(KeyCode.R)) SceneManager.LoadScene(prototypeSceneIndex);

    if (Input.GetKey(KeyCode.Escape)) Application.Quit();
  }
}
