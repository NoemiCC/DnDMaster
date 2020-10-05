using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public CodeLock codeLock;
    public Sprite sprite01;
    public Sprite sprite02;
    public Sprite sprite03;
    public Sprite sprite04;
    public Sprite sprite05;
    public Sprite sprite06;
    public Sprite sprite07;
    public Sprite sprite08;
    public Sprite sprite09;
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
