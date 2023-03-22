using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class findClosestNode : MonoBehaviour
{
     public static List<node> listOfNode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public static node getClosestNode( Vector3 agentPosition)
    {

        listOfNode = GameObject.Find("Node List").GetComponent<nodeSelection>().getListNode();

        float currentDistance = float.MaxValue;
        node closestNode = null;
        foreach (node n in listOfNode)
        {

            RaycastHit hit;
            if (Physics.Raycast(agentPosition, n.transform.position - agentPosition, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.GetComponentInParent<node>() != null)
                {
                    if (Vector3.Distance(agentPosition, n.transform.position) < currentDistance)
                    {
                        closestNode = n;
                        currentDistance = Vector3.Distance(agentPosition, n.transform.position);
                    }
                }
            }


                /*
                if (Physics.Linecast(agentPosition, n.transform.position))
                {
                    Debug.Log("blocked");
                }
                else
                {
                    if(Vector3.Distance(agentPosition,n.transform.position) < currentDistance)
                    {
                        closestNode = n;
                    }

                }*/


            }

        return closestNode;
    }

    
}
