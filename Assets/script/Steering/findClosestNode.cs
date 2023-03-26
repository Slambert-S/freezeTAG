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
        
        int layerMask = 1 << 7;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
        foreach (node n in listOfNode)
        {

            RaycastHit hit;
            if (Physics.Raycast(agentPosition, n.transform.position - agentPosition, out hit, Mathf.Infinity, layerMask))
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


            }

        return closestNode;
    }

    
}
