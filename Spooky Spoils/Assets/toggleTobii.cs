using UnityEngine;
using System.Collections;

public class toggleTobii : MonoBehaviour {
    void Awake()
    {
        toggle(true);
    }
    public void toggle(bool activated)
    {
        InputManager.tobiiOn = activated;
    }
}
