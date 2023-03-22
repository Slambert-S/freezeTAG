using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class humanBehaviourSM : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] protected SteeringAgent _steeringAgentScript;
    protected valueOfBehaviour behaviourValue;
    protected  float valueForBeingClose;
    public float speedTreshhold = 11;
    public bool isFleeing = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (behaviourValue == null)
        {

            if (this.GetComponent<valueOfBehaviour>() != null)
                behaviourValue = this.GetComponent<valueOfBehaviour>();

            if (this.GetComponent<SteeringAgent>() != null)
            {
                _steeringAgentScript = behaviourValue._steeringAgentScript;
                valueForBeingClose = behaviourValue.valueForBeingClose;
            }
        }
        
        testSpeed();
        
    }

    public  virtual void testingHineritance()
    {
        Debug.Log("In master Script");
    }

    public  void testSpeed()
    {

        if (_steeringAgentScript.Velocity.magnitude < speedTreshhold)
        {
          //  Debug.Log("changed the behaviour state scripe to slow");
            _steeringAgentScript.stateBheaviour = this.gameObject.GetComponent<slowBehaviour>();
        }
        else
        {
            //To-Do add the fast behaviour script 

            //Debug.Log("changed the behaviour state scripe to slow");
            _steeringAgentScript.stateBheaviour = this.gameObject.GetComponent<fastBehaviour>();
        }
    }

    protected virtual bool testDistance(Vector3 distance)
    {

        //Debug.Log(distance.magnitude);
        //Debug.Log(this.valueForBeingClose);
        if (distance.magnitude < valueForBeingClose)
        {

            return true;
        }
        else
        {
            return false;
            //To-Do add the fast behaviour script 
        }
       
    }

    public virtual Vector3 humanAction()
    {
        return Vector3.zero;
    }

}
