using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

	public Text dialogueText;
	public GameObject characterMenu;
	public GameObject chatMenu;
	public GameObject dialogueBox;
	public GameObject finalMenu;
	public GameObject selectFirst_text;

	private Queue<string> sentences;
    
    // Start is called before the first frame update
    void Start()
    {
		sentences = new Queue<string>();
		if (Globals.start_welcome == 0)
		{
			dialogueBox.SetActive(true);
		}
		if (Globals.start_welcome == 1)
		{
			ShowAll();
			ShowCharacterMenu();
			ShowChatMenu();
			AllowButtons();
		}
    }

    public void SelectFirst()
    {

		if (Globals.characters_selected == 0)
    	{
    		selectFirst_text.SetActive(true);
    	}
    	else
    	{	
    		InnMenuSelect sn = gameObject.GetComponent<InnMenuSelect>();
			sn.LoadScene("Campo_batalla");
    	}
    }

    public void StartDialogue (Dialogue dialogue)
	{
		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{
		if (sentences.Count == 0)
		{
	        var prev_highlight = GameObject.Find("Canvas/UI_InnMenu_2/StoreButton/highlight");
			prev_highlight.SetActive(false);
			EndDialogue();
			return;
		}

		if (sentences.Count == 4)
		{
			ShowCharacterMenu();
	        var highlight = GameObject.Find("Canvas/UI_InnMenu_1/CharactersButton/highlight");
			highlight.SetActive(true);
		}

		if (sentences.Count == 3)
		{
			ShowChatMenu();
	        var prev_highlight = GameObject.Find("Canvas/UI_InnMenu_1/CharactersButton/highlight");
			prev_highlight.SetActive(false);
	        var highlight = GameObject.Find("Canvas/UI_InnMenu_1/ChatButton/highlight");
			highlight.SetActive(true);
		}


		if (sentences.Count == 2)
		{
	        var prev_highlight = GameObject.Find("Canvas/UI_InnMenu_1/ChatButton/highlight");
			prev_highlight.SetActive(false);
		}

		if (sentences.Count == 1)
		{
			dialogueText.fontSize = 12;
	        var highlight = GameObject.Find("Canvas/UI_InnMenu_2/StoreButton/highlight");
			highlight.SetActive(true);
		}

		string sentence = sentences.Dequeue();
		dialogueText.text = sentence;
	}

	void EndDialogue()
	{
		HideDialogueBox();
		ShowAll();
		AllowButtons();
	}

	public void ShowCharacterMenu()
	{
		characterMenu.SetActive(true);
	}

	public void ShowChatMenu()
	{
		chatMenu.SetActive(true);
	}

	public void HideDialogueBox()
	{
		dialogueBox.SetActive(false);
	}

	public void ShowAll()
	{
		finalMenu.SetActive(true);
	}

	public void AllowButtons()
	{
		Button characterButton = characterMenu.GetComponent<Button>();
		Button chatButton = chatMenu.GetComponent<Button>();
		// characterMenu;
		chatButton.interactable = !chatButton.interactable;
		characterButton.interactable = !characterButton.interactable;
	}
}
