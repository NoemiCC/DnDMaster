using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BulletController theBS;
    public static GameManager instance;

    public int notesLeft = 10;
    public bool gameOver = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameText;
    public GameObject instructions;
    void Start()
    {
        instance = this;
        scoreText.text = "Quedan: " + notesLeft;
        gameText.text = "Requiem";
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
                    theBS.hasStarted = true;
                    gameText.text = "";
                    theMusic.Play();
                }
            }
        
        }
        if(notesLeft <= 0)
        {
            startPlaying = false;
            theMusic.Stop();
            theBS.hasStarted = false;
            gameText.text = "GANASTE";
            PlayerPrefs.SetFloat( "minigameScore", 10 );
        }
    }

    public void NoteHit()
    {
        notesLeft -= 1;
        scoreText.text = "Quedan: " + notesLeft;
    }

    public void NoteMissed()
    {
        startPlaying = false;
        theMusic.Stop();
        theBS.hasStarted = false;
        gameText.text = "PERDISTE";
        gameOver = true;
    }
}
