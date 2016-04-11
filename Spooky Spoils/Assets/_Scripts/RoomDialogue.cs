using UnityEngine;
using System.Collections;

public class RoomDialogue : MonoBehaviour {
    public string roomBegin = "";    
    public string roomHint = "";
    private DialogueManager _dialogueManager;    

    void Awake()
    {
        _dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    void Start()
    {
        if (roomBegin != "")
            _dialogueManager.StartDialogue(roomBegin);   
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && roomHint != "")
        {
            _dialogueManager.StartDialogue(roomHint);
        }
    }
}
