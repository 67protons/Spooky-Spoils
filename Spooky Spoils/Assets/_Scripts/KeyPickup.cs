using UnityEngine;
using System.Collections;

public class KeyPickup : MonoBehaviour {
    public bool hasKey = false;    
	public virtual void Awake () {
        this.GetComponent<Collider2D>().enabled = false;
	}
		
    public virtual void Update()
    {
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
