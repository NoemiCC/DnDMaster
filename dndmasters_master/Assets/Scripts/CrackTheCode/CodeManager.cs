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
    public TextMeshProUGUI gameInstructions;

    void Start()
    {
        int gameMode = transform.parent.gameObject.GetComponent<GameSelector>().gameMode;
        instance = this;
        if(gameMode==0)
        {
        scoreText.text = "Quedan:"; 
        gameText.text = "Conjuración";
        gameInstructions.text = "Haz click en runas de la izquierda\n para probar combinaciones.\n" + 
                                "El color de la runa seleccionada\nte indicará si acertaste, fallaste\n o estás cerca.\n\n" +
                                "Descifra el código para ganar!";

        }else if(gameMode==1)
        {
        scoreText.text = "Puntaje:"; 
        gameText.text = "Alquimia";
        gameInstructions.text = "Haz click en las runas\n para darlas vuelta.\n" + 
                                "¡Encuentra las parejas para ganar!\n\n" + 
                                "Importante: jugar lento para evitar bugs.";
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
