using UnityEngine;
using System.Collections;

public class KeyPickup : MonoBehaviour {
    public bool hasKey = false;
    // Use this for initialization
	void Awake () {
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        hasKey = true;
    }
}
