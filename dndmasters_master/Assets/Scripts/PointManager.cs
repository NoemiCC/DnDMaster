using UnityEngine;
using Photon.Pun;

public class PointManager : MonoBehaviourPunCallbacks
{
    [PunRPC]
    void UpdatePoints(float points) {
        PlayerPrefs.SetFloat( "enemyScore", points );
    }
}
