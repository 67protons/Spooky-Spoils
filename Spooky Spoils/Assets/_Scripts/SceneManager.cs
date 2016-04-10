using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {
    public string Scene;
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Application.LoadLevel(Scene);
        }
    }
}
