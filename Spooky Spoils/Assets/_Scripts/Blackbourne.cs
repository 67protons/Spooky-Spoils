using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Blackbourne : Enemy {
    public Sprite angry;
    public int phase = 1;
    public GameObject projectile;
    public float shotFrequency;
    private float cooldownCounter;
    private GameObject _playerObject;
    private List<GameObject> _projectileList = new List<GameObject>();    

    void Awake()
    {
        _playerObject = GameObject.FindGameObjectWithTag("Player");
        cooldownCounter = shotFrequency;        
    }

    void Update()
    {
        if (phase == 1)
            ShootAtPlayer();
        else if (phase == 2)
            ChasePlayer();
    }

    void ShootAtPlayer()
    {
        if (cooldownCounter <= 0)
        {
            Vector2 direction = _playerObject.transform.position - this.transform.position;
            GameObject newProjectile = (GameObject)Instantiate(projectile);
            newProjectile.GetComponent<Rigidbody2D>().AddForce(direction.normalized * 100f);
            _projectileList.Add(newProjectile);
            Destroy(newProjectile, 10f);
            cooldownCounter = shotFrequency;
        }
        else
        {
            cooldownCounter -= Time.deltaTime;
        }
    }

    void ChasePlayer()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, _playerObject.transform.position, 1 * Time.deltaTime);
    }

    public override void Stop()
    {
        if (phase == 1)
        {
            foreach (GameObject projectile in _projectileList)
            {                
                if (projectile != null)
                {
                    Destroy(projectile);
                }
            }
            this.GetComponent<SpriteRenderer>().sprite = angry;
            phase = 2;
            this.GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
