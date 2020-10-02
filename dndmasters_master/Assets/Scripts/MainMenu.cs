using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public InputField nameInput;

    public void LoadScene( string sceneName ) {

        if ( nameInput.text != "" ) {
            PlayerPrefs.SetString( "username", nameInput.text );
    	    SceneManager.LoadScene( sceneName );
        } else {
            nameInput.text = "Necesitas nombre!!!";
        }
        
    }

    public void QuitGame()
    {
    	Debug.Log("Exit the Game");
    	Application.Quit();
    }
}
