using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MonkManager : MonoBehaviour
{
    public GameObject gameCanvas;
    public GameObject rulesCanvas;

    public GameObject endCanvas;

    bool startGame = false;

    // Start is called before the first frame update
    void Start() {
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
