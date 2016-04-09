using UnityEngine;
using System.Collections;

public class BlockPuzzleManager : MonoBehaviour {
    public float thresholdMs = 100f;
    private EyePositionDataComponent _eyePositionDataComponent;
    private GameObject[] pirateVisibles;
    private float _activatedRenderTime = 0f;
    private float _deactivatedRenderTime = 0f;

    void Awake()
    {
        _eyePositionDataComponent = this.GetComponent<EyePositionDataComponent>();
        pirateVisibles = GameObject.FindGameObjectsWithTag("PirateVisible");
    }

    void Update()
    {
        EyeXEyePosition eyePosition = _eyePositionDataComponent.LastEyePosition;
        if (eyePosition != null)
        {
            Debug.Log(eyePosition.LeftEye.IsValid ^ eyePosition.RightEye.IsValid);
            if (eyePosition.LeftEye.IsValid ^ eyePosition.RightEye.IsValid)
            {
                //Reveal every object in our list
                _deactivatedRenderTime = 0f;
                _activatedRenderTime += Time.deltaTime;
                if (_activatedRenderTime >= (thresholdMs / 1000f))
                    TogglePirateVisibleRenderer(true);
            }
            else
            {
                //Deactivate every object                
                _activatedRenderTime = 0f;
                _deactivatedRenderTime += Time.deltaTime;
                if (_deactivatedRenderTime >= (thresholdMs / 1000f))
                    TogglePirateVisibleRenderer(false);         
            }
        }
    }

    private void TogglePirateVisibleRenderer(bool enabled){
        foreach (GameObject invisibleObject in pirateVisibles)
        {
            invisibleObject.GetComponent<SpriteRenderer>().enabled = enabled;
        }
    }
}
