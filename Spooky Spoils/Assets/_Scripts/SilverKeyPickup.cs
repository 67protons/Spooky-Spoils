using UnityEngine;
using System.Collections;

public class SilverKeyPickup : KeyPickup
{
    private GameObject[] _invisibleBlocks;

    public override void Awake()
    {
        //base.Awake();
        _invisibleBlocks = GameObject.FindGameObjectsWithTag("PirateVisible");
    }

    public override void Update()
    {
        //base.Update();
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        foreach (GameObject invisBlock in _invisibleBlocks)
        {
            invisBlock.SetActive(false);
        }
    }
}
