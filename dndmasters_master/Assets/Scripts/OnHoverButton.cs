using UnityEngine;
using TMPro;

public class OnHoverButton : MonoBehaviour
{
	public bool ifObject;
	public GameObject visibleObject;

	TMP_Text m_TextComponent;
	// Collider2D m_Collider;


	void Awake()
	{
		m_TextComponent = GetComponent<TMP_Text>();
		// m_Collider = GetComponent<Collider2D>();
	}

	void Start()
	{
		if (ifObject)
	    	visibleObject.SetActive(false);
	}

    void OnMouseOver()
    {
		if (ifObject)
			visibleObject.SetActive(true);
    }

    void OnMouseExit()
    {
		if (ifObject)
	    	visibleObject.SetActive(false);
    }

    public void FullScreenOk(bool ok_fullscreen)
    {
    	if (ok_fullscreen == true)
			m_TextComponent.color = Color.yellow;
		else
			m_TextComponent.color = Color.white;
    }
}