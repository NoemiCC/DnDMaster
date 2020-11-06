using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

public class CodeLock : MonoBehaviour
{
    int codeLength;
    int placeInCode;
    public string code;
    public string attemptedCode;
    public GameObject log;
    public Button button01;
    public Button button02;
    public Button button03;
    public Button button04;
    public Button button05;
    public Button button06;
    public Button button07;
    public Button button08;
    public Button button09;
    public List<GameObject> rows = new List<GameObject>();
    public List<GameObject> sprites = new List<GameObject>();

    private void Start() 
    {
        codeLength = code.Length;
        System.Random rnd = new System.Random();
        int number = 10;
        double floor = Math.Pow(number, codeLength-1);
        double roof = Math.Pow(number, codeLength);
        int randomCode  = rnd.Next(Convert.ToInt32(floor), Convert.ToInt32(roof-1));
        code = randomCode.ToString();
        Button btn01 = button01.GetComponent<Button>();
        Button btn02 = button02.GetComponent<Button>();
        Button btn03 = button03.GetComponent<Button>();
        Button btn04 = button04.GetComponent<Button>();
        Button btn05 = button05.GetComponent<Button>();
        Button btn06 = button06.GetComponent<Button>();
        Button btn07 = button07.GetComponent<Button>();
        Button btn08 = button08.GetComponent<Button>();
        Button btn09 = button09.GetComponent<Button>();
		btn01.onClick.AddListener(TaskOnClick);
        btn02.onClick.AddListener(TaskOnClick);
        btn03.onClick.AddListener(TaskOnClick);
        btn04.onClick.AddListener(TaskOnClick);
        btn05.onClick.AddListener(TaskOnClick);
        btn06.onClick.AddListener(TaskOnClick);
        btn07.onClick.AddListener(TaskOnClick);
        btn08.onClick.AddListener(TaskOnClick);
        btn09.onClick.AddListener(TaskOnClick);
        foreach (Transform child in log.transform)
        {
        rows.Add(child.gameObject);
        }
    }
	void TaskOnClick(){
        string name =  EventSystem.current.currentSelectedGameObject.name;
		SetValue(name);
	}

    void CheckCode()
    {
        if(attemptedCode == code)
        {
            Debug.Log("right code");
            CodeManager.instance.tries = 5;
            Open();
        }
        else
        {
            Debug.Log("wrong code");
            CodeManager.instance.tries -= 1;

            // Colorear runas 

            if(CodeManager.instance.tries <= 0)
            {
                Debug.Log("¡Perdiste!");
                // Terminar juego y volver a batalla
                CodeManager.instance.tries = 5;
                SceneManager.LoadScene("Campo_batalla");
            }
        }
    }

    void Open()
    {
        Debug.Log("Yeah!");
        PlayerPrefs.SetFloat( "minigameScore", 10 );
        SceneManager.LoadScene("Campo_batalla");
    }

    public void SetValue(string value)
    {
        GameObject row = rows[CodeManager.instance.tries-1];
        GameObject rune = row.transform.GetChild(placeInCode).gameObject;
        foreach (Transform child in log.transform)
        {
        rows.Add(child.gameObject);
        }
        SpriteRenderer spriteRenderer = rune.GetComponent<SpriteRenderer>();
        Debug.Log("place" + placeInCode);
        if(int.Parse(value) == 1)
        {
            if(value == Char.ToString(code[placeInCode]))
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite01Right);
            }else if(code.Contains(value))
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite01Search);
            }else 
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite01Wrong);               
            }

        }else if (int.Parse(value) == 2)
        {
            if(value == Char.ToString(code[placeInCode]))
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite02Right);
            }else if(code.Contains(value))
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite02Search);
            }else 
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite02Wrong);               
            }

        }else if (int.Parse(value) == 3)
        {
            if(value == Char.ToString(code[placeInCode]))
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite03Right);
            }else if(code.Contains(value))
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite03Search);
            }else 
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite03Wrong);               
            }
        }
        else if (int.Parse(value) == 4)
        {
            if(value == Char.ToString(code[placeInCode]))
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite04Right);
            }else if(code.Contains(value))
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite04Search);
            }else 
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite04Wrong);               
            }
        }
        else if (int.Parse(value) == 5)
        {
            if(value == Char.ToString(code[placeInCode]))
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite05Right);
            }else if(code.Contains(value))
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite05Search);
            }else 
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite05Wrong);               
            }
        }
        else if (int.Parse(value) == 6)
        {
            if(value == Char.ToString(code[placeInCode]))
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite06Right);
            }else if(code.Contains(value))
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite06Search);
            }else 
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite06Wrong);               
            }
        }
        else if (int.Parse(value) == 7)
        {
                    if(value == Char.ToString(code[placeInCode]))
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite07Right);
            }else if(code.Contains(value))
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite07Search);
            }else 
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite07Wrong);               
            }
        }
        else if (int.Parse(value) == 8)
        {
            if(value == Char.ToString(code[placeInCode]))
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite08Right);
            }else if(code.Contains(value))
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite08Search);
            }else 
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite08Wrong);               
            }
        }
        else if (int.Parse(value) == 9)
        {
            if(value == Char.ToString(code[placeInCode]))
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite09Right);
            }else if(code.Contains(value))
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite09Search);
            }else 
            {
                spriteRenderer.sprite = (rune.GetComponent<ChangeSprite>().sprite09Wrong);               
            }
        }
        placeInCode++;
        if(placeInCode <= codeLength)
        {
            attemptedCode += value;
        }

        if(placeInCode == codeLength)
        {
            CheckCode();
            attemptedCode = "";
            placeInCode = 0;  
        }
    }
}
