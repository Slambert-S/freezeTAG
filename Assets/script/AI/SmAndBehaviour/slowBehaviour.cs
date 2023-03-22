using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowBehaviour : humanBehaviourSM
{
    

    // Start is called before the first frame update
    void Start()
    {
    }

    void Awake()
    {

        
    }

    // Update is called once per frame
    void Update()
    {

        if(behaviourValue == null)
        {
            if (this.GetComponent<valueOfBehaviour>() != null)
                behaviourValue = this.GetComponent<valueOfBehaviour>();

            if (this.GetComponent<SteeringAgent>() != null)
            {
                _steeringAgentScript = behaviourValue._steeringAgentScript;
                valueForBeingClose = behaviourValue.valueForBeingClose;
            }
        }
        

        
    }

    public  override void   testingHineritance()
    {
        //Debug.Log("In slow Script");
    }

    public override Vector3 humanAction()
    {

        
        // Handle the error if all the file are not present whan called.
        if(behaviourValue == null)
        {
            return Vector3.zero;
        }
        

       //This section  take the the position of the object and his target , while the object is not close enuph to the target , it will move forward. 
       Vector3 distanceFromTarget = (_steeringAgentScript.transform.position - _steeringAgentScript.target.transform.position);
       if (base.testDistance(distanceFromTarget))
        {
          
            _steeringAgentScript.transform.position = _steeringAgentScript.target.transform.position;
        }
        else
        {
            // A, II , turn toward the the target , if the object if facing the targert then it can go toward it 
            Vector3 facingVector = _steeringAgentScript.target.transform.position - _steeringAgentScript.transform.position;
            if (Vector3.Dot(_steeringAgentScript.transform.forward, facingVector.normalized) < 0.99) 
            {
               
                Quaternion targetRotation = Quaternion.LookRotation(facingVector);

                // Smoothly rotate towards the target point.
                _steeringAgentScript.transform.rotation = Quaternion.Slerp(_steeringAgentScript.transform.rotation, targetRotation, 3f * Time.deltaTime);
                _steeringAgentScript.Velocity = Vector3.zero;
            }
            else
            {
                return _steeringAgentScript.seekScript.getSteering(1, _steeringAgentScript);

            }
            
            return Vector3.zero;

        }

        return Vector3.zero;
    }
}
