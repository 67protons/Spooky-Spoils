using UnityEngine;
using System.Collections;

public class GhostStatue : Enemy {

    public float speed = 1f;
    public bool isChasing = false;
    public bool activated = false;
    public bool hasGaze
    {
        get { return ((InputManager.tobiiOn && _gazeAware.HasGaze) || (!InputManager.tobiiOn && _mouseAware.HasMouse)); }
    }
    private GameObject player;
    private GazeAwareComponent _gazeAware;
    private MouseAwareComponent _mouseAware;
    public Animator anim;

    void Awake()
    {
        _gazeAware = this.GetComponent<GazeAwareComponent>();
        _mouseAware = this.GetComponent<MouseAwareComponent>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (activated)
        {
            checkState();
            if (isChasing)
            {
                float step = speed * Time.deltaTime;
                this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, step);
            }
        }
    }

    void checkState()
    {
        if (isChasing)
        {
            anim.SetBool("isAttacking", true);
            anim.Play("StatueAttack");
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }

    public override void Stop()
    {
        this.activated = false;
        anim.SetBool("isAttacking", false);
    }
}
