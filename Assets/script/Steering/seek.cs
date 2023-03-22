using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seek : MonoBehaviour
{
    // Start is called before the first frame update

    //private  Vector3 Velocity ;
// public GameObject target;
    //public float maxAccel;
  
    
void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

     //  this.transform.position +=  getSteering() * Time.deltaTime;
       // this.transform.rotation = faceForward() ;
    }

    public Vector3 getSteeringOld(GameObject target,Vector3 Velocity ,float maxSpeed ,float weight, SteeringAgent agent)
    {

      
        

        Vector3 absTargetToCharacter = AbsValueDistance.getAbsoluteDistance(target.transform.position, this.transform.position);
        
        Vector3 desiredVelocity = (target.transform.position - this.transform.position) ;


        //Debug.Log(desiredVelocity.x / absTargetToCharacter.x + " acceleration : "+ desiredVelocity.x + "   ABS : " + absTargetToCharacter.x);
       /*
        desiredVelocity.x = desiredVelocity.x / absTargetToCharacter.x;
        desiredVelocity.y = desiredVelocity.y / absTargetToCharacter.y;
        desiredVelocity.z = desiredVelocity.z / absTargetToCharacter.z;*/
        
        desiredVelocity = desiredVelocity * maxSpeed;

        Vector3 steering = desiredVelocity - Velocity;
        
        /*
        Velocity = Velocity + (steering * Time.deltaTime) ;
        Debug.Log("steering X  : " + steering.x+ "  Steering  Z : "+ steering.z);
        Velocity = Vector3.ClampMagnitude(Velocity, maxAccel);
        */
        return steering;



/*
        Vector3 testDesiredVelocity = target.transform.position - transform.position;
        testDesiredVelocity = testDesiredVelocity.normalized * maxAccel;
        Vector3 testSteering = testDesiredVelocity - Velocity;

        Velocity += testSteering * Time.deltaTime;
        Velocity = Vector3.ClampMagnitude(Velocity, maxAccel);
        return Velocity;
*/

    }


    public Vector3 getSteering( float weight, SteeringAgent agent)
    {

       
        Vector3 absTargetToCharacter = AbsValueDistance.getAbsoluteDistance(agent.target.transform.position, agent.transform.position);

        Vector3 desiredVelocity = (agent.target.transform.position - agent.transform.position);


        //Debug.Log(desiredVelocity.x / absTargetToCharacter.x + " acceleration : "+ desiredVelocity.x + "   ABS : " + absTargetToCharacter.x);
        /*
        desiredVelocity.x = desiredVelocity.x / absTargetToCharacter.x;
        desiredVelocity.y = desiredVelocity.y / absTargetToCharacter.y;
        desiredVelocity.z = desiredVelocity.z / absTargetToCharacter.z;
        */

        desiredVelocity = desiredVelocity.normalized * agent.maxSpeed;

        Vector3 steering = desiredVelocity  /*- agent.Velocity*/;

       
        return steering * weight;



     

    }

    public Vector3 getSteeringSpecificPoint(float weight, SteeringAgent agent, Vector3 pointToTarget, bool wall)
    {

        Vector3 newPoint = pointToTarget;
        if (wall)
        {
            newPoint *= 15;
        }

        Vector3 absTargetToCharacter = AbsValueDistance.getAbsoluteDistance(newPoint, agent.transform.position);

        Vector3 desiredVelocity = (newPoint - agent.transform.position);


        //Debug.Log(desiredVelocity.x / absTargetToCharacter.x + " acceleration : "+ desiredVelocity.x + "   ABS : " + absTargetToCharacter.x);

        /*
         *desiredVelocity.x = desiredVelocity.x / absTargetToCharacter.x;
        desiredVelocity.y = desiredVelocity.y / absTargetToCharacter.y;
        desiredVelocity.z = desiredVelocity.z / absTargetToCharacter.z;*/

        desiredVelocity = desiredVelocity.normalized * agent.maxSpeed;

        Vector3 steering = desiredVelocity /*- agent.Velocity*/;


        return steering*weight;





    }

    public Vector3 beaviourSeekWall(float weight, Vector3 pointToTarget, bhv_strg_agent behaviour, bool wall)
    {
        Vector3 newPoint = pointToTarget;
        if (wall)
        {
            //newPoint *= 20;
        }

        Vector3 desiredVelocity = (newPoint - behaviour.transform.position);
        desiredVelocity = desiredVelocity.normalized * behaviour.maxSpeed;

        Vector3 steering = desiredVelocity - behaviour.Velocity;


        return steering * weight;





    }
    public Vector3 beaviourSeek(float weight, Vector3 target, bhv_strg_agent behaviour, bool wall)
    {

        Vector3 desiredVelocity = (target - behaviour.transform.position);
        desiredVelocity = desiredVelocity.normalized * behaviour.maxSpeed;

        Vector3 steering = desiredVelocity - behaviour.Velocity ;


        return steering * weight;





    }

    public Vector3 getSteeringTemps(float weight, SteeringAgent agent)
    {

       
        Vector3 absTargetToCharacter = AbsValueDistance.getAbsoluteDistance(agent.tagTarget.transform.position, agent.transform.position);

        Vector3 desiredVelocity = (agent.tagTarget.transform.position - agent.transform.position);


        //Debug.Log(desiredVelocity.x / absTargetToCharacter.x + " acceleration : "+ desiredVelocity.x + "   ABS : " + absTargetToCharacter.x);
        /*
        desiredVelocity.x = desiredVelocity.x / absTargetToCharacter.x;
        desiredVelocity.y = desiredVelocity.y / absTargetToCharacter.y;
        desiredVelocity.z = desiredVelocity.z / absTargetToCharacter.z;
        */

        desiredVelocity = desiredVelocity.normalized * agent.maxSpeed;

        Vector3 steering = desiredVelocity /* - agent.Velocity*/;


        return steering * weight;





    }

    /*
    public Quaternion faceForward()
    {
        if(Velocity == Vector3.zero)
        {
            return transform.rotation;
        }

        return  Quaternion.LookRotation(Velocity);
    }*/
}
