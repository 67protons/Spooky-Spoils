using UnityEngine;
using System.Collections;
using System.IO;

public class LockDoorDialogue : MonoBehaviour {
    private DialogueManager _dialogueManager;
    private TextAsset _lockedDoorsFile;

    void Awake()
    {        
        _dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        _lockedDoorsFile = Resources.Load("_Dialogues/Locked_Doors") as TextAsset;   
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {            
            _dialogueManager.StartDialogue(_lockedDoorsFile.text);
        }
    }
}
