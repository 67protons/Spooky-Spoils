using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuCursor : MonoBehaviour {

    public GameObject PlayButton;
    public GameObject ExitButton;
    private bool PlayBool = false;
    private Vector3 playOffset;
    private Vector3 exitOffset;

	// Use this for initialization
	void Start () {
        playOffset = PlayButton.transform.position;
        exitOffset = ExitButton.transform.position;
        transform.position = playOffset;
        PlayBool = true;
    }
	
	// Update is called once per frame
	void Update ()
    {

        playOffset = PlayButton.transform.position;
        exitOffset = ExitButton.transform.position;



        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.instance.PlaySFX(SoundManager.instance.sfxClips[0]);
            if (PlayBool)
                Application.LoadLevel("Foyer1");
            if (!PlayBool)
            {
                Debug.Log("Quit");
                Application.Quit();
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            PlayBool = true;
            this.transform.position =  playOffset;
            SoundManager.instance.PlaySFX(SoundManager.instance.sfxClips[1]);
            
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            PlayBool = false;
            this.transform.position = exitOffset;
            SoundManager.instance.PlaySFX(SoundManager.instance.sfxClips[1]);
        }

	}
}
