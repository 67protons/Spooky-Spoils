using UnityEngine;
using System.Collections;

public class LeverTrigger : MonoBehaviour {
    public GameObject correspondingDoor;
    public Sprite oppositeDoor;
    public Sprite pressedPlate;

    private GazeAwareComponent _gazeAware;

    void Awake()
    {
        _gazeAware = this.GetComponent<GazeAwareComponent>();
    }

    void Update()
    {
        checkState();
    }
    void checkState()
    {
        if (_gazeAware.HasGaze)
        {
            this.GetComponent<SpriteRenderer>().enabled = true;
            this.GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            this.GetComponent<Collider2D>().enabled = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            correspondingDoor.GetComponent<Collider2D>().enabled = false;
            correspondingDoor.GetComponent<SpriteRenderer>().sprite = oppositeDoor;
            this.GetComponent<SpriteRenderer>().sprite = pressedPlate;
        }
    }
}
