using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {
    
    private GameObject _dialoguePanel;
    private GameObject _cancelButton;
    private Text _textBox;
    private int _dialogueIndex = 0;
    private string[] _dialogueList;
    private TextAsset _currentTextfile;

    void Awake()
    {
        _dialoguePanel = this.transform.FindChild("Canvas").transform.FindChild("DialoguePanel").gameObject;
        _cancelButton = _dialoguePanel.transform.FindChild("CancelButton").gameObject;
        _dialoguePanel.SetActive(false);
    }   	
			
    public void StartDialogue(TextAsset textFile)
    {
        Time.timeScale = 0;
        _currentTextfile = textFile;

        string text = _currentTextfile.text;
        _dialogueList = text.Split('|');

        if (_currentTextfile.name == "Quit")
            EnableDialoguePanel(true);
        else
            EnableDialoguePanel(false);
        _dialogueIndex = 0;
        PrintToDialogueBox();
    }

    void Update()
    {
        if (_dialoguePanel.activeSelf && (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space)))
        {
            AdvanceDialogue();
        }
    }
    

    public void AdvanceDialogue()
    {
        _dialogueIndex++;
        if (_dialogueIndex >= _dialogueList.Length){
            if (_currentTextfile.name == "Quit")
            {
                Application.LoadLevel("MainMenu");
            }
            _dialoguePanel.SetActive(false);
            Time.timeScale = 1;
        }            
        else
            PrintToDialogueBox();
    }

    public void CancelDialogue()
    {
        _dialoguePanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void PrintToDialogueBox()
    {
        _textBox.text = _dialogueList[_dialogueIndex];
    }

    private void EnableDialoguePanel(bool withCancel=false)
    {        
        _dialoguePanel.SetActive(true);
        _textBox = _dialoguePanel.transform.FindChild("Text").GetComponent<Text>();
        _cancelButton.SetActive(withCancel);
    }
}