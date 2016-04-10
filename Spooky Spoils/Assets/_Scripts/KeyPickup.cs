using UnityEngine;
using System.Collections;

public class KeyPickup : MonoBehaviour {
    private GameObject Whitley;
	// Use this for initialization
	void Awake () {
        //if (Application.loadedLevel == 1)
        //    Whitley = GameObject.Find("Whitley");
	}
	
	// Update is called once per frame
	void Update () {
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (Application.loadedLevel == 1)
        //    Destroy(Whitley);
        PlayerPrefs.SetInt("keys", PlayerPrefs.GetInt("Keys")+1);
        Destroy(this.gameObject);
    }
}
