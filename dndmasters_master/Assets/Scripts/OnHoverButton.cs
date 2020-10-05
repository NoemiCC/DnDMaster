using UnityEngine;

public class OnHoverButton : MonoBehaviour
{
	public GameObject arrowObject;

	void Start()
	{
	    arrowObject.SetActive(false);
	}

    void OnMouseOver()
    {
	    arrowObject.SetActive(true);
    }

    void OnMouseExit()
    {
	    arrowObject.SetActive(false);
    }
}