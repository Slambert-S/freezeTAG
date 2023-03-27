using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seeker_investigation : MonoBehaviour
{
    public GameObject debugSeeker;
    public List<GameObject> listOfSeeker = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
       SeekerBT[]  potato = GameObject.Find("seekerList").transform.GetComponentsInChildren<SeekerBT>();

        foreach(SeekerBT n in potato)
        {
            listOfSeeker.Add(n.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void assigneSeekerToInvestigateCollectible( Vector3 destination)
    {
        node closestNode =findClosestNode.getClosestNode(destination);

        float distance = float.MaxValue;
        GameObject closestSeeker = listOfSeeker[0];
        float currentDistance = 0;
        foreach(GameObject seeker in listOfSeeker)
        {
            currentDistance = Vector3.Distance(destination, seeker.transform.position);

            if(currentDistance <= distance)
            {
                distance = currentDistance;
                closestSeeker = seeker;
            }
        }
        //To-Do addapt script to select the closest seeker

        closestSeeker.GetComponent<atwo_variable_reference>().nodeTrigger = closestNode;
    }
}
