using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InnMenuSelect : MonoBehaviour
{
    Text moneyText;
    public GameObject money;
    // int moneyVal;

    void Start() {
        PlayerPrefs.SetFloat( "playerLife", 30 );
        PlayerPrefs.SetFloat( "enemyLife", 30 );
        PlayerPrefs.SetFloat( "minigameScore", 0 );
        PlayerPrefs.SetString("startingBattle", "true");

        // moneyVal = PlayerPrefs.GetInt("money", 0);

        // moneyText = money.GetComponent<Text>();
        // moneyText.text = "Dinero: $0"; // + moneyVal.ToString();
    }
    public void LoadScene( string sceneName ) {
        SceneManager.LoadScene( sceneName );
    }
}
