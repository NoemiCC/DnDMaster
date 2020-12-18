using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFullscreen : MonoBehaviour
{
    bool fullScreen;

    public void SetFullScreen (bool isFullScreen) // Linkear con el menu de opciones
    {
        Screen.fullScreen = isFullScreen;
    }
}
