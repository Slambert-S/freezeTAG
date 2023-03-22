using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class createObject : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject seekerModel;
    public GameObject evaderModel;
    public GameObject coinPrefab;

    public string coinRoomName;
    public Text roomNumber;

    public bool canCreatToken = true;
    public bool firstTokenWasSpown = false;
    public bool gameFinished = false;

    public List<SteeringAgent> listOfNewSeeker = new List<SteeringAgent>();
    public List<SteeringAgent> listOfAllAgent = new List<SteeringAgent>();
    public SteeringAgent currentCoinSeeker = null;
    private static List<node> listOfNode;

    public  List<coinNode> lisOfCoinNode = new List<coinNode>();


    void Start()
    {
        initialiseGame();

    }
    private void OnEnable()
    {
        coin.onCollectedCoin += creatNewToken;
        pointKeepink.stopCreatingCoin += finishGame;
    }

    private void OnDisable()
    {
        coin.onCollectedCoin -= creatNewToken;
        pointKeepink.stopCreatingCoin -= finishGame;

    }

    void Update()
    {
        if (canCreatToken == true && firstTokenWasSpown == false)
        {
            //Create new token
            firstTokenWasSpown = true;
            creatNewToken();
        }    
    }



    public void createNewObject(Vector3 position, Quaternion rotation, int typeOfObject)
    {
        GameObject newAgent = null;
        if (typeOfObject == 0)
        {
             newAgent =Instantiate(seekerModel, position, rotation);

            listOfNewSeeker.Add(newAgent.GetComponent<SteeringAgent>());
            if(firstTokenWasSpown == false)
            {
                if(listOfNewSeeker.Count >1)
                    canCreatToken = true;
            }
        }
        if (typeOfObject == 1)
        {
            newAgent = Instantiate(evaderModel, position, rotation);
        }

        listOfAllAgent.Add(newAgent.GetComponent<SteeringAgent>());
    }

    public void creatNewToken()
    {

        if (currentCoinSeeker != null)
        {
            currentCoinSeeker.gameObject.transform.Find("Rig").Find("Bone").Find("VikingHelmet").transform.localScale = Vector3.one;
            currentCoinSeeker.GetComponent<SteeringAgent>().huntingCoin = false;
        }
        if (gameFinished ==false)
        {
            Debug.Log("New token created");
            int selectedRoom = Random.Range(0, lisOfCoinNode.Count - 1);
            GameObject newCoin = Instantiate(coinPrefab, lisOfCoinNode[selectedRoom].transform.position, Quaternion.identity);
            coinRoomName = lisOfCoinNode[selectedRoom].roomName;

            int selectedSeeker = Random.Range(0, listOfNewSeeker.Count);
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<SteeringAgent>().coinTarget = newCoin;
                listOfNewSeeker[selectedSeeker].GetComponent<SteeringAgent>().getAssigneCoin(newCoin);
                currentCoinSeeker = listOfNewSeeker[selectedSeeker];
            }
            
        }
        roomNumber.text = "Coin in room : " + coinRoomName;




    }

    private void finishGame()
    {
        gameFinished = true;
    }

    private void initialiseGame()
    {
        foreach (coinNode n in GameObject.Find("coinNodeList").GetComponentsInChildren<coinNode>())
        {
            lisOfCoinNode.Add(n);

        }

        // nbOfNode = listOfNode.Count;
        
        listOfNode = GameObject.Find("Node List").GetComponent<nodeSelection>().getListNode();
        int nbNode = listOfNode.Count;
        for (int i  = 0; i< 12; i++)
        {
            node n = listOfNode[Random.Range(0, nbNode)];

            createNewObject(n.transform.position, Quaternion.identity, 1);
        }

        StartCoroutine(creatFristSeeker(5));


    }

    IEnumerator creatFristSeeker(int secs)
    {
        
        yield return new WaitForSeconds(secs);

        int randomIndex = Random.Range(0, listOfAllAgent.Count-1);

        createNewObject(listOfAllAgent[randomIndex].transform.position, listOfAllAgent[randomIndex].transform.rotation, 0);
        GameObject.Destroy(listOfAllAgent[randomIndex].gameObject);

        if(randomIndex < listOfAllAgent.Count - 1)
        {
            createNewObject(listOfAllAgent[randomIndex + 1].transform.position, listOfAllAgent[randomIndex + 1].transform.rotation, 0);
            GameObject.Destroy(listOfAllAgent[randomIndex + 1].gameObject);
        }
        else
        {
            createNewObject(listOfAllAgent[randomIndex - 1].transform.position, listOfAllAgent[randomIndex + 1].transform.rotation, 0);
            GameObject.Destroy(listOfAllAgent[randomIndex - 1].gameObject);
        }
        
        //gameObject.SetActive(false);

    }
}
