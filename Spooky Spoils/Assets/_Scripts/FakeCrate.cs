using UnityEngine;
using System.Collections;

public class FakeCrate : MonoBehaviour {
    public bool playerIsPirate = false;

    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider;    
    private bool _objectInSpot = false;

    void Awake()
    {
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
        _collider = this.GetComponent<Collider2D>();
    }
    
    void Update()
    {    
        if (this.playerIsPirate)
        {
            Disappear();
        }        
        else if (!_objectInSpot)
        {
            Reappear();
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {        
        if (other.CompareTag("Player") || other.CompareTag("Barrel"))
        {            
            _objectInSpot = true;
        }        
    }

    void OnTriggerExit2D(Collider2D other)
    {        
        if (other.CompareTag("Player") || other.CompareTag("Barrel"))
        {            
            _objectInSpot = false;
        }        
    }

    void Disappear()
    {
        _spriteRenderer.enabled = false;
        _collider.isTrigger = true;        
    }

    void Reappear()
    {
        _spriteRenderer.enabled = true;
        _collider.isTrigger = false;
    }    
}
