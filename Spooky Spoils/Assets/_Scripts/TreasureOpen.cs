using UnityEngine;
using System.Collections;

public class TreasureOpen : MonoBehaviour {
    public Sprite opened;
    private DialogueManager _dialogueManager;

    void Awake()
    {
        _dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.GetComponent<SpriteRenderer>().sprite = opened;
            _dialogueManager.StartDialogue("Chase_End");
        }            
    }
}
