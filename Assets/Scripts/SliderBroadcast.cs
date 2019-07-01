using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderBroadcast : MonoBehaviour
{
    private float _value;
    private Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        _slider = GetComponent<Slider>();
        _value = _slider.value;
        _slider.onValueChanged.AddListener(delegate {OnSpeedChanged(); });
    }

    public void OnSpeedChanged() {
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, _slider.value);
        print("Speed changed to: " + _slider.value);
    }


}
