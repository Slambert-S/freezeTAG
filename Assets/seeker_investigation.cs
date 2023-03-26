using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seeker_investigation : MonoBehaviour
{
    public GameObject debugSeeker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void assigneSeekerToInvestigateCollectible( Vector3 destination)
    {
        node closestNode =findClosestNode.getClosestNode(destination);
        //To-Do addapt script to select the closest seeker

        debugSeeker.GetComponent<atwo_variable_reference>().nodeTrigger = closestNode;
    }
}
