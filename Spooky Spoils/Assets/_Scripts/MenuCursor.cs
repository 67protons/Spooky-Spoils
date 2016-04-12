using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuCursor : MonoBehaviour {

    public GameObject PlayButton;
    public GameObject ExitButton;
    private Vector3 playOffset;
    private Vector3 exitOffset;

	// Use this for initialization
	void Start () {
        playOffset = PlayButton.transform.position;
        exitOffset = ExitButton.transform.position;
        transform.position = playOffset;
    }
	
	// Update is called once per frame
	void Update ()
    {

        playOffset = PlayButton.transform.position;
        exitOffset = ExitButton.transform.position;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (transform.position == playOffset)
                Application.LoadLevel("Foyer1");
            if (transform.position == exitOffset)
                Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            this.transform.position =  playOffset;
            
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            this.transform.position = exitOffset;
        }

	}

    public void TobiiOn(bool activated)
    {
        InputManager.tobiiOn = activated;
    }
}
