using UnityEngine;
using System.Collections;

public class LevelEnd : MonoBehaviour {
    //public string filename;
    public TextAsset roomEnd;
    public Enemy[] enemies;
    private DialogueManager _dialogueManager;

    void Awake()
    {
        _dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Stop bosses
            foreach (Enemy enemyScript in enemies){
                enemyScript.Stop();
            }
            _dialogueManager.StartDialogue(roomEnd);
        }
    }
}
