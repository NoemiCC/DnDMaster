using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Photon.Pun;


public class GameManager : MonoBehaviour
{
    public AudioSource music00;
    public AudioSource music01;
    public AudioSource failSound;

    public bool startPlaying;
    public BulletController notesController00;
    public BulletController notesController01;

    public static GameManager instance;

    public int notesLeft;
    // 0: requiem, 1:, 2:, 3:
    public int game = 0;

    public bool gameOver = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameText;

    public TextMeshProUGUI instructionsText;
    public GameObject instructions;
    public GameObject endCanvas;
    public GameObject noteHolder1;
    public GameObject noteHolder2;
    private int score = 0;

    public PhotonView PV;

    void Start()
    {
        instance = this;
        scoreText.text = "Score: " + score;
        gameText.text = "Requiem";
        endCanvas.SetActive( false );
    }

    // Update is called once per frame
    void Update()
    {
        if (endCanvas.activeSelf) {
            if (Input.anyKeyDown) {
                SceneManager.LoadScene("Campo_batalla");
            }
        } else {
            if(!startPlaying)
            {
                if(!gameOver)
                {
                    if(game==0)
                    {
                        gameText.text = "Requiem";
                        instructionsText.text = "¡Atrapa todas las notas musicales para ganar!";
                        notesLeft = 16;
                    } else if(game==1)
                    {
                        gameText.text = "Adaggio";
                        instructionsText.text = "¡Evade las notas musicales para ganar!";
                        notesLeft = 32;
                    }
                    noteHolder1.SetActive( false );
                    noteHolder2.SetActive( false );
                    if(Input.anyKeyDown)
                    {
                        instructions.SetActive(false);
                        startPlaying = true;
                        gameText.text = "";
                        if(game == 0)
                        {
                            music00.Play();
                            StartCoroutine(FadeAudioSource.StartFade(music00, 2, 0.65f));
                            noteHolder1.SetActive( true );
                            notesController00.hasStarted = true;
                        }
                        else if(game == 1)
                        {
                            music01.Play();
                            StartCoroutine(FadeAudioSource.StartFade(music01, 2, 0.65f));
                            noteHolder2.SetActive( true );
                            notesController01.hasStarted = true;
                        }
                    }
                }
            }
            if(notesLeft <= 0)
            {
                startPlaying = false;
                StartCoroutine(FadeAudioSource.StartFade(music00, 3, 0));
                StartCoroutine(FadeAudioSource.StartFade(music01, 3, 0));
                notesController00.hasStarted = false;
                notesController01.hasStarted = false;
                gameText.text = "Fin del juego";
                PlayerPrefs.SetFloat( "minigameScore", score);
                PV.RPC("UpdatePoints", RpcTarget.Others, (float)score);
                endCanvas.SetActive( true );
                noteHolder1.SetActive( false );
                noteHolder2.SetActive( false );
            }
        }
    }

    public void NoteHit()
    {
        // Debug.Log(notesLeft);
        notesLeft -= 1;
        if(game==0)
        {
            score += 1;
        } else if(game==1)
        {
            failSound.Play();
        }
        scoreText.text = "Score: " + score;
    }

    public void NoteMissed()
    {
        // Debug.Log(notesLeft);
        notesLeft -= 1;
        if(game==1)
        {
            score += 1;
        } else if(game==0)
        {
            failSound.Play();
        }
        scoreText.text = "Score: " + score;
    }
}
