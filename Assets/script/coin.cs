using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    // Start is called before the first frame update
    public delegate void CoinCollected();
    public static event CoinCollected onCollectedCoin;
    public int index;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void coinCollected()
    {
        if(onCollectedCoin != null)
        {
            onCollectedCoin();
        }

        Destroy(this.gameObject);
    }

    public void atwo_coinCollected()
    {
        /* if (onCollectedCoin != null)
         {
             onCollectedCoin();
         }*/

        GameObject.Find("gameManger").GetComponent<seeker_investigation>().assigneSeekerToInvestigateCollectible(transform.position);
        GameObject.Find("gameManger").GetComponent<coinManager>().coinColected();

        Destroy(this.gameObject);
    }
}
