using UnityEngine;

public class OnHoverButton : MonoBehaviour
{
	public GameObject visibleObject;

	void Start()
	{
	    visibleObject.SetActive(false);
	}

    void OnMouseOver()
    {
	    visibleObject.SetActive(true);
    }

    void OnMouseExit()
    {
	    visibleObject.SetActive(false);
    }
}