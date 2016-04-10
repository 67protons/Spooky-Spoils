using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float moveSpeed = 3f;
    private Animator anim;
    private bool movingLeft, movingRight;
    private bool movingUp, movingDown;

    /*public override */void Start()
    {
        //base.Start();
        anim = this.GetComponent<Animator>();        
    }

	/*public override */void Update () {
        //base.Update();
        //ManageState();
        //Horizontal Movement
        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetBool("isWalking", true);
            anim.Play("PlayerWalkLeft");
            movingLeft = true;
            movingRight = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            //anim.SetBool("isWalking", false);
            movingLeft = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetBool("isWalking", true);
            anim.Play("PlayerWalkRight");
            movingRight = true;
            movingLeft = false;
        }
      
        if (Input.GetKeyUp(KeyCode.D))
        {
            //anim.SetBool("isWalking", false);
            movingRight = false;
        }

        //Vertical Movement
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("isWalking", true);
            anim.Play("PlayerWalkUp");
            movingUp = true;
            movingDown = false;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            //anim.SetBool("isWalking", false);
            movingUp = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            anim.SetBool("isWalking", true);
            anim.Play("PlayerWalkDown");
            movingDown = true;
            movingUp = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            //anim.SetBool("isWalking", false);
            movingDown = false;
        }

        //if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W)))
        if(!(movingLeft || movingRight || movingUp || movingDown))
            anim.SetBool("isWalking", false);

	}

    void FixedUpdate()
    {
        if (movingLeft)
        {
            this.transform.Translate(new Vector2(-moveSpeed * Time.deltaTime, 0f));
        }
        else if (movingRight)
        {
            this.transform.Translate(new Vector2(moveSpeed * Time.deltaTime, 0f));
        }
        if (movingUp)
        {
            this.transform.Translate(new Vector2(0f, moveSpeed * Time.deltaTime));
        }
        else if (movingDown)
        {
            this.transform.Translate(new Vector2(0f, -moveSpeed * Time.deltaTime));
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
