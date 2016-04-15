using UnityEngine;
using System.Collections;

public class toggleTobii : MonoBehaviour {
    void Awake()
    {
        toggle();
    }
    public void toggle()
    {
        InputManager.tobiiOn = this.GetComponent<UnityEngine.UI.Toggle>().isOn;
    }
}
