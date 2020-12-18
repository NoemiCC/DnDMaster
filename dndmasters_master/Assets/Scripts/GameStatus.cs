using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatus : MonoBehaviour
{
    public int level = 1;
    public int coins = 0;
    public bool beginner = true;

    Text moneyText;
    Text storeMoneyText;
    Text userText;
    public GameObject money;
    public GameObject storeMoney;
    public GameObject userName;

    public AudioSource innMusic;

    // Start is called before the first frame update
    void Start()
    {
        //LoadPlayer();
        innMusic.Play();
        StartCoroutine(FadeAudioSource.StartFade(innMusic, 1, 0.1f));
    }

    void Update()
    {
        ChangeCoins();
        ChangeUserName();
    }

	public void SavePlayer ()
	{
		SaveSystem.SavePlayer(this);
	}

	// decidir cuando cargar partida.
    public void LoadPlayer ()
	{
		PlayerData data = SaveSystem.LoadPlayer();

		level = data.level;
    	coins = data.coins;
    	beginner = data.beginner;
	}

    public void ChangeCoins ()
    {
        moneyText = money.GetComponent<Text>();
        moneyText.text = "Dinero: $" + PlayerPrefs.GetInt("money");
        storeMoneyText = storeMoney.GetComponent<Text>();
        storeMoneyText.text = "$" + PlayerPrefs.GetInt("money");
    }

    public void ChangeUserName ()
    {
        userText = userName.GetComponent<Text>();
        userText.text = "Usuario: " + PlayerPrefs.GetString("username", "Anon");
    }
}
