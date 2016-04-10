using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {
    public string Scene;
	// Use this for initialization
	void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Application.LoadLevel(Scene);
        }
    }
}
