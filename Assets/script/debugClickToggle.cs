using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugClickToggle : MonoBehaviour
{
    // Start is called before the first frame update
    public node nearestNode;
    public node TargetNode;
    public List<node> pathFindingList = new List<node>();
    public createObject refCreateObject;
    public List<int> listInt = new List<int>();
    void Start()
    {
        listInt.Add(1);
        listInt.Add(2);
        listInt.Add(3);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKey(KeyCode.C))
        {
            Debug.Log("Before remove  value : " + listInt[0] + "  Count value :" + listInt.Count);
            listInt.RemoveAt(0);
            Debug.Log("After remove  value : " + listInt[0] + "  Count value :" + listInt.Count);


            //  seeker.gameObject.GetComponent<SteeringAgent>().getAssigneCoin(coinObject);
            //nearestNode = findClosestNode.getClosestNode(this.transform.position);
            //TargetNode = GameObject.Find("Node List").GetComponent<nodeSelection>().getRandomNode();
            //pathFindingList = GameObject.Find("Node List").GetComponent<pathFinding>().findPath(nearestNode, TargetNode);

        }*/
    }
}
