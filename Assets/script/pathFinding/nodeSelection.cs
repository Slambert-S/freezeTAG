using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodeSelection : MonoBehaviour
{
    private List<node> listOfNode = new List<node>();
    int nbOfNode;
    int selectedNode = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (node n in Object.FindObjectsOfType<node>())
        {
            listOfNode.Add(n);

        }

         nbOfNode = listOfNode.Count;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<node> getListNode()
    {
        return listOfNode;
    }

    // Find and return a random node in the list
    public node getRandomNode()
    {
      
        if(nbOfNode > 0)
        {
            selectedNode = Random.Range(0, nbOfNode);
        }
        else
        {
            return null;
        }

        return listOfNode[selectedNode];
        
    }

    //if flee = true  then we are seeking a node farther away from the enemy
    public node getRandomObjectiveNode(Vector3 currentPosition  ,Vector3 enemyPosition, bool flee)
    {
        List<node> listOfValideNode = new List<node>();
        //Debug.Log("In get list of random node");
        foreach (node n in listOfNode)
        {
            float agentDistance = Vector3.Distance(n.transform.position , currentPosition);
            float enemyDistance = Vector3.Distance(n.transform.position , enemyPosition);
            if(flee)
            {
                if (agentDistance < enemyDistance)
                {
                    listOfValideNode.Add(n);
                }
            }
            
           

        }

        if (listOfValideNode.Count > 0)
        {
            //Debug.Log("in listOfValidNode");
            
            selectedNode = Random.Range(0, (listOfValideNode.Count)-1);
        }
        else
        {
            return getRandomNode();
        }

        return listOfValideNode[selectedNode];

    }

}
