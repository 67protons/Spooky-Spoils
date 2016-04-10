using UnityEngine;
using System.Collections;

public class KeyPickup : MonoBehaviour {
    public bool hasKey = false;
    // Use this for initialization
	void Awake () {
        this.GetComponent<Collider2D>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.GetComponent<GazeAwareComponent>().HasGaze)
        {
            this.GetComponent<Collider2D>().enabled = true;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        hasKey = true;
    }
}
