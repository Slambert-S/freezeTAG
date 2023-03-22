using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atwo_coneOfView : MonoBehaviour
{
    // Start is called before the first frame update
    private scriptManager _scriptManager;
    void Start()
    {
        _scriptManager = gameObject.GetComponentInParent<scriptManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool checkInConeOfView(float angle)
    {

        float angleLeft = angle;
        int nuberOfAngle = 6;
        float angleIncreament = (angleLeft * 2) / nuberOfAngle;
        Vector3 rayPosition = transform.position;
        Vector3 leftRayRotation = Quaternion.AngleAxis(-angle, Vector3.up) * Vector3.forward;
        Vector3 rightRayRotation = Quaternion.AngleAxis(angle, Vector3.up) * Vector3.forward;
        RaycastHit hit;
        bool hitSomething = false;

        for (int i = 0; i < nuberOfAngle; i++)
        {
            Vector3 temAngle = Quaternion.AngleAxis(-angleLeft + (angleIncreament * i), Vector3.up) * Vector3.forward;
            if (Physics.Raycast(transform.position, transform.TransformDirection(temAngle), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(temAngle) * hit.distance, Color.red);

                
                 //swap wanderring for seeTaargetAgent == false;
                if (_scriptManager.variableReference.seeTargetAgent == false)
                {
                    // Debug.Log("patate");
                    if (hit.collider.gameObject.GetComponentInParent<bhv_strg_agent>() != null) 
                    {

                        if (hit.collider.gameObject.GetComponentInParent<atwo_variable_reference>().isEvader)
                        {
                            // Debug.Log("popoto");
                            //if seeket spot a new evader set them as a target and register last known information.
                            if (_scriptManager.variableReference.isEvader)
                            {
                                //Debug.Log("lalafel");
                                //SteeringAgent evaderDetected = hit.collider.gameObject.GetComponentInParent<SteeringAgent>();
                               // if (evaderDetected.isFreezed)
                                //{
                                  //  Debug.Log("potato magical");
                                    //_steeringAgent.target = evaderDetected.gameObject;
                                    //if (_steeringAgent.wandering == true)
                                      //  _steeringAgent.wandering = false;
                                    //_steeringAgent.unfrozeTarget = evaderDetected;
                                   // _steeringAgent.targetLastknownNode = evaderDetected.lastNode;
                                    //return true;
                                //}
                                //Debug.Log("I can see a lalafel");
                               

                                hitSomething = false;
                            }
                            else
                            {
                                if (hit.collider.gameObject.GetComponentInParent<atwo_variable_reference>().isFreezed != true)
                                {
                                    _scriptManager.variableReference.tagTarget = hit.collider.gameObject.GetComponentInParent<bhv_strg_agent>();
                                    if (_scriptManager.variableReference.seeTargetAgent == true)
                                        _scriptManager.variableReference.seeTargetAgent = false;
                                    _scriptManager.variableReference.targetLastKnownNode = _scriptManager.variableReference.tagTarget.GetComponent<atwo_variable_reference>().lastNode;
                                    return true;
                                }
                                else
                                {
                                    hitSomething = false;
                                }

                            }

                        }
                        else
                        {
                            /*
                            //if evader see a seeker
                            if (_steeringAgent.isEvader())
                            {
                                //Debug.Log("I can see a potato");

                                _steeringAgent.tagTarget = hit.collider.gameObject.GetComponentInParent<SteeringAgent>().gameObject;
                                if (_steeringAgent.wandering == true)
                                    _steeringAgent.wandering = false;
                                _steeringAgent.targetLastknownNode = _steeringAgent.tagTarget.GetComponent<SteeringAgent>().lastNode;
                                return true;
                            }
                            hitSomething = false;*/
                        }


                    }
                    else
                    {
                        if(_scriptManager.variableReference.tagTarget != null)
                        {
                            if (hit.Equals(_scriptManager.variableReference.tagTarget.gameObject))
                            {
                                // Debug.Log("Looking at " + _steeringAgent.target.name);
                                return true;
                            }
                        }
                        
                        hitSomething = false;
                    }

                }
                else
                {
                    if (hit.collider.gameObject.GetComponentInParent<bhv_strg_agent>() != null)
                    {
                        if (hit.collider.gameObject.GetComponentInParent<atwo_variable_reference>().isEvader)
                        {
                            // Debug.Log("Looking at " + _steeringAgent.target.name);
                            return true;
                        }

                    }
                    else
                    {
                        //Debug.Log("The malediction of the king");
                        hitSomething = false;
                    }
                }


            
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(temAngle) * Mathf.Infinity, Color.red);
                //Debug.Log("Did not Hit");
                //return false;
            }

        }
            return false;
    }
}
