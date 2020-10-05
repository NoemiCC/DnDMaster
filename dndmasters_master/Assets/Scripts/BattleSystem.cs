using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    float minigame;
    string startingBattle;

    public GameObject hudCanvas;
    public GameObject endCanvas;
    public Text resultTxt;
    public Text pointsTxt;
    float maxLife = 30;
    int money;
    public GameObject pLifeBar;
    public GameObject eLifeBar;
    Image pLifeBarImage;
    Image eLifeBarImage;


    void Start()
    {
        endCanvas.SetActive( false );
        hudCanvas.SetActive( true );
        SetLifeBars();

        state = BattleState.START;
        SetupBattle();
    }
    void OnDestroy() {
        PlayerPrefs.SetFloat("enemyLife", enemyLife);
        PlayerPrefs.SetFloat("playerLife", playerLife);
        PlayerPrefs.SetFloat( "minigameScore", 0 );
    }
    private void Update()
    {
        if (pLifeBarImage.fillAmount == 0 || eLifeBarImage.fillAmount == 0) {
            if (pLifeBarImage.fillAmount == 0) {
                resultTxt.text = "Que lastima, has perdido";
                pointsTxt.text = "Has ganado $0";
            } else {
                resultTxt.text = "Felicidades! Has ganado";
                pointsTxt.text += "Has ganado $100";
            }
            endCanvas.SetActive( true );
            hudCanvas.SetActive( false );
        }

        if (endCanvas.activeSelf && Input.anyKeyDown) {
            money = PlayerPrefs.GetInt("money", 0);
            if (eLifeBarImage.fillAmount == 0) {
                PlayerPrefs.SetInt("money", money + 100);
            }
            SceneManager.LoadScene("InnScene");
        }

        if (Input.GetMouseButtonDown(0) && !endCanvas.activeSelf)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        }
    }

    void SetLifeBars() {
        startingBattle = PlayerPrefs.GetString("startingBattle");
        minigame = PlayerPrefs.GetFloat("minigameScore");
        enemyLife = PlayerPrefs.GetFloat("enemyLife") - minigame;
        
        if (startingBattle == "true") {
            PlayerPrefs.SetString("startingBattle", "false");
            playerLife = PlayerPrefs.GetFloat("playerLife");
        } else {
            playerLife = PlayerPrefs.GetFloat("playerLife") - Random.Range (0, 2) * 10;
        }
        
        pLifeBarImage = pLifeBar.GetComponent<Image>();
        eLifeBarImage = eLifeBar.GetComponent<Image>();

        pLifeBarImage.fillAmount = playerLife / maxLife;
        eLifeBarImage.fillAmount = enemyLife / maxLife;
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

        GameObject ally2GO = Instantiate(ally2prefab, ally2Tile);
        ally2Unit = ally2GO.GetComponent<Unit>();
        ally2GO.transform.position += Vector3.up * 1;
        ally2Unit.GetComponent<ObjectClicker>().unitName = battleHUD.nameText;
        ally2Unit.GetComponent<ObjectClicker>().hability1 = battleHUD.hability1text;
        ally2Unit.GetComponent<ObjectClicker>().hability2 = battleHUD.hability2text;
        ally2Unit.GetComponent<ObjectClicker>().hability3 = battleHUD.hability3text;
        ally2Unit.GetComponent<ObjectClicker>().hability4 = battleHUD.hability4text;


        GameObject ally3GO = Instantiate(ally3prefab, ally3Tile);
        ally3Unit = ally3GO.GetComponent<Unit>();
        ally3GO.transform.position += Vector3.up * 1;
        ally3Unit.GetComponent<ObjectClicker>().unitName = battleHUD.nameText;
        ally3Unit.GetComponent<ObjectClicker>().hability1 = battleHUD.hability1text;
        ally3Unit.GetComponent<ObjectClicker>().hability2 = battleHUD.hability2text;
        ally3Unit.GetComponent<ObjectClicker>().hability3 = battleHUD.hability3text;
        ally3Unit.GetComponent<ObjectClicker>().hability4 = battleHUD.hability4text;


        GameObject enemy1GO = Instantiate(enemy1prefab, enemy1Tile);
        enemy1Unit = enemy1GO.GetComponent<Unit>();
        enemy1GO.transform.position += Vector3.up * 1;
        enemy1Unit.GetComponent<ObjectClicker>().unitName = battleHUD.nameText;
        enemy1Unit.GetComponent<ObjectClicker>().hability1 = battleHUD.hability1text;
        enemy1Unit.GetComponent<ObjectClicker>().hability2 = battleHUD.hability2text;
        enemy1Unit.GetComponent<ObjectClicker>().hability3 = battleHUD.hability3text;
        enemy1Unit.GetComponent<ObjectClicker>().hability4 = battleHUD.hability4text;


        GameObject enemy2GO = Instantiate(enemy2prefab, enemy2Tile);
        enemy2Unit = enemy2GO.GetComponent<Unit>();
        enemy2GO.transform.position += Vector3.up * 1;
        enemy2Unit.GetComponent<ObjectClicker>().unitName = battleHUD.nameText;
        enemy2Unit.GetComponent<ObjectClicker>().hability1 = battleHUD.hability1text;
        enemy2Unit.GetComponent<ObjectClicker>().hability2 = battleHUD.hability2text;
        enemy2Unit.GetComponent<ObjectClicker>().hability3 = battleHUD.hability3text;
        enemy2Unit.GetComponent<ObjectClicker>().hability4 = battleHUD.hability4text;


        GameObject enemy3GO = Instantiate(enemy3prefab, enemy3Tile);
        enemy3Unit = enemy3GO.GetComponent<Unit>();
        enemy3GO.transform.position += Vector3.up * 1;
        enemy3Unit.GetComponent<ObjectClicker>().unitName = battleHUD.nameText;
        enemy3Unit.GetComponent<ObjectClicker>().hability1 = battleHUD.hability1text;
        enemy3Unit.GetComponent<ObjectClicker>().hability2 = battleHUD.hability2text;
        enemy3Unit.GetComponent<ObjectClicker>().hability3 = battleHUD.hability3text;
        enemy3Unit.GetComponent<ObjectClicker>().hability4 = battleHUD.hability4text;

    }
}
