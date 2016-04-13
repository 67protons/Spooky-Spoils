using UnityEngine;
using System.Collections;

public class LeverTrigger : MonoBehaviour {
    public GameObject correspondingDoor;
    public Sprite oppositeDoor;
    public Sprite pressedPlate;
    public bool returnScene = false;
    private AudioSource audioClip;
    private bool _activated = false;
    private GazeAwareComponent _gazeAware;
    private MouseAwareComponent _mouseAware;
    private bool HasGaze
    {
        get
        {
            return ((InputManager.tobiiOn && _gazeAware.HasGaze) || (!InputManager.tobiiOn && _mouseAware.HasMouse));
        }
    }

    void Awake()
    {
        if (InputManager.tobiiOn && this.returnScene)
        {
            this.gameObject.SetActive(false);
            this.correspondingDoor.GetComponent<SpriteRenderer>().sprite = oppositeDoor;
            this.correspondingDoor.GetComponent<Collider2D>().enabled = false;
        }
    }

    void Start()
    {
        _gazeAware = this.GetComponent<GazeAwareComponent>();
        _mouseAware = this.GetComponent<MouseAwareComponent>();
        this.GetComponent<Collider2D>().enabled = false;
        audioClip = GetComponent<AudioSource>();
    }

    void Update()
    {
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
            if (!this._activated)
                audioClip.PlayOneShot(audioClip.clip);
            _activated = true;
        }
    }
}
