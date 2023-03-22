using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetControl : MonoBehaviour
{
    // Start is called before the first frame update

   

    public List<SteeringAgent> listFrozenAgent;
    
    void Start()
    {
        listFrozenAgent = new List<SteeringAgent>();
    }

    // Update is called once per frame
    public void addToListFrozenAgent( SteeringAgent newAgent)
    {
       
        listFrozenAgent.Add(newAgent);
    }

    public void removeFromListFrozenAgent(SteeringAgent newAgent)
    {
        int indexToRemove = listFrozenAgent.IndexOf(newAgent, 0);
        listFrozenAgent.RemoveAt(indexToRemove);

    }

    public SteeringAgent getUnfreezeTarget()
    {
        SteeringAgent newTarget = null;
        if(listFrozenAgent.Count > 0)
        {
            int index ;
            if(listFrozenAgent.Count == 1)
            {
                index = 0;
            }
            else
            {
                index = Random.Range(0, listFrozenAgent.Count);
            }

            newTarget = listFrozenAgent[index];

        }
        //Debug.Log(newTarget);

        return newTarget;
    }
}
