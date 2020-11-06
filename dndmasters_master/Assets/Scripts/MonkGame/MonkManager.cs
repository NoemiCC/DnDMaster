using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MonkManager : MonoBehaviour
{
    public GameObject gameCanvas0;
    public GameObject gameCanvas1;
    public GameObject gameCanvas2;
    public GameObject gameCanvas3;

    public GameObject Titulo;

    public GameObject rulesCanvas;

    public GameObject endCanvas;

    GameObject gameCanvas;
    bool startGame = false;

    int game = 0;

    // Start is called before the first frame update
    void Start() {
        game = PlayerPrefs.GetInt("game", 0);
        
        if (game == 0) {
            gameCanvas1.SetActive( false );
            gameCanvas2.SetActive( false );
            gameCanvas3.SetActive( false );
            gameCanvas = gameCanvas0;
            Titulo.GetComponent<Text>().text = "Bloqueo de Chi";
        } else if (game == 1) {
            gameCanvas0.SetActive( false );
            gameCanvas2.SetActive( false );
            gameCanvas3.SetActive( false );
            gameCanvas = gameCanvas1;
            Titulo.GetComponent<Text>().text = "Meditar";
        } else if (game == 2) {
            gameCanvas0.SetActive( false );
            gameCanvas1.SetActive( false );
            gameCanvas3.SetActive( false );
            gameCanvas = gameCanvas2;
            Titulo.GetComponent<Text>().text = "Patada alta";
        } else if (game == 3) {
            gameCanvas0.SetActive( false );
            gameCanvas1.SetActive( false );
            gameCanvas2.SetActive( false );
            gameCanvas = gameCanvas3;
            Titulo.GetComponent<Text>().text = "Velocidad extrema";
        }
        
        gameCanvas.SetActive( false );
        rulesCanvas.SetActive( true );
        endCanvas.SetActive( false );
    }

    // Update is called once per frame
    void Update() {
        if (!startGame && Input.anyKeyDown) {
            startGame = true;
            gameCanvas.SetActive( true );
            rulesCanvas.SetActive( false );
        }

        if (endCanvas.activeSelf && Input.anyKeyDown) {
            SceneManager.LoadScene("Campo_batalla");
        }
    }
}
