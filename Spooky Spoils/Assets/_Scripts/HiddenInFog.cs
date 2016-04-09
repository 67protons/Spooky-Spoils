using UnityEngine;
using System.Collections;

public class HiddenInFog : MonoBehaviour {

    private GazeAwareComponent _gazeAware;
    private SpriteRenderer _spriteRenderer;
    protected bool HasGaze
    {
        get 
        {     
            return _gazeAware.HasGaze;
        }
    }

    public virtual void Awake()
    {
        _gazeAware = this.GetComponent<GazeAwareComponent>();
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

	public virtual void Start () {
	    
	}
		
	public virtual void Update () {
        ManageState();
	}

    private void ManageState()
    {
        if (_gazeAware.HasGaze)
        {
            //Debug.Log("Senpai noticed me");
            _spriteRenderer.enabled = true;
        }
        else
        {
            _spriteRenderer.enabled = false;
        }
    }
}
