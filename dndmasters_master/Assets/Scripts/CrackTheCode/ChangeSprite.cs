using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public CodeLock codeLock;
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

    private SpriteRenderer spriteRenderer; 
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Change(GameObject btn)
    {
        spriteRenderer.sprite = sprite01;
    }
}
