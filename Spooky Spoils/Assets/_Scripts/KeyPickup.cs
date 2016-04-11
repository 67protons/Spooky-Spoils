using UnityEngine;
using System.Collections;

public class KeyPickup : MonoBehaviour {
    public bool hasKey = false;
    private GazeAwareComponent _gazeAware;
	public virtual void Awake () {
        _gazeAware = this.GetComponent<GazeAwareComponent>();
        if (_gazeAware != null)
            this.GetComponent<Collider2D>().enabled = false;
	}
		
    public virtual void Update()
    {        
        if (_gazeAware != null && _gazeAware.HasGaze)
        {
            this.GetComponent<Collider2D>().enabled = true;
        }
	}

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            hasKey = true;
    }
}
