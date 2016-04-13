using UnityEngine;
using System.Collections;

public class TreasureOpen : MonoBehaviour {
    public Sprite opened;
    private bool activated = false;
    private DialogueManager _dialogueManager;
    private TextAsset _chaseEnd;

    void Awake()
    {
        _dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        _chaseEnd = Resources.Load("_Dialogues/Chase_End") as TextAsset;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.GetComponent<SpriteRenderer>().sprite = opened;
            if (!activated)
                _dialogueManager.StartDialogue(_chaseEnd);
            activated = true;
        }            
    }
}
