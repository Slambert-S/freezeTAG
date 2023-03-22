using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fastBehaviour : humanBehaviourSM
{
    public int raydistance;
    public float coneAngle;
    public bool goingToLastKnownPos = false;
    public float anglePercent;
    private float weight = 2;
    // Start is called before the first frame update
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

                anglePercent = coneAngle /100;
            }

        }

        //testRaycast();




    }

    public override Vector3 humanAction()
    {

        if (_steeringAgentScript.isEvader())
        {
            return evaderBehaviour();
        }
        else
        {
            return seekerBehaviour();
        }
        //If spotted the tag target in raycast
        

    }

    private bool testRaycast()
    {
       // Debug.Log("inTestRaycast");
        if (behaviourValue == null)
        {
            return  false;
        }

        float speedDependentConeAngle = (_steeringAgentScript.Velocity.magnitude / _steeringAgentScript.maxSpeed) * 100;

        speedDependentConeAngle = 100 - speedDependentConeAngle;
      
        if(speedDependentConeAngle < 16)
        {
            speedDependentConeAngle = 16;
        }
        return  GetComponentInChildren<coneOfView>().checkInConeOfView(speedDependentConeAngle);

        


    }

    //Will call a function to get a new path of node if the currnt one is empty
    private void seekerWander()
    {
        _steeringAgentScript.checkPathFinding();

    }

    private void evadePath()
    {
       // Debug.Log("in evadePath");
        _steeringAgentScript.GetPathFindingEvade();
    }

    private Vector3 seekerBehaviour()
    {

        //Debug.Log("In seeker");
        if (testRaycast())
        {
            if (_steeringAgentScript.wandering == false)
            {
               
                //error handeling if the current target was removed from the game
                
                if(_steeringAgentScript.tagTarget == null)
                {
                    _steeringAgentScript.wandering = true;
                    return Vector3.zero;
                }
                else//move toward target and turn
                {
                    Vector3 facingVector = (_steeringAgentScript.tagTarget.transform.position - _steeringAgentScript.transform.position).normalized;
                    Quaternion targetRotation = Quaternion.LookRotation(facingVector);

                    if (Vector3.Distance(_steeringAgentScript.transform.position, _steeringAgentScript.tagTarget.transform.position) < 1)
                    {
                        // GameObject.Destroy(_steeringAgentScript.tagTarget.gameObject);
                        //  Object.FindObjectOfType<createObject>().createNewObject(_steeringAgentScript.transform.position, _steeringAgentScript.transform.rotation, 0);
                        _steeringAgentScript.tagTarget.GetComponent<freeze>().getFreezed();

                        _steeringAgentScript.tagTarget = null;
                        _steeringAgentScript.wandering = true;
                        return Vector3.zero;
                    }
                    // Smoothly rotate towards the target point.
                    _steeringAgentScript.transform.rotation = Quaternion.Slerp(_steeringAgentScript.transform.rotation, targetRotation, 10f * Time.deltaTime);
                    return _steeringAgentScript.pursueScript.getSterring(weight, _steeringAgentScript, _steeringAgentScript.tagTarget.transform.position);//change for pursue
                }
               
            }
            else
            {
                //Debug.Log("In looking for target");
                //move toward target and turn
                Vector3 facingVector = _steeringAgentScript.target.transform.position - _steeringAgentScript.transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(facingVector);
                _steeringAgentScript.wandering = false;

                // Smoothly rotate towards the target point.
                _steeringAgentScript.transform.rotation = Quaternion.Slerp(_steeringAgentScript.transform.rotation, targetRotation, 3f * Time.deltaTime);
                return _steeringAgentScript.arrivecript.getSterring(weight, _steeringAgentScript);//change for pursue
            }

        }
        else //Did not spot the target
        {
            if (_steeringAgentScript.wandering)
            {
               // Debug.Log("No target wondering");
                //Keep wandering
                seekerWander();
                
                Vector3 facingVector = _steeringAgentScript.target.transform.position - _steeringAgentScript.transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(facingVector);

                // Smoothly rotate towards the target point.
                _steeringAgentScript.transform.rotation = Quaternion.Slerp(_steeringAgentScript.transform.rotation, targetRotation, 3f * Time.deltaTime);
                return _steeringAgentScript.arrivecript.getSterring(weight, _steeringAgentScript);//change for pursue
            }
            else
            {
                if (_steeringAgentScript.huntingCoin)
                {
                    if(_steeringAgentScript.lastNode == _steeringAgentScript.coinNode)
                    {
                        //Seek coin
                        Vector3 facingVector = (_steeringAgentScript.coinTarget.transform.position - _steeringAgentScript.transform.position).normalized; 
                        Quaternion targetRotation = Quaternion.LookRotation(facingVector);
                        _steeringAgentScript.target = _steeringAgentScript.coinTarget;
                        Debug.Log("Looking for da coin");
                        if (Vector3.Distance(_steeringAgentScript.transform.position, _steeringAgentScript.coinTarget.transform.position) < 1)
                        {
                            // GameObject.Destroy(_steeringAgentScript.tagTarget.gameObject);
                            //  Object.FindObjectOfType<createObject>().createNewObject(_steeringAgentScript.transform.position, _steeringAgentScript.transform.rotation, 0);
                            _steeringAgentScript.coinTarget.SetActive(false);

                            _steeringAgentScript.coinTarget = null;
                            _steeringAgentScript.wandering = true;
                            _steeringAgentScript.coinNode = null;
                            _steeringAgentScript.huntingCoin = false;
                            return Vector3.zero;
                        }
                        // Smoothly rotate towards the target point.
                        _steeringAgentScript.transform.rotation = Quaternion.Slerp(_steeringAgentScript.transform.rotation, targetRotation, 10f * Time.deltaTime);
                        return _steeringAgentScript.pursueScript.getSterring(weight, _steeringAgentScript, _steeringAgentScript.coinTarget.transform.position);//change for pursue
                    }
                    else
                    {
                        return moveTotargetPoint();
                    }
                }
                else
                {
                    // Seek last known node
                    if (_steeringAgentScript.lastNode == _steeringAgentScript.targetLastknownNode)
                    {
                        _steeringAgentScript.wandering = true;
                        seekerWander();
                        return _steeringAgentScript.arrivecript.getSterring(weight, _steeringAgentScript);//change for pursue
                    }
                    else
                    {
                        if (goingToLastKnownPos)
                        {
                            //Rotate toward next node
                            Vector3 facingVector = _steeringAgentScript.targetLastknownNode.transform.position - _steeringAgentScript.transform.position;
                            Quaternion targetRotation = Quaternion.LookRotation(facingVector);

                            // Smoothly rotate towards the target point.
                            _steeringAgentScript.transform.rotation = Quaternion.Slerp(_steeringAgentScript.transform.rotation, targetRotation, 3f * Time.deltaTime);
                            return _steeringAgentScript.arrivecript.getSterring(weight, _steeringAgentScript);//change for pursue
                        }
                        else
                        {
                            //get new list of node
                            _steeringAgentScript.getNewPath(_steeringAgentScript.lastNode, _steeringAgentScript.targetLastknownNode);
                            _steeringAgentScript.transform.rotation = _steeringAgentScript.faceForward(_steeringAgentScript);
                            return _steeringAgentScript.arrivecript.getSterring(weight, _steeringAgentScript);//change for pursue

                        }
                    }
                }

               
               

            }
            // _steeringAgentScript.Velocity = Vector3.zero;

        }
        return Vector3.zero;


       
    }

    private Vector3 evaderBehaviour()
    {
        //do i see a seeker
        if (testRaycast())
        {
            if (!_steeringAgentScript.wandering)
            {
                /*
                //move toward target and turn
                Vector3 facingVector = _steeringAgentScript.target.transform.position - _steeringAgentScript.transform.position;
                Quaternion targetRotation = Quaternion.LookRotation(facingVector);

                // Smoothly rotate towards the target point.
                _steeringAgentScript.transform.rotation = Quaternion.Slerp(_steeringAgentScript.transform.rotation, targetRotation, 3f * Time.deltaTime);
                return _steeringAgentScript.seekScript.getSteering(4, _steeringAgentScript);
                */

                // Toogle if fleeing 
                //Debug.Log("I am suppose to see a seeker");
               /* if(isFleeing == true)
                {
                    evadePath();
                    return moveTotargetPoint();
                }*/

                return moveTotargetPoint();

            }else
            {
                Debug.Log("potato");
                return moveTotargetPoint();
            }

        }
        else //Did not spot the target
        {
            if (_steeringAgentScript.wandering)
            {
                //Keep wandering
                seekerWander();


                return moveTotargetPoint()
;
            }
            else // The evader is fleeing or chasing a goal
            {

                if (isFleeing)
                {
                    //To-Do check if i arrived at destination
                    if(_steeringAgentScript.pathFindingList.Count > 0)
                    {
                        seekerWander();
                        return moveTotargetPoint();
                    }
                    else
                    {
                        _steeringAgentScript.wandering = true;
                        isFleeing = false;
                        seekerWander();
                        return moveTotargetPoint();
                    }
                }
                else
                {
                    //DO I have a target to unzreeze ?
                    if(_steeringAgentScript.unfrozeTarget != null)
                    {
                        //Am I at their last knonw node ?
                        if (_steeringAgentScript.lastNode == _steeringAgentScript.targetLastknownNode)
                        {

                            Vector3 facingVector = (_steeringAgentScript.unfrozeTarget.transform.position - _steeringAgentScript.transform.position).normalized;
                            Quaternion targetRotation = Quaternion.LookRotation(facingVector);

                            if (Vector3.Distance(_steeringAgentScript.transform.position, _steeringAgentScript.unfrozeTarget.transform.position) < 1)
                            {
                                //To-Do unfroze the target
                                Debug.Log("I would have unfroze the target");
                                _steeringAgentScript.unfrozeTarget.GetComponent<freeze>().getUnFreezed();
                                _steeringAgentScript.target = null;
                                _steeringAgentScript.unfrozeTarget = null;
                                seekerWander();
                                _steeringAgentScript.wandering = true;
                                return Vector3.zero;
                            }
                            // Smoothly rotate towards the target point.
                            _steeringAgentScript.transform.rotation = Quaternion.Slerp(_steeringAgentScript.transform.rotation, targetRotation, 10f * Time.deltaTime);
                            return _steeringAgentScript.seekScript.getSteeringSpecificPoint(weight, _steeringAgentScript, _steeringAgentScript.unfrozeTarget.transform.position, false);//change for pursue







                            /*
                            //-------------
                            _steeringAgentScript.target = _steeringAgentScript.unfrozeTarget.gameObject;

                            if(Vector3.Distance(_steeringAgentScript.transform.position, _steeringAgentScript.target.transform.position) < 0.5)
                            {
                                //To-Do unfroze the target
                                Debug.Log("I would have unfroze the target");
                                _steeringAgentScript.target.GetComponent<freeze>().getUnFreezed();
                                _steeringAgentScript.target = null;
                                _steeringAgentScript.unfrozeTarget = null;
                                seekerWander();
                                _steeringAgentScript.wandering = true;
                            }
                            // _steeringAgentScript.wandering = true;
                            //seekerWander();
                            seekerWander();
                            return moveTotargetPoint();
                            */
                        }
                        else
                        {
                            seekerWander();
                            return moveTotargetPoint();
                        }
                    }
                    else {
                        _steeringAgentScript.wandering = true;
                        return moveTotargetPoint();
                    }
                }
                // Seek last known node
                

               
                // Seek last known node
            }
            // _steeringAgentScript.Velocity = Vector3.zero;

        }
        return Vector3.zero;

    }

    private Vector3 moveTotargetPoint()
    {
        Vector3 facingVector = _steeringAgentScript.target.transform.position - _steeringAgentScript.transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(facingVector);

        // Smoothly rotate towards the target point.
        _steeringAgentScript.transform.rotation = Quaternion.Slerp(_steeringAgentScript.transform.rotation, targetRotation, 3f * Time.deltaTime);
        return _steeringAgentScript.arrivecript.getSterring(weight, _steeringAgentScript);
    }
}
