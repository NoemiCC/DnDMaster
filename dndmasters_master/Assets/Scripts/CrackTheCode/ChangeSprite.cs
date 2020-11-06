using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChangeSprite : MonoBehaviour
{
    public CodeLock codeLock;
    public Sprite sprite00;
    public Sprite sprite01;
    public Sprite sprite01Right;
    public Sprite sprite01Wrong;
    public Sprite sprite01Search;

    public Sprite sprite02;
    
    public Sprite sprite02Right;
    public Sprite sprite02Wrong;
    public Sprite sprite02Search;

    public Sprite sprite03;
    
    public Sprite sprite03Right;
    public Sprite sprite03Wrong;
    public Sprite sprite03Search;

    public Sprite sprite04;
    
    public Sprite sprite04Right;
    public Sprite sprite04Wrong;
    public Sprite sprite04Search;

    public Sprite sprite05;
    
    public Sprite sprite05Right;
    public Sprite sprite05Wrong;
    public Sprite sprite05Search;

    public Sprite sprite06;
    
    public Sprite sprite06Right;
    public Sprite sprite06Wrong;
    public Sprite sprite06Search;

    public Sprite sprite07;
    
    public Sprite sprite07Right;
    public Sprite sprite07Wrong;
    public Sprite sprite07Search;

    public Sprite sprite08;
    
    public Sprite sprite08Right;
    public Sprite sprite08Wrong;
    public Sprite sprite08Search;

    public Sprite sprite09;
    
    public Sprite sprite09Right;
    public Sprite sprite09Wrong;
    public Sprite sprite09Search;
    public List<Sprite> vainillaSprites = new List<Sprite>();

    public int memorySprite;

    private SpriteRenderer spriteRenderer; 
    void Start()
    {
        vainillaSprites.Add(sprite00);
        vainillaSprites.Add(sprite01);
        vainillaSprites.Add(sprite02);
        vainillaSprites.Add(sprite03);
        vainillaSprites.Add(sprite04);
        vainillaSprites.Add(sprite05);
        vainillaSprites.Add(sprite06);
        vainillaSprites.Add(sprite07);
        vainillaSprites.Add(sprite08);
        vainillaSprites.Add(sprite09);

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        int gameMode = transform.root.gameObject.GetComponent<GameSelector>().gameMode;
        if (gameMode == 1)
        {
            Debug.Log("flip!");
            if (transform.parent.transform.parent.gameObject.GetComponent<memoryGameController>().selected >= 2)
            {
                // Agregar checkeo de igualdad
                transform.parent.transform.parent.gameObject.GetComponent<memoryGameController>().selected = 0;
                spriteRenderer.sprite = vainillaSprites[0];

            }else {
            transform.parent.transform.parent.gameObject.GetComponent<memoryGameController>().selected += 1;
            Debug.Log("memory sprite: " + memorySprite);
            spriteRenderer.sprite = vainillaSprites[memorySprite];
            }
        }
    }  

}
