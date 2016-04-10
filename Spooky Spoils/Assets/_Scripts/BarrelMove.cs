using UnityEngine;
using System.Collections;

public class BarrelMove : MonoBehaviour {

    private AudioSource audioClip;
    public bool isPushing;

    void Start()
    {
        audioClip = GetComponent<AudioSource>();
        isPushing = false;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioClip.Play();
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {
        audioClip.Stop();
    }


}
