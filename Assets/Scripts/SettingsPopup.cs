using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsPopup : MonoBehaviour
{

    private bool _open = false;

    public void Close() {
        gameObject.SetActive(false);
        _open = false;
    }

    public void Open() {
        gameObject.SetActive(true);
        _open = true;
    }

    public bool IsOpen() {
        return _open;
    }
}
