using UnityEngine;
using System.Collections;

public class GhostPirate : MonoBehaviour {
    public float speed = 1f;
    public bool isChasing = false;
    private GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

	void Update () {
        if (isChasing)
        {
            float step = speed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, step);
        }
	}
}
