﻿using UnityEngine;
using System.Collections;

public class LeverTrigger : HiddenInFog {
    public GameObject correspondingDoor;
    public Sprite oppositeDoor;
    public Sprite pressedPlate;

    void Start()
    {
        base.Start();
        this.GetComponent<Collider2D>().enabled = false;
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
        }
    }
}
