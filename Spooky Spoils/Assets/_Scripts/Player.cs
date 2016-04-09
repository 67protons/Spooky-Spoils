using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float moveSpeed = 3f;
    private bool movingLeft, movingRight;
    private bool movingUp, movingDown;

	void Update () {
        //Horizontal Movement
        if (Input.GetKeyDown(KeyCode.A))
        {
            movingLeft = true;
            movingRight = false;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            movingLeft = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {            
            movingRight = true;
            movingLeft = false;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            movingRight = false;
        }

        //Vertical Movement
        if (Input.GetKeyDown(KeyCode.W))
        {
            movingUp = true;
            movingDown = false;
        }
        else if (Input.GetKeyUp(KeyCode.W))
        {
            movingUp = false;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            movingDown = true;
            movingUp = false;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            movingDown = false;
        }

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
}
