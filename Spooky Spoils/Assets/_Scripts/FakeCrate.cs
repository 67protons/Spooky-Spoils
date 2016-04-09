using UnityEngine;
using System.Collections;

public class FakeCrate : HiddenInFog {
    public bool playerIsPirate = false;
    public override void Update()
    {
        //base.Update(); Purposefully override base
        //isBeingLookedAt = this.HasGaze;
        if (this.HasGaze && playerIsPirate)
            Disapear();
    }

    public void Disapear()
    {
        Destroy(this.gameObject);
    }
}
