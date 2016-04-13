using UnityEngine;
using System.Collections;

public class LockDoorDialogue : MonoBehaviour {
    private DialogueManager _dialogueManager;

    void Awake()
    {
        _dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _dialogueManager.StartDialogue("Locked_Doors");
        }
    }
}
