using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CodeManager : MonoBehaviour
{
    public bool startPlaying;
    public static CodeManager instance;
    public bool gameOver = false;
    public int tries = 5;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameText;
    public GameObject instructions;
    void Start()
    {
        instance = this;
        scoreText.text = "Quedan:"; 
        gameText.text = "Crack the Code";
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(!gameOver)
            {
                if(Input.anyKeyDown)
                {
                    instructions.SetActive(false);
                    startPlaying = true;
                    gameText.text = "";
                    Debug.Log("Start");
                }
            }
        
        }
        if(gameOver)
        {
            startPlaying = false;
            gameText.text = "Terminó el juego";
        }
    }


}
