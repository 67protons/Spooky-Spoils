using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {
    public string Scene1, Scene2;
    public KeyPickup key;

    void Awake()
    {
        GameObject keyObject = GameObject.Find("Key");
        if (keyObject != null)
            key = keyObject.GetComponent<KeyPickup>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            if (key == null)
                Application.LoadLevel(Scene2);
            else
            {
                if (key.hasKey)
                    Application.LoadLevel(Scene2);
                else if (Scene1 != "")
                    Application.LoadLevel(Scene1);
            }
        }
    }

	void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (key == null)
                Application.LoadLevel(Scene2);
            else
            {
                if (key.hasKey)
                    Application.LoadLevel(Scene2);
                else
                    Application.LoadLevel(Scene1);
            }
        }
    }
}
