using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atwo_evader_getCought : MonoBehaviour
{
    // Start is called before the first frame update
    public void getCought()
    {
        //call event for traking player
        GameObject.Find("gameManger").GetComponent<coinManager>().evaderGotCought();
        Destroy(this.gameObject);

    }
}
