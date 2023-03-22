using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atwo_detectSeeker : MonoBehaviour
{
    public float radius;
    // Start is called before the first frame update
  
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public List<Collider> checkAroundforSeeker(float radius)
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        List<Collider> listSeeker = new List<Collider>();
        Vector3 steering = Vector3.zero;

        int haveNewPath = 0;
        foreach (Collider hitCollider in hitColliders)
        {
            //check if a seeker is in the area
            if (hitCollider.CompareTag("seeker"))
            {

                RaycastHit hit;
                if (Physics.Raycast(transform.position, hitCollider.transform.position - transform.position, out hit, Mathf.Infinity))
                {
                    //check if the agent can see the seeker
                    if (hit.collider.CompareTag("seeker"))
                    {
                        listSeeker.Add(hitCollider);
                    }
                }
                
                //Debug.Log("Evader spot a seeker");
                
                /*
                float distance = (hitCollider.transform.position - this.transform.position).magnitude;
                _sterringAgent.stateBheaviour.isFleeing = true;
                if (distance < 2)
                {
                    steering += this.gameObject.GetComponent<SteeringAgent>().fleeScript.getSteeringAvoidSeeker(36, hitCollider.transform.position, this.gameObject.GetComponent<SteeringAgent>());
                }
                else
                {
                    //_sterringAgent.Velocity = Vector3.zero;
                    //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, _sterringAgent.kinematicFaceAway(_sterringAgent, hitCollider.transform.position), 1f * Time.deltaTime); ;

                    steering += this.gameObject.GetComponent<SteeringAgent>().fleeScript.getSteeringAvoidSeeker(6, hitCollider.transform.position, this.gameObject.GetComponent<SteeringAgent>());
                    // Make sure to no get a new path every frame.
                    if (needNewPathFinding == 0)
                    {

                        _sterringAgent.GetPathFindingEvade();
                        needNewPathFinding = 1;


                        haveNewPath++;

                    }
                    else
                    {
                        haveNewPath++;
                    }

               
                } */

               // return true;
            }

        }

        return listSeeker;
    /*

        if (haveNewPath == 0 && needNewPathFinding == 1)
        {

            needNewPathFinding = 0;

        }

        steering.y = 0;
        steering = steering.normalized;
        return steering;*/
    }
}
