using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {
    public string Scene;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Application.LoadLevel(Scene);
        }
    }

	void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Application.LoadLevel(Scene);
        }
    }
}
