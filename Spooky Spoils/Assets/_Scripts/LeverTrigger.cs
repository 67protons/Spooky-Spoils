using UnityEngine;
using System.Collections;

public class LeverTrigger : HiddenInFog {
    public GameObject correspondingDoor;
    public Sprite oppositeDoor;
    public Sprite pressedPlate;
    private AudioSource audioClip;

    void Start()
    {
        base.Start();
        this.GetComponent<Collider2D>().enabled = false;
        audioClip = GetComponent<AudioSource>();
    }

    void Update()
    {
        base.Update();
        if (HasGaze)
        {
            this.GetComponent<Collider2D>().enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            correspondingDoor.GetComponent<Collider2D>().enabled = false;
            correspondingDoor.GetComponent<SpriteRenderer>().sprite = oppositeDoor;
            this.GetComponent<SpriteRenderer>().sprite = pressedPlate;
            audioClip.PlayOneShot(audioClip.clip);
        }
    }
}
