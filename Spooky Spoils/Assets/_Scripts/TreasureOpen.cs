using UnityEngine;
using System.Collections;

public class TreasureOpen : MonoBehaviour {
    public Sprite opened;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            this.GetComponent<SpriteRenderer>().sprite = opened;
    }
}
