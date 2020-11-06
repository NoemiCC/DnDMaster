using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
	public GameObject monk;
	public GameObject witch;
	public GameObject bard;
	public GameObject selectFirst_text;
    private int activeCharacters = 0;
    
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
    void Update()
    {
        if (activeCharacters == 3)
        {
            FlagCharacters();
        }
    }

    public void FlagCharacters()
    {
     	Globals.characters_selected = 1;
		selectFirst_text.SetActive(false);
    }

    void ShowCharacters()
    {
		monk.SetActive(true);
		witch.SetActive(true);
		bard.SetActive(true);
    }

    // prende y apaga el sprite del heroe en el Inn
    public void CheckActive(GameObject sprite_object)
    {
        if (sprite_object.activeInHierarchy)
        {
            sprite_object.SetActive(false);
            if (sprite_object.name == "Monk" || sprite_object.name == "Bard" || sprite_object.name == "Witch")
            {
                activeCharacters -= 1;
                // Debug.Log("Ok unselected" + sprite_object.name);
            }
        }
        else
        {
            sprite_object.SetActive(true);
            if (sprite_object.name == "Monk" || sprite_object.name == "Bard" || sprite_object.name == "Witch")
            {
                activeCharacters += 1;
                //Debug.Log("Ok selected" + sprite_object.name);
            }
        }
    }
}
