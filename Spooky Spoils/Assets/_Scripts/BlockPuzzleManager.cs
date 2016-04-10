using UnityEngine;
using System.Collections;

public class BlockPuzzleManager : MonoBehaviour {
    public float thresholdMs = 100f;
    public Texture leftEyeSpot, rightEyeSpot;
    private EyePositionDataComponent _eyePositionDataComponent;
    private Light _spotlight;
    private GameObject[] ghostCrates;
    private GameObject[] ghostPirates;
    private GameObject[] fakeCrates;
    private float _activatedRenderTime = 0f;
    private float _deactivatedRenderTime = 0f;

    void Awake()
    {
        _eyePositionDataComponent = this.GetComponent<EyePositionDataComponent>();
        _spotlight = GameObject.Find("Spotlight").GetComponent<Light>();
        ghostCrates = GameObject.FindGameObjectsWithTag("PirateVisible");
        ghostPirates = GameObject.FindGameObjectsWithTag("GhostPirate");
        fakeCrates = GameObject.FindGameObjectsWithTag("FakeCrate");
    }

    void Update()
    {
        EyeXEyePosition eyePosition = _eyePositionDataComponent.LastEyePosition;
        if (eyePosition != null)
        {            
            if (eyePosition.LeftEye.IsValid ^ eyePosition.RightEye.IsValid)
            {                
                _deactivatedRenderTime = 0f;
                _activatedRenderTime += Time.deltaTime;
                if (_activatedRenderTime >= (thresholdMs / 1000f))
                {
                    ToggleGhostPirates(true);
                    if (eyePosition.RightEye.IsValid)   //Right-eye is open
                    {                        
                        _spotlight.cookie = rightEyeSpot;
                        ToggleGhostCrates(true);
                    }
                    else if (eyePosition.LeftEye.IsValid)   //Left-eye is open
                    {
                        _spotlight.cookie = leftEyeSpot;
                        ToggleFakeCrates(true);
                    }
                }             
            }
            else
            {                          
                _activatedRenderTime = 0f;
                _deactivatedRenderTime += Time.deltaTime;
                if (_deactivatedRenderTime >= (thresholdMs / 1000f))
                {
                    _spotlight.cookie = null;
                    ToggleGhostCrates(false);
                    ToggleGhostPirates(false);
                    ToggleFakeCrates(false);
                }                    
            }
        }
    }

    private void ToggleGhostCrates(bool enabled){
        foreach (GameObject invisibleObject in ghostCrates)
        {
            invisibleObject.GetComponent<SpriteRenderer>().enabled = enabled;
        }
    }

    private void ToggleGhostPirates(bool enabled)
    {
        foreach (GameObject ghost in ghostPirates)
        {
            ghost.GetComponent<SpriteRenderer>().enabled = enabled;
            ghost.GetComponent<GhostPirate>().isChasing = enabled;
        }
    }

    private void ToggleFakeCrates(bool enabled)
    {
        foreach (GameObject crate in fakeCrates)
        {
            if (crate != null)
                crate.GetComponent<FakeCrate>().playerIsPirate = enabled;
        }
    }
}
