using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_player : MonoBehaviour
{
    //Basic sciprt taken from here : https://stackoverflow.com/questions/65816546/unity-camera-follows-player-script
    public Transform player;
    public int xpos;
    public int ypos;
    public int zpos;

    // Update is called once per frame
    void Update()
    {
        if(player!= null)
            transform.position = player.transform.position + new Vector3(xpos, ypos, zpos);
    }
}
