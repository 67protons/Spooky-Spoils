using UnityEngine;
using System.Collections;

public class TreasureOpen : MonoBehaviour {
    public Sprite opened;
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
            _dialogueManager.StartDialogue(_chaseEnd);
        }            
    }
}
