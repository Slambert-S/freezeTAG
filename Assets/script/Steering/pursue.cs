using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pursue : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getSterring(float weight, SteeringAgent agent, Vector3 targetPoint)
    {


        float distance = Vector3.Distance(agent.transform.position, targetPoint);
        float ahead = distance / 10;
        Vector3 futurePosition = targetPoint + Vector3.zero * ahead;

        Vector3 steering = agent.seekScript.getSteeringSpecificPoint(weight,agent, futurePosition, false) - agent.Velocity;
        /*
        Velocity = Velocity + (steering * Time.deltaTime);
        Velocity = Vector3.ClampMagnitude(Velocity, maxAccel);
        */
        steering *= weight;
        return steering;
    }
}
