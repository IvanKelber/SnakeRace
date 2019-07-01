using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTrigger : MonoBehaviour
{

    [SerializeField] private SceneController controller;

    private void OnTriggerEnter(Collider other) {
        print("collided with other: " + other.ToString());

    }

    private void OnTriggerExit(Collider other) {
        controller.StartTimer();
    }
}
