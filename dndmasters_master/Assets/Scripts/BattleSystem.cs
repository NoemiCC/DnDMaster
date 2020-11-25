using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using Photon.Pun;

// Instancia a las unidades sobre el terreno, actualiza los valores del HUD y controla la batalla
public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{
    public BattleHUD battleHUD;
    public GameObject ally1prefab;
    public GameObject ally2prefab;
    public GameObject ally3prefab;
    public GameObject enemy1prefab;
    public GameObject enemy2prefab;
    public GameObject enemy3prefab;

    public Transform ally1Tile;
    public Transform ally2Tile;
    public Transform ally3Tile;
    public Transform enemy1Tile;
    public Transform enemy2Tile;
    public Transform enemy3Tile;

    Unit ally1Unit;
    Unit ally2Unit;
    Unit ally3Unit;
    Unit enemy1Unit;
    Unit enemy2Unit;
    Unit enemy3Unit;

    public BattleState state;

    float playerLife;
    float enemyLife;
    float myScore;
    float enemyScore;
    string startingBattle;
    int damage = 10;

    public GameObject selectCanvas;
    public GameObject hudCanvas;
    public GameObject lifeCanvas;
    public GameObject endCanvas;
    public GameObject waitCanvas;
    public Text selectText;
    public Text resultTxt;
    public Text pointsTxt;
    float maxLife = 30;
    int money;
    public GameObject pLifeBar;
    public GameObject eLifeBar;
    Image pLifeBarImage;
    Image eLifeBarImage;
    public PhotonView PV;


    void Start()
    {
        Globals.myTurn = !Globals.myTurn;
        // Debug.Log("Mi turno: " + Globals.myTurn);

        endCanvas.SetActive( false );
        lifeCanvas.SetActive( false );
        selectCanvas.SetActive( false );
        hudCanvas.SetActive( false );

        pLifeBarImage = pLifeBar.GetComponent<Image>();
        eLifeBarImage = eLifeBar.GetComponent<Image>();
    }
    void OnDestroy() {
        PlayerPrefs.SetFloat("enemyLife", enemyLife);
        PlayerPrefs.SetFloat("playerLife", playerLife);
        PlayerPrefs.SetFloat( "myScoreScore", -1 );
        PlayerPrefs.SetFloat( "enemyScore", -1 );
    }
    private void Update()
    {
        if (Globals.playerCount == 2) {
            SetUpGame();

            if (!endCanvas.activeSelf && (pLifeBarImage.fillAmount == 0 || eLifeBarImage.fillAmount == 0)) {
                if (pLifeBarImage.fillAmount == 0) {
                    resultTxt.text = "Que lastima, has perdido";
                    pointsTxt.text = "Has ganado $0";
                } else {
                    resultTxt.text = "Felicidades! Has ganado";
                    pointsTxt.text = "Has ganado $100";
                }

                money = PlayerPrefs.GetInt("money", 0);
                if (eLifeBarImage.fillAmount == 0) {
                    PlayerPrefs.SetInt("money", money + 100);
                }
                Debug.Log("Added money");

                endCanvas.SetActive( true );
                hudCanvas.SetActive( false );
                selectCanvas.SetActive( false );
            }

            if (Input.GetMouseButtonDown(0) && !endCanvas.activeSelf)
            {
                Vector3 mousePos;
                mousePos = Input.mousePosition;
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            }
        }
    }

    void SetUpGame() {
        if (!selectCanvas.activeSelf && !hudCanvas.activeSelf && !endCanvas.activeSelf) {
            waitCanvas.SetActive( false );
            lifeCanvas.SetActive( true );
            selectCanvas.SetActive( true );

            if (Globals.myTurn) {
                selectText.text = "Seleccione un Personaje";
            } else {
                selectText.text = "Es el turno de su oponente";
            }

            SetLifeBars();
            state = BattleState.START;
            SetupBattle();
        }
        
    }

    void SetLifeBars() {
        startingBattle = PlayerPrefs.GetString("startingBattle");
        myScore = PlayerPrefs.GetFloat("minigameScore", -1);
        enemyScore = PlayerPrefs.GetFloat("enemyScore", -1);

        if (startingBattle == "true") {
            PlayerPrefs.SetString("startingBattle", "false");
            playerLife = PlayerPrefs.GetFloat("playerLife");
            enemyLife = PlayerPrefs.GetFloat("enemyLife");

            pLifeBarImage.fillAmount = playerLife / maxLife;
            eLifeBarImage.fillAmount = enemyLife / maxLife;
        } else if (enemyScore == (float)-1 && myScore != -1) {
            hudCanvas.SetActive( false );
            selectCanvas.SetActive( false );
            waitCanvas.SetActive( true );
        } else if (myScore != -1 && enemyScore != -1) { // Cambiar las barras de vida
            waitCanvas.SetActive( false );
            selectCanvas.SetActive( true );

            if (myScore == enemyScore) {
                return;
            }
            else if (myScore > enemyScore) { // Yo gano
                if (Globals.myTurn) {
                    // Si es mi turno -> enemyLife -= damage
                    enemyLife = PlayerPrefs.GetFloat("enemyLife") - damage;
                    playerLife = PlayerPrefs.GetFloat("playerLife");
                } else {
                    // Si no es mi turno -> enemyLife -= damage
                    enemyLife = PlayerPrefs.GetFloat("enemyLife") - damage/2;
                    playerLife = PlayerPrefs.GetFloat("playerLife");
                }
            }
            else if (myScore < enemyScore) { // Yo pierdo
                if (Globals.myTurn) {
                    // Si es mi turno, yo gane -> playerLife -= damage/2
                    enemyLife = PlayerPrefs.GetFloat("enemyLife");
                    playerLife = PlayerPrefs.GetFloat("playerLife") - damage/(float)2;
                } else {
                    // Si no es mi turno, yo perdi -> playerLife -= damage/2
                    enemyLife = PlayerPrefs.GetFloat("enemyLife");
                    playerLife = PlayerPrefs.GetFloat("playerLife") - damage;
                }
            }

            pLifeBarImage.fillAmount = playerLife / maxLife;
            eLifeBarImage.fillAmount = enemyLife / maxLife;
        }
    }

    void SetupBattle() 
    {
        GameObject ally1GO = Instantiate(ally1prefab, ally1Tile);
        ally1Unit = ally1GO.GetComponent<Unit>();
        ally1GO.transform.position += Vector3.up*1;
        ally1Unit.GetComponent<ObjectClicker>().unitName = battleHUD.nameText;
        ally1Unit.GetComponent<ObjectClicker>().hability1 = battleHUD.hability1text;
        ally1Unit.GetComponent<ObjectClicker>().hability2 = battleHUD.hability2text;
        ally1Unit.GetComponent<ObjectClicker>().hability3 = battleHUD.hability3text;
        ally1Unit.GetComponent<ObjectClicker>().hability4 = battleHUD.hability4text;
        ally1Unit.GetComponent<ObjectClicker>().hudCanvas = hudCanvas;
        ally1Unit.GetComponent<ObjectClicker>().selectCanvas = selectCanvas;

        GameObject ally2GO = Instantiate(ally2prefab, ally2Tile);
        ally2Unit = ally2GO.GetComponent<Unit>();
        ally2GO.transform.position += Vector3.up * 1;
        ally2Unit.GetComponent<ObjectClicker>().unitName = battleHUD.nameText;
        ally2Unit.GetComponent<ObjectClicker>().hability1 = battleHUD.hability1text;
        ally2Unit.GetComponent<ObjectClicker>().hability2 = battleHUD.hability2text;
        ally2Unit.GetComponent<ObjectClicker>().hability3 = battleHUD.hability3text;
        ally2Unit.GetComponent<ObjectClicker>().hability4 = battleHUD.hability4text;
        ally2Unit.GetComponent<ObjectClicker>().hudCanvas = hudCanvas;
        ally2Unit.GetComponent<ObjectClicker>().selectCanvas = selectCanvas;


        GameObject ally3GO = Instantiate(ally3prefab, ally3Tile);
        ally3Unit = ally3GO.GetComponent<Unit>();
        ally3GO.transform.position += Vector3.up * 1;
        ally3Unit.GetComponent<ObjectClicker>().unitName = battleHUD.nameText;
        ally3Unit.GetComponent<ObjectClicker>().hability1 = battleHUD.hability1text;
        ally3Unit.GetComponent<ObjectClicker>().hability2 = battleHUD.hability2text;
        ally3Unit.GetComponent<ObjectClicker>().hability3 = battleHUD.hability3text;
        ally3Unit.GetComponent<ObjectClicker>().hability4 = battleHUD.hability4text;
        ally3Unit.GetComponent<ObjectClicker>().hudCanvas = hudCanvas;
        ally3Unit.GetComponent<ObjectClicker>().selectCanvas = selectCanvas;


        GameObject enemy1GO = Instantiate(enemy1prefab, enemy1Tile);
        enemy1Unit = enemy1GO.GetComponent<Unit>();
        enemy1GO.transform.position += Vector3.up * 1;
        enemy1Unit.GetComponent<ObjectClicker>().unitName = battleHUD.nameText;
        enemy1Unit.GetComponent<ObjectClicker>().hability1 = battleHUD.hability1text;
        enemy1Unit.GetComponent<ObjectClicker>().hability2 = battleHUD.hability2text;
        enemy1Unit.GetComponent<ObjectClicker>().hability3 = battleHUD.hability3text;
        enemy1Unit.GetComponent<ObjectClicker>().hability4 = battleHUD.hability4text;
        enemy1Unit.GetComponent<ObjectClicker>().hudCanvas = hudCanvas;
        enemy1Unit.GetComponent<ObjectClicker>().selectCanvas = selectCanvas;


        GameObject enemy2GO = Instantiate(enemy2prefab, enemy2Tile);
        enemy2Unit = enemy2GO.GetComponent<Unit>();
        enemy2GO.transform.position += Vector3.up * 1;
        enemy2Unit.GetComponent<ObjectClicker>().unitName = battleHUD.nameText;
        enemy2Unit.GetComponent<ObjectClicker>().hability1 = battleHUD.hability1text;
        enemy2Unit.GetComponent<ObjectClicker>().hability2 = battleHUD.hability2text;
        enemy2Unit.GetComponent<ObjectClicker>().hability3 = battleHUD.hability3text;
        enemy2Unit.GetComponent<ObjectClicker>().hability4 = battleHUD.hability4text;
        enemy2Unit.GetComponent<ObjectClicker>().hudCanvas = hudCanvas;
        enemy2Unit.GetComponent<ObjectClicker>().selectCanvas = selectCanvas;


        GameObject enemy3GO = Instantiate(enemy3prefab, enemy3Tile);
        enemy3Unit = enemy3GO.GetComponent<Unit>();
        enemy3GO.transform.position += Vector3.up * 1;
        enemy3Unit.GetComponent<ObjectClicker>().unitName = battleHUD.nameText;
        enemy3Unit.GetComponent<ObjectClicker>().hability1 = battleHUD.hability1text;
        enemy3Unit.GetComponent<ObjectClicker>().hability2 = battleHUD.hability2text;
        enemy3Unit.GetComponent<ObjectClicker>().hability3 = battleHUD.hability3text;
        enemy3Unit.GetComponent<ObjectClicker>().hability4 = battleHUD.hability4text;
        enemy3Unit.GetComponent<ObjectClicker>().hudCanvas = hudCanvas;
        enemy3Unit.GetComponent<ObjectClicker>().selectCanvas = selectCanvas;

    }

}
