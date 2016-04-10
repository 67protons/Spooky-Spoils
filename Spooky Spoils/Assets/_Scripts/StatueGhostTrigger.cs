using UnityEngine;
using System.Collections;

public class StatueGhostTrigger : MonoBehaviour {
    public GhostStatue owner;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            owner.activated = true;
        }
    }
}
