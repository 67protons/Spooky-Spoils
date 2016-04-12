using UnityEngine;
using System.Collections;

public class KeyPickup : MonoBehaviour {
    public bool hasKey = false;
    private GazeAwareComponent _gazeAware;
    private MouseAwareComponent _mouseAware;
    private bool HasGaze
    {
        get { return ((InputManager.tobiiOn && _gazeAware.HasGaze) || (!InputManager.tobiiOn && _mouseAware.HasMouse)); }
    }

	public virtual void Awake () {
        _gazeAware = this.GetComponent<GazeAwareComponent>();
        _mouseAware = this.GetComponent<MouseAwareComponent>();
        if (AwareNotNull())
            this.GetComponent<Collider2D>().enabled = false;
	}
		
    public virtual void Update()
    {        
        if (AwareNotNull() && this.HasGaze)
        {
            this.GetComponent<Collider2D>().enabled = true;
        }
	}

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            hasKey = true;
    }

    public bool AwareNotNull()
    {
        return _gazeAware != null && _mouseAware != null;
    }
}
