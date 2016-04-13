using UnityEngine;
using System.Collections;

public class FrontDoorQuit : MonoBehaviour {
    private DialogueManager _dialogueManager;
    private TextAsset _quitDialogue;

    void Awake()
    {
        _dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        _quitDialogue = Resources.Load("_Dialogues/Quit") as TextAsset;
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _dialogueManager.StartDialogue(_quitDialogue);
        }
    }
}
