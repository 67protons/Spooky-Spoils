using UnityEngine;
using System.Collections;

public class GhostStatue : MonoBehaviour {

    public float speed = 1f;
    public bool isChasing = false;
    public bool activated = false;

    private GameObject player;
    private GazeAwareComponent _gazeAware;
    private Animator anim;

    void Awake()
    {
        _gazeAware = this.GetComponent<GazeAwareComponent>();
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
        if (_gazeAware.HasGaze)
        {
            isChasing = false;
            anim.SetBool("isAttacking", false);
        }
        else
        {
            isChasing = true;
            anim.SetBool("isAttacking", true);
            anim.Play("PlebStatueAttack");
        }
    }
}
