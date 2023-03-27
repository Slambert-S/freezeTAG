using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atwo_player_lastNode : MonoBehaviour
{
    // Start is called before the first frame update
    public List<node> listOfNode;
    public atwo_variable_reference _variableReference;
    void Start()
    {
        List<node> listOfPossibleNode = GameObject.Find("Node List").GetComponent<nodeSelection>().getListNode();
        listOfNode = listOfPossibleNode;
        StartCoroutine("DoCheck");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DoCheck()
    {
        do
        {

            node nearestNode = findClosestNode.getClosestNode(transform.position);
            if (nearestNode != null)
            {
                _variableReference.lastNode = nearestNode;
               
            }
            
            // execute block of code here
            yield return new WaitForSeconds(3);

        } while (true);
    }


}
