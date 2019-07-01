using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    [SerializeField] private TextMesh tmp;
    [SerializeField] private SceneController sceneController;
    [SerializeField] private Button settings;
    [SerializeField] private SettingsPopup settingsPopup;
    private float settingsButtonScale = 1.2f;

    // Start is called before the first frame update
    void Start()
    {
        tmp.text = "" + 0.0f;
        settingsPopup.Close();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            print("Pressing Key Escape");
            if(!settingsPopup.IsOpen()) {
                OnOpenSettings();
            } else {
                OnCloseSettings();
            }
        }
    }

    public void UpdateTime(float time) {
        tmp.text = "" + time;
    }

    public void OnOpenSettings() {
        settingsPopup.Open();
        Messenger.Broadcast(GameEvent.PAUSE);
    }

    public void OnCloseSettings() {
        settingsPopup.Close();
        Messenger.Broadcast(GameEvent.UNPAUSE);
    }


    public void OnMouseEnterSettings() {
        settings.transform.localScale *= settingsButtonScale;
    }

    public void OnMouseExitSettings() {
        settings.transform.localScale /= settingsButtonScale;
    }
}
