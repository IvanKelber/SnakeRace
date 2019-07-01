using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    private float baseSpeed = 15.0f;
    private float speed = 15.0f;
    private float turnSpeed = 3.0f;
    private Vector3 movement;

    private bool autoRun = false;
    private bool _paused = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(!_paused) {
            if(autoRun) {
                movement = Vector3.forward * speed;
            } else {
                // float deltaX = Input.GetAxis("Horizontal") * speed;
                float deltaZ = Input.GetAxis("Vertical") * speed;
                // movement.x = deltaX;
                movement.z = deltaZ;
                movement = Vector3.ClampMagnitude(movement, speed); // clamp diagonal velocity
            }

            movement *= Time.deltaTime;
            transform.Translate(movement);

            float turn = Input.GetAxis("Horizontal") * turnSpeed;
            transform.Rotate(turn * Vector3.up);
        }

    }

    private void Awake() {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedUpdated);
        Messenger.AddListener(GameEvent.PAUSE, PauseMovement);
        Messenger.AddListener(GameEvent.UNPAUSE, UnPauseMovement);
    }

    private void OnDestroy() {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedUpdated);
        Messenger.RemoveListener(GameEvent.PAUSE, PauseMovement);
        Messenger.RemoveListener(GameEvent.UNPAUSE, UnPauseMovement);
    }

    private void OnSpeedUpdated(float value) {
        speed = baseSpeed * value;
    }

    public void PauseMovement() {
        _paused = true;
    }

    public void UnPauseMovement() {
        _paused = false;
    }
}
