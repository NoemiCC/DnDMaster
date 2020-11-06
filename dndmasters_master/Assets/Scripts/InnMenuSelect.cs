using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InnMenuSelect : MonoBehaviour
{
    void Start() 
    {
        PlayerPrefs.SetFloat( "playerLife", 30 );
        PlayerPrefs.SetFloat( "enemyLife", 30 );
        PlayerPrefs.SetFloat( "minigameScore", -1 );
        PlayerPrefs.SetFloat( "enemyScore", -1 );
        PlayerPrefs.SetString("startingBattle", "true");
        PlayerPrefs.SetString("myTurn", "true");
    }

    public void LoadScene( string sceneName ) 
    {
        SceneManager.LoadScene( sceneName );
    }
}
