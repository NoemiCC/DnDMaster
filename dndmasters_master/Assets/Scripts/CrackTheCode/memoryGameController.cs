using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System;


public class memoryGameController : MonoBehaviour
{
    public int runes;
    public List<GameObject> rows = new List<GameObject>();
    public int selected = 0;
    void Start()
    {
        System.Random rnd = new System.Random();
        List<int> listNumbers = new List<int>();
        int number;
        for (int i = 0; i < runes/2; i++)
        {
            do 
            {
                number = rnd.Next(1, runes/2);
            } 
            while (listNumbers.Contains(number));
                listNumbers.Add(number);
                listNumbers.Add(number);
            }
        foreach (int num in listNumbers)
        {
            Debug.Log(num);
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
}