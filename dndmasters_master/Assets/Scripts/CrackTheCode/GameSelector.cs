using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelector : MonoBehaviour
{
    public int gameMode = 0;
    public GameObject codeObject;
    public GameObject memoryObject;


    void Start() {
        gameMode = PlayerPrefs.GetInt("game", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameMode == 0)
        {
        codeObject.SetActive( true );
        memoryObject.SetActive( false );
        }else if(gameMode == 1)
        {
        codeObject.SetActive( false );
        memoryObject.SetActive( true ); 
        }
    }
}
