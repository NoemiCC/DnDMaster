using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
	public GameObject monk;
	public GameObject druid;
	public GameObject bard;
	public GameObject selectFirst_text;
    
    // Start is called before the first frame update
    void Start()
    {
		if (Globals.characters_selected == 1)
		{
			ShowCharacters();
    		selectFirst_text.SetActive(false);
		}
    }

    // Update is called once per frame
    public void FlagCharacters()
    {
     	Globals.characters_selected = 1;
		selectFirst_text.SetActive(false);
    }

    void ShowCharacters()
    {
		monk.SetActive(true);
		druid.SetActive(true);
		bard.SetActive(true);
    }
}
