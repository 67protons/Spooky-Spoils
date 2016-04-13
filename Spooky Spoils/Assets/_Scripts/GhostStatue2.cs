using UnityEngine;
using System.Collections;

public class GhostStatue2 : Enemy {

    public Sprite neutralSprite, chasingSprite;
    public float speed = 1f;
    //public bool isChasing = false;
    public bool activated = false;
    private bool hasGaze
    {
        get { return ((InputManager.tobiiOn && _gazeAware.HasGaze) || (!InputManager.tobiiOn && _mouseAware.HasMouse)); }
    }
    private GameObject player;
    private GazeAwareComponent _gazeAware;
    private MouseAwareComponent _mouseAware;
    private SpriteRenderer _spriteRenderer;
    //public Animator anim;

    void Awake()
    {
        _gazeAware = this.GetComponent<GazeAwareComponent>();
        _mouseAware = this.GetComponent<MouseAwareComponent>();
        player = GameObject.FindGameObjectWithTag("Player");
        _spriteRenderer = this.GetComponent<SpriteRenderer>();
        //anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (activated)
        {
            checkState();           
        }
    }

    void checkState()
    {
        if (!this.hasGaze)
        {
            this.GetComponent<Collider2D>().isTrigger = true;
            float step = speed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, step);
            _spriteRenderer.sprite = chasingSprite;
        }
        else if (this.hasGaze)
        {
            this.GetComponent<Collider2D>().isTrigger = false;
            _spriteRenderer.sprite = neutralSprite;
        }
    }
}
