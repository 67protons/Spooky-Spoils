using UnityEngine;
using System.Collections;

public class Blackbourne : MonoBehaviour {
    public int phase = 1;
    public GameObject projectile;
    public float shotFrequency;
    private float cooldownCounter;
    private GameObject _playerObject;

    void Awake()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        cooldownCounter = shotFrequency;
    }

    void Update()
    {
        if (phase == 1)
            ShootAtPlayer();
    }

    void ShootAtPlayer()
    {
        if (cooldownCounter <= 0)
        {
            Vector2 direction = _playerObject.transform.position - this.transform.position;
            GameObject newProjectile = (GameObject)Instantiate(projectile);
            newProjectile.GetComponent<Rigidbody2D>().AddForce(direction.normalized * 100f);
            Destroy(newProjectile, 10f);
            //Debug.Log(direction);
            cooldownCounter = shotFrequency;
        }
        else
        {
            cooldownCounter -= Time.deltaTime;
        }
    }
}
