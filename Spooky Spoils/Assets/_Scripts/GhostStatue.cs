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

    private AudioSource audioClip;

    void Awake()
    {
        _gazeAware = this.GetComponent<GazeAwareComponent>();
        _mouseAware = this.GetComponent<MouseAwareComponent>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = this.GetComponent<Animator>();
        audioClip = this.GetComponent<AudioSource>();
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
            this.GetComponent<Collider2D>().isTrigger = true;
            anim.SetBool("isAttacking", true);
            anim.Play("StatueAttack");
            if(audioClip != null && !audioClip.isPlaying)
            {
                audioClip.PlayOneShot(audioClip.clip);
            }
        }
        else
        {
            anim.SetBool("isAttacking", false);
//<<<<<<< HEAD
            if(audioClip != null)
                audioClip.Stop();
//=======
            this.GetComponent<Collider2D>().isTrigger = false;
//>>>>>>> 2936f90d086986271e11ad5a966ea3255bf52465
        }
    }

    public override void Stop()
    {
        this.activated = false;
        this.GetComponent<Collider2D>().isTrigger = false;
        anim.SetBool("isAttacking", false);
    }
}
