using UnityEngine;
using System.Collections;

public class HiddenInFog : MonoBehaviour {

    private GazeAwareComponent _gazeAware;
    private MouseAwareComponent _mouseAware;
    private SpriteRenderer _spriteRenderer;
    protected bool HasGaze
    {
        get 
        {     
            return ((InputManager.tobiiOn && _gazeAware.HasGaze) || (!InputManager.tobiiOn && _mouseAware.HasMouse));
        }
    }

    public virtual void Awake()
    {
        _gazeAware = this.GetComponent<GazeAwareComponent>();
        _mouseAware = this.GetComponent<MouseAwareComponent>();
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

	public virtual void Start () {
	    
	}
		
	public virtual void Update () {        
        if (this.HasGaze)
        {
            _spriteRenderer.enabled = true;
        }
        else
        {
            _spriteRenderer.enabled = false;
        }
	}
}
