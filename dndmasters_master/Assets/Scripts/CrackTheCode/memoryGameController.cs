using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Photon.Pun;


public class memoryGameController : MonoBehaviour
{
    public int runes;
    public int score = 0;
    public PhotonView PV;

    public List<GameObject> rows = new List<GameObject>();
    public int selected = 0;
    public List<GameObject> runesSelected = new List<GameObject>();
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameText;
    public GameObject instructions;
    public CodeManager uiController;

    void Start()
    {
        scoreText.text = "Puntaje:"; 
        gameText.text = "Alquimia";
        System.Random rnd = new System.Random();
        List<int> listNumbers = new List<int>();
        int number;
        for (int i = 0; i < runes/2; i++)
        {
            do 
            {
                number = rnd.Next(1, (runes/2) + 1);
            } 
            while (listNumbers.Contains(number));
                listNumbers.Add(number);
                listNumbers.Add(number);
            }

        foreach (Transform child in gameObject.transform)
        {   
            rows.Add(child.gameObject);
            foreach (Transform rune in child.transform)
            {
                int r = listNumbers[rnd.Next(listNumbers.Count)];
                listNumbers.Remove(r);
                rune.gameObject.GetComponent<ChangeSprite>().memorySprite = r;
            }
        }
    }

        private void Update() {
            if(Input.GetMouseButtonDown(0))
                {
                    instructions.SetActive(false);
                    gameText.text = "";
                }
                scoreText.text = "Puntaje: " + score; 
        }
        public IEnumerator checkEqual()
    {
        Debug.Log("Serán iguales?");
        ChangeSprite runeScript0 = runesSelected[0].GetComponent<ChangeSprite>();
        ChangeSprite runeScript1 = runesSelected[1].GetComponent<ChangeSprite>();
        if(runeScript0.memorySprite == runeScript1.memorySprite)
        {
            Debug.Log("Son iguales!!!");
            runeScript0.GetComponent<SpriteRenderer>().sprite = runeScript0.rightSprites[runeScript0.memorySprite - 1];
            runeScript1.GetComponent<SpriteRenderer>().sprite = runeScript1.rightSprites[runeScript1.memorySprite - 1];
            runesSelected[0].GetComponent<BoxCollider2D>().enabled = false;
            runesSelected[1].GetComponent<BoxCollider2D>().enabled = false;
            score += 1;
            if(score == runes/2)
            {
                gameText.text = "Terminó el juego";
                PlayerPrefs.SetFloat( "minigameScore", score );
                PV.RPC("UpdatePoints", RpcTarget.Others, score);
                SceneManager.LoadScene("Campo_batalla");
            }
        }else {
            Debug.Log("No son iguales D:");
            yield return new WaitForSeconds(0.7f);
            Debug.Log("asdasd");
            runeScript0.GetComponent<SpriteRenderer>().sprite = runeScript0.vainillaSprites[0];
            runeScript1.GetComponent<SpriteRenderer>().sprite = runeScript1.vainillaSprites[0];
        }
        selected = 0;
        runesSelected.Clear();

    }
    public void go()
    {
        StartCoroutine(checkEqual());
    }
}