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
        //PlayPosition = new Vector3(61.4f,-79.5f,0.0f);
        //ExitPosition = new Vector3(61.4f, -140.4f,0.0f);
        //PlayPosition = Camera.main.WorldToViewportPoint(PlayPosition);
        //ExitPosition = Camera.main.WorldToViewportPoint(ExitPosition);
        playOffset = PlayButton.transform.position;
        exitOffset = ExitButton.transform.position;
        playOffset.x += 65.0f;
        exitOffset.x += 65.0f;
        transform.position = playOffset;
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.W))
        {
            this.transform.position = playOffset;
            
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            this.transform.position = exitOffset;
        }

        if(Input.GetKeyDown(KeyCode.Return) && transform.position == playOffset)
            Application.LoadLevel("Foyer1");
        if (Input.GetKeyDown(KeyCode.Return) && transform.position == exitOffset)
            Application.Quit();
	}
}
