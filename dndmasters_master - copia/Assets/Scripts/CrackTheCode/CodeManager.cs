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
        int gameMode = transform.parent.gameObject.GetComponent<GameSelector>().gameMode;
        instance = this;
        if(gameMode==0)
        {
        scoreText.text = "Quedan:"; 
        gameText.text = "Conjuración";
        }else if(gameMode==1)
        {
        scoreText.text = "Puntaje:"; 
        gameText.text = "Alquimia";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.parent.gameObject.GetComponent<GameSelector>().gameMode == 0)
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
                    }
                    scoreText.text = "Quedan: " + tries; 
                }
            
            }
            if(gameOver)
            {
                startPlaying = false;
                gameText.text = "Terminó el juego";
            }
        }


    }


}
