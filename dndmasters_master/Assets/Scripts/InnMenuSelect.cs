using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InnMenuSelect : MonoBehaviour
{
    void Start() {
        PlayerPrefs.SetFloat( "playerLife", 30 );
        PlayerPrefs.SetFloat( "enemyLife", 30 );
        PlayerPrefs.SetFloat( "minigameScore", 0 );
        PlayerPrefs.SetString("startingBattle", "true");
    }
    public void LoadScene( string sceneName ) {
        SceneManager.LoadScene( sceneName );
    }
}
