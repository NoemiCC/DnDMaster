﻿using System.Collections;
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
            //nameInput.text = "¡Necesitas un nombre!";
            StartCoroutine(UserErrorCoroutine());
        }
        
    }

    public void QuitGame()
    {
    	Application.Quit();
    }

    IEnumerator UserErrorCoroutine()
    {
        nameInput.text = "¡Necesitas un nombre!";
        yield return new WaitForSeconds(1);
        nameInput.text = "";
    }
}
