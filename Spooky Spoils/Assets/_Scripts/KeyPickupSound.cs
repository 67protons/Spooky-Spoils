using UnityEngine;
using System.Collections;

public class KeyPickupSound : MonoBehaviour {

    private AudioSource audioClip;

	void Start ()
    {
        audioClip = GetComponent<AudioSource>();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //if(other.gameObject.tag == "Player")
        //{
        //    audioClip.PlayOneShot(audioClip.clip);
        //}
        if(other.gameObject.tag == "Key")
        {
            audioClip.PlayOneShot(audioClip.clip);
        }
    }
}
