using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    private GameObject _dialoguePanel;
    private Text _textBox;
    private int _dialogueIndex = 0;
    private string[] _dialogueList;

    void Awake()
    {
        _dialoguePanel = this.transform.FindChild("Canvas").transform.FindChild("DialoguePanel").gameObject;
        _dialoguePanel.SetActive(false);
    }
    
	void Start () {
        StartDialogue("test.txt");       
	}
			
    public void StartDialogue(string filename)
    {
        _dialogueList = File.ReadAllText("Assets\\_Dialogues\\" + filename).Split('|');        
        EnableDialoguePanel();
        _dialogueIndex = 0;
        PrintToDialogueBox();
    }
    

    public void AdvanceDialogue()
    {
        _dialogueIndex++;
        if (_dialogueIndex >= _dialogueList.Length)
            _dialoguePanel.SetActive(false);
        else
            PrintToDialogueBox();
    }

    private void PrintToDialogueBox()
    {
        _textBox.text = _dialogueList[_dialogueIndex];
    }

    private void EnableDialoguePanel()
    {        
        _dialoguePanel.SetActive(true);
        _textBox = _dialoguePanel.transform.FindChild("Text").GetComponent<Text>();
    }
}