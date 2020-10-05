using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject gameCanvas;

    public GameObject endCanvas;
    public Text endTitle;
    public Text endPoints;

    Rigidbody2D rb;
    int points = 0;
    public int maxPoints = 5;

    Image timerBar;
    public float maxTime = 5f;
    float timeLeft;
    bool gameOver = false;
    

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start() {
        timerBar = GameObject.FindGameObjectWithTag("Timer").GetComponent<Image>();
        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButton(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.position = mousePos;
        }

        if (timeLeft > 0 && !gameOver) {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = timeLeft / maxTime;
        } else if (!gameOver) {
            gameCanvas.SetActive( false );
            endCanvas.SetActive( true );

            endTitle.text = "Se acabo el tiempo";
            endPoints.text += "0";
            gameOver = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Point" && !gameOver) {
            Destroy(collision.gameObject);
            points++;

            if (points >= maxPoints) {
                PlayerPrefs.SetFloat( "minigameScore", 10 );
                gameCanvas.SetActive( false );
                endCanvas.SetActive( true );

                endTitle.text = "Lo lograste!";
                endPoints.text += "10";
                gameOver = true;
            }

        } else if (collision.gameObject.tag == "Bad" && !gameOver) {
            gameCanvas.SetActive( false );
            endCanvas.SetActive( true );

            endTitle.text = "Has presionado un punto equivocado";
            endPoints.text += "0";
            gameOver = true;
        }
    }

}
