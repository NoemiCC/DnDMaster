using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

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

    void Start()
    {
        state = BattleState.START;
        SetupBattle();
        
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos;

            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
         

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
