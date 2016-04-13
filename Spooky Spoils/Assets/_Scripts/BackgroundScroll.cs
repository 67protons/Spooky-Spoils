using UnityEngine;
using System.Collections;

public class BackgroundScroll : MonoBehaviour {
    public GameObject background1, background2;
    private Player _player;
	// Use this for initialization
	void Start () {
        this._player = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {

	}
}
