using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;

	public void TriggerDialogue ()
	{
		if (Globals.start_welcome == 0)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		}

		// FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
		
		Globals.start_welcome = Globals.start_welcome = 1;
	}

}