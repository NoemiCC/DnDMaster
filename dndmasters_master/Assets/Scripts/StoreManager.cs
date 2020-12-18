using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
	private int money;
	private int object_value = 100;

	public static GameObject selectedobject;

	public static string[ ] storeItems = new string[ ]{"plantita", "velita", "planta", "escudo","libros","cuadro","espada"} ;

	string dummyString1;
	string dummyString2;

	// pages
	public int pagina_actual;
    public Text pageText;

    // Start is called before the first frame update
    void Start()
    {
    	pagina_actual = 1;
    	// PlayerPrefs.SetInt("money", 100);
        money = PlayerPrefs.GetInt("money");

        // RefreshCompras();
        MostrarCompras();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerPosition()
    {
        var panel = GameObject.Find("Canvas/StorePanel/ObjetosPanel");

        panel.SetActive(false);

        var room1 = GameObject.Find("Inn/room1/halo_room1");
        var room2 = GameObject.Find("Inn/room2/halo_room2");
        var room3 = GameObject.Find("Inn/room3/halo_room3");
        var room4 = GameObject.Find("Inn/room4/halo_room4");

        room1.SetActive(true);
        room2.SetActive(true);
        room3.SetActive(true);
        room4.SetActive(true);

        var b1 = GameObject.Find("Canvas/StorePanel/Botones");

        b1.SetActive(true);
    }

    public void SaveObjectRoom(int room)
    {
        PlayerPrefs.SetInt($"{selectedobject.name}_r{room}", 1);

        var show = GameObject.Find($"Inn/room{room}/{selectedobject.name}");
        show.SetActive(true);

        HideHalo();
    }

    public void CheckValue(GameObject sprite_object)
    {
        if (money > object_value)
        {
        	money = money - object_value;
        	PlayerPrefs.SetInt("money", money);

			// activar sprite ticket
        	var ok_image = sprite_object.transform.Find("Image").gameObject;
			ok_image.SetActive(true);

			// desactiva el boton del item para que no se pueda comprar denuevo
			sprite_object.GetComponent<Button>().interactable = false;
			
			selectedobject = sprite_object;
			
			TriggerPosition();
        }
		
		else
		{
			Debug.Log("Dinero insuficiente");
		}
    }

    void HideHalo()
    {
        var room1 = GameObject.Find("Inn/room1/halo_room1");
        var room2 = GameObject.Find("Inn/room2/halo_room2");
        var room3 = GameObject.Find("Inn/room3/halo_room3");
        var room4 = GameObject.Find("Inn/room4/halo_room4");

        room1.SetActive(false);
        room2.SetActive(false);
        room3.SetActive(false);
        room4.SetActive(false);
    }

    void MostrarCompras()
    {

        for (int i = 1; i <= 4; i++)
        {
        	for (int j = 0; j <= storeItems.Length-1; j++)
        	{
        		for (int k = 1; k <= 3; k++)
        		{
        			dummyString1 = $"Inn/room{i}/{storeItems[j]}{k}";
        			
        			if (PlayerPrefs.GetInt($"{storeItems[j]}{k}_r{i}") == 1)
        			{
        				var show = GameObject.Find(dummyString1);
        				show.SetActive(true);
        			}
        		}
        	}
        }

    }

    void RefreshCompras()
    {
        for (int i = 1; i <= 4; i++)
        {
        	for (int j = 0; j <= storeItems.Length-1; j++)
        	{
        		for (int k = 1; k <= 3; k++)
        		{
    				PlayerPrefs.DeleteKey($"{storeItems[j]}{k}_r{i}");
        		}
        	}
        }
    }

    public void AddPage(GameObject panel)
    {
    	if (pagina_actual < 4)
    	{
			pagina_actual += 1;
			
			var page1 = panel.transform.Find("Objetos").gameObject;
			var page2 = panel.transform.Find("Objetos_2").gameObject;
			var page3 = panel.transform.Find("Objetos_3").gameObject;
			var page4 = panel.transform.Find("Objetos_4").gameObject;
	    	
	    	if (pagina_actual == 2)
	    	{
				page1.SetActive(false);
				page2.SetActive(true);
	    	}

	    	else if (pagina_actual == 3)
	    	{
				page2.SetActive(false);
				page3.SetActive(true);
	    	}

	    	else if (pagina_actual == 4)
	    	{
				page3.SetActive(false);
				page4.SetActive(true);
	    	}
    	}
        pageText.text = "Pag " + pagina_actual;
    }

    public void MinusPage(GameObject panel)
    {
    	if (1 < pagina_actual)
    	{
			pagina_actual -= 1;
			
			var page1 = panel.transform.Find("Objetos").gameObject;
			var page2 = panel.transform.Find("Objetos_2").gameObject;
			var page3 = panel.transform.Find("Objetos_3").gameObject;
			var page4 = panel.transform.Find("Objetos_4").gameObject;
	    	
	    	if (pagina_actual == 1)
	    	{
				page1.SetActive(true);
				page2.SetActive(false);
	    	}
			
	    	else if (pagina_actual == 2)
	    	{
				page2.SetActive(true);
				page3.SetActive(false);
	    	}
			
	    	else if (pagina_actual == 3)
	    	{
				page3.SetActive(true);
				page4.SetActive(false);
	    	}
    	}
        pageText.text = "Pag " + pagina_actual;
    }
}
