using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public virtual void Stop()
    {
        Debug.Log("No Stop() written");
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public virtual void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
