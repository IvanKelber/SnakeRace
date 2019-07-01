using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private float currentTime = 0.0f;
    private bool timing = false;    
    [SerializeField] private UIController uiController;

    // Update is called once per frame
    void Update()
    {
        if(timing) {
            currentTime += Time.deltaTime;
            uiController.UpdateTime(currentTime);
        }
    }

    public void StartTimer() {
        currentTime = 0.0f;
        timing = true;
    }

    public void PauseTimer() {
        timing = false;
    }

    public void UnPauseTimer() {
        timing = true;
    }

    public void StopTimer() {
        timing = false;
    }

    private void Awake() {
        Messenger.AddListener(GameEvent.PAUSE, PauseTimer);
        Messenger.AddListener(GameEvent.UNPAUSE, UnPauseTimer);

    }

    private void OnDestroy() {
        Messenger.RemoveListener(GameEvent.PAUSE, PauseTimer);
        Messenger.RemoveListener(GameEvent.UNPAUSE, UnPauseTimer);
    }
}
