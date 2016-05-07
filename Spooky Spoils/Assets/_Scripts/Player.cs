using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float moveSpeed = 3f;
    private Animator anim;
    private Direction currentDirection = Direction.None;
    private Direction lastDirection = Direction.None;

    void Start()
    {
        anim = this.GetComponent<Animator>();        
    }

	void Update () {

        if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W)))
        {
            anim.SetBool("isWalking", false);
            currentDirection = Direction.None;
        }

        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isWalking", true);
            currentDirection = Direction.Left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isWalking", true);
            currentDirection = Direction.Right;
        }
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("isWalking", true);
            currentDirection = Direction.Up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("isWalking", true);
            currentDirection = Direction.Down;
        }

        if (lastDirection != currentDirection)
        {
            switch (currentDirection)
            {
                case Direction.Left:
                    anim.Play("PlayerWalkLeft");
                    break;
                case Direction.Right:
                    anim.Play("PlayerWalkRight");
                    break;
                case Direction.Up:
                    anim.Play("PlayerWalkUp");
                    break;
                case Direction.Down:
                    anim.Play("PlayerWalkDown");
                    break;
            }
        }

        lastDirection = currentDirection;
	}

    void FixedUpdate()
    {
        if (currentDirection == Direction.Left)
        {
            this.transform.Translate(new Vector2(-moveSpeed * Time.deltaTime, 0f));
        }
        else if (currentDirection == Direction.Right)
        {
            this.transform.Translate(new Vector2(moveSpeed * Time.deltaTime, 0f));
        }
        else if (currentDirection == Direction.Up)
        {
            this.transform.Translate(new Vector2(0f, moveSpeed * Time.deltaTime));
        }
        else if (currentDirection == Direction.Down)
        {
            this.transform.Translate(new Vector2(0f, -moveSpeed * Time.deltaTime));
        }
    }    
}
