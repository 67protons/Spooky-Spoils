using UnityEngine;
using System.Collections;


public class MouseAwareComponent : MonoBehaviour {
    [HideInInspector]
    public bool HasMouse = false;    
    public Vector2 projectedBounds;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _mousePos;
    private float xMin, xMax, yMin, yMax;


    void Awake()
    {
        _spriteRenderer = this.GetComponent<SpriteRenderer>();             
    }

    void Update()
    {
        if (projectedBounds == Vector2.zero || projectedBounds.x <= 0 || projectedBounds.y <= 0)
        {
            Vector3 _bounds = _spriteRenderer.bounds.size;
            xMin = this.transform.position.x - (_bounds.x / 2);
            xMax = this.transform.position.x + (_bounds.x / 2);
            yMin = this.transform.position.y - (_bounds.y / 2);
            yMax = this.transform.position.y + (_bounds.y / 2);
        }
        else
        {
            xMin = this.transform.position.x - (projectedBounds.x / 2);
            xMax = this.transform.position.x + (projectedBounds.x / 2);
            yMin = this.transform.position.y - (projectedBounds.y / 2);
            yMax = this.transform.position.y + (projectedBounds.y / 2);
        }  

        _mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        HasMouse = (xMin <= _mousePos.x && _mousePos.x <= xMax && yMin <= _mousePos.y && _mousePos.y <= yMax);        
    }


}
