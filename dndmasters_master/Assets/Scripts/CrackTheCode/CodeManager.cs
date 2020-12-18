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
    public int clicks = 0;
    public GameObject runes;
    public AudioSource music;

    void Start()
    {
        int gameMode = transform.parent.gameObject.GetComponent<GameSelector>().gameMode;
        instance = this;
        music.Play();
        StartCoroutine(FadeAudioSource.StartFade(music, 2, 0.65f));
        if(gameMode==0)
        {
        scoreText.text = "Quedan:"; 
        gameText.text = "Conjuración";
        gameInstructions.text = "Selecciona los íconos de la izquierda\npara formar combinaciones\n" +
                                "de 3 runas.\n\n Tu selección aparecerá\nen las piedras de la derecha.";

        }else if(gameMode==1)
        {
        scoreText.text = "Puntaje:"; 
        gameText.text = "Alquimia";
        gameInstructions.text = "Haz click en las runas\n para darlas vuelta.\n" + 
                                "¡Encuentra las parejas iguales para ganar!\n\n" + 
                                "Importante: jugar lento para evitar bugs.";
        }
    }

    // Update is called once per frame
    void Update()
    {
        int gameMode = transform.parent.gameObject.GetComponent<GameSelector>().gameMode;
        if(gameMode == 0)
        {
            if(!startPlaying)
            {
                if(!gameOver)
                {
                    if(Input.GetMouseButtonDown(0))
                    {
                        if(clicks==0) 
                        {
                            Debug.Log("mostrar las otras instrucciones");
                            clicks += 1;
                            gameInstructions.text = "¡Encuentra la secuencia correcta\nantes de que se acabe el tiempo!";
                            runes.SetActive(true);
                        }else if(clicks>=1)
                            {
                                instructions.SetActive(false);
                                startPlaying = true;
                                gameText.text = "";
                                runes.SetActive(true);
                            }
                    }

                }
                    scoreText.text = "Quedan: " + tries; 
            }
            
            if(gameOver)
            {
                startPlaying = false;
                StartCoroutine(FadeAudioSource.StartFade(music, 1, 0));
                gameText.text = "Terminó el juego";
            }
        }


    }
}
