using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> listOfCollectible = new List<GameObject>();
    public int trakinNumberCoin;
    public List<node> listOfNode;
    public GameObject coinListParent;
    public int nbCoin;
    public GameObject coinPrefab;
    public GameObject debugNode;

    public int finalScore = 0;
    void Start()
    {
        initialiseGame();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void initialiseGame()
    {
        List<node> listOfPossibleNode = GameObject.Find("Node List").GetComponent<nodeSelection>().getListNode();
        listOfNode = listOfPossibleNode;
        Debug.Log("Nuber of node in list :" + listOfNode.Count);
        StartCoroutine(createCollectible(2));
    }

    public GameObject assigneCollectible()
    {
        listOfCollectible.TrimExcess();
        int numberOfCollectibleLeft = GameObject.Find("coinList").transform.childCount;
       
        int selectedCollectible = 0;
        //Debug.Log("number of collectible :" + numberOfCollectibleLeft);
        if (numberOfCollectibleLeft >= 1)
        {
             selectedCollectible = Random.Range(0, numberOfCollectibleLeft - 1);
        }
        else if(numberOfCollectibleLeft == 0) {
            selectedCollectible = 0;
        }

        if(numberOfCollectibleLeft == 0)
        {
            return null;
        }
        return GameObject.Find("coinList").transform.GetChild(selectedCollectible).gameObject;
        
    }

    public void checkEndOfGame()
    {
        if(trakinNumberCoin <= 0)
        {
            this.GetComponent<endGame>().evaderWin(finalScore);
            
        }
    }

    public void evaderGotCought()
    {
        this.GetComponent<endGame>().evaderWin(finalScore);
    }

    public void coinColected()
    {
        trakinNumberCoin--;
        finalScore++;
        checkEndOfGame();
    }

    IEnumerator createCollectible(int secs)
    {
        yield return new WaitForSeconds(secs);
        for (int i = 0; i <= nbCoin; i++)
        {
            int selectedNode = Random.Range(0, listOfNode.Count - 1);
            Debug.Log(selectedNode);
            GameObject newCoin = Instantiate(coinPrefab, listOfNode[selectedNode].transform.position, Quaternion.identity, coinListParent.transform);
            newCoin.gameObject.name = "coin" + i;
            newCoin.GetComponent<coin>().index = i;
            listOfNode.RemoveAt(selectedNode);
            listOfCollectible.Add(newCoin);
        }
        trakinNumberCoin = nbCoin;
    }
}
