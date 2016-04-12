using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {
    public string Scene1, Scene2;
    public KeyPickup key;
    private bool _playerHasKey = false;

    void Awake()
    {
        GameObject keyObject = GameObject.Find("Key");
        if (keyObject != null)
            key = keyObject.GetComponent<KeyPickup>();
    }

    void Update()
    {
        if (key != null)
        {
            _playerHasKey = key.hasKey;

            if (_playerHasKey)
                Destroy(key.gameObject);
        }           
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            if (key == null)
                Application.LoadLevel(Scene2);
            else
            {
                if (_playerHasKey)
                    Application.LoadLevel(Scene2);
                else if (Scene1 != "")
                    Application.LoadLevel(Scene1);
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (key == null)
                Application.LoadLevel(Scene2);
            else
            {
                if (_playerHasKey)
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
                if (_playerHasKey)
                    Application.LoadLevel(Scene2);
                else if (Scene1 != "")
                    Application.LoadLevel(Scene1);
            }
        }
    }
}
