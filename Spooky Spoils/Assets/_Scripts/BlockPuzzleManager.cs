using UnityEngine;
using System.Collections;

public class BlockPuzzleManager : MonoBehaviour {
    public float thresholdMs = 100f;
    private Texture originalEyeSpot;
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
        originalEyeSpot = _spotlight.GetComponent<Light>().cookie;
        ghostCrates = GameObject.FindGameObjectsWithTag("PirateVisible");
        ghostPirates = GameObject.FindGameObjectsWithTag("GhostPirate");
        fakeCrates = GameObject.FindGameObjectsWithTag("FakeCrate");        
    }

    void Update()
    {
        EyeXEyePosition eyePosition = _eyePositionDataComponent.LastEyePosition;
        if (eyePosition != null)
        {     
            if ((InputManager.tobiiOn && (eyePosition.LeftEye.IsValid ^ eyePosition.RightEye.IsValid)) || 
                (!InputManager.tobiiOn && (Input.GetKey(KeyCode.Mouse0) ^ Input.GetKey(KeyCode.Mouse1))))
            {                
                _deactivatedRenderTime = 0f;
                _activatedRenderTime += Time.deltaTime;
                if (_activatedRenderTime >= (thresholdMs / 1000f))
                {
                    ToggleGhostPirates(true);
                    if (eyePosition.RightEye.IsValid || Input.GetKey(KeyCode.Mouse0))   //Right-eye is open
                    {
                        _spotlight.cookie = rightEyeSpot;
                        ToggleGhostCrates(true);
                    }
                    if (eyePosition.LeftEye.IsValid || Input.GetKey(KeyCode.Mouse1))   //Left-eye is open
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
                    _spotlight.cookie = originalEyeSpot;
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
            if (ghost != null)
            {
                ghost.GetComponent<SpriteRenderer>().enabled = enabled;
                ghost.GetComponent<GhostPirate>().isChasing = enabled;
            }            
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
