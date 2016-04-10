using UnityEngine;
using System.Collections;

public class KeyShards : MonoBehaviour{
    public GameObject correspondingKey;
    void Start()
    {
        this.GetComponent<Collider2D>().enabled = false;
    }

    void Update()
    {
        if (this.GetComponent<GazeAwareComponent>().HasGaze)
        {
            this.GetComponent<Collider2D>().enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (this.correspondingKey.gameObject != null)
                correspondingKey.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
