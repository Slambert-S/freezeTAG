using UnityEngine;

public class collisionRayCast : MonoBehaviour
{
    public float raydistance;
    public int weightOfDodge;
    private int stuckdetection = 0;
    public float divident = 4;
    public GameObject newPositionVisualiser;
    public Vector3 [] visionDetection( atwo_variable_reference variableManager)
    {
        Vector3[] ellementToDodge = new Vector3[10];
        
        int layerMask = 1 << 6;

        // This would cast rays only against colliders in layer 6.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        //layerMask = ~layerMask;

        var right45 = (Vector3.forward + Vector3.right).normalized;
        var left45 = (Vector3.forward - Vector3.right).normalized;
        var left = ( Vector3.left).normalized;
        var right = ( Vector3.right).normalized;
        var back = (Vector3.forward * -1).normalized;

        RaycastHit hit;
        int count = 0;
        // Does the ray intersect any objects excluding the player layer
        //Forward
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raydistance, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raydistance, Color.yellow);
            //Debug.Log("Did Hit");
            ellementToDodge[count] = hit.point +(hit.normal)* weightOfDodge;
            newPositionVisualiser.transform.position = hit.point + (hit.normal) * weightOfDodge;

            count++;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raydistance, Color.white);
            //Debug.Log("Did not Hit");
        }


        
        // Left45
        if (Physics.Raycast(transform.position, transform.TransformDirection(left45), out hit, raydistance/ divident, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(left45) * (raydistance/ divident), Color.yellow);
           // Debug.Log("Did Hit");
            ellementToDodge[count] = hit.point + (hit.normal) * weightOfDodge;
            newPositionVisualiser.transform.position = hit.point + (hit.normal) * weightOfDodge;

            count++;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(left45) * (raydistance / divident), Color.white);
           // Debug.Log("Did not Hit");
        }


        //Right 45
        if (Physics.Raycast(transform.position, transform.TransformDirection(right45), out hit, (raydistance / divident), layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(right45) * (raydistance / divident), Color.yellow);
            //Debug.Log("Did Hit");
            ellementToDodge[count] = hit.point + (hit.normal) * weightOfDodge;
            newPositionVisualiser.transform.position = hit.point + (hit.normal) * weightOfDodge;

            count++;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(right45) * (raydistance / divident), Color.white);
            //Debug.Log("Did not Hit");
        }

        //Right
        if (Physics.Raycast(transform.position, transform.TransformDirection(right), out hit, (raydistance / divident), layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(right) * (raydistance / divident), Color.yellow);
            //Debug.Log("Did Hit");
            ellementToDodge[count] = hit.point + (hit.normal) * weightOfDodge;
            newPositionVisualiser.transform.position = hit.point + (hit.normal) * weightOfDodge;

            count++;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(right) * (raydistance / divident), Color.white);
            //Debug.Log("Did not Hit");
        }
        //left
        if (Physics.Raycast(transform.position, transform.TransformDirection(left), out hit, (raydistance / divident), layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(left) * (raydistance / divident), Color.yellow);
            //Debug.Log("Did Hit");
            ellementToDodge[count] = hit.point + (hit.normal) * weightOfDodge;
            newPositionVisualiser.transform.position = hit.point + (hit.normal) * weightOfDodge;

            count++;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(left) * (raydistance / divident), Color.white);
            //Debug.Log("Did not Hit");
        }
        //back
        if (Physics.Raycast(transform.position, transform.TransformDirection(back), out hit, (raydistance / divident), layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(back) * (raydistance / divident), Color.yellow);
            //Debug.Log("Did Hit");
            ellementToDodge[count] = hit.point + (hit.normal) * weightOfDodge;
            newPositionVisualiser.transform.position = hit.point + (hit.normal) * weightOfDodge;
            count++;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(back) * (raydistance / divident), Color.white);
            //Debug.Log("Did not Hit");
        }

        stuckdetection += count;
        if(stuckdetection > 50)
        {
            variableManager.isStuck = true;
            stuckdetection = 0;
        }



        return ellementToDodge;
    }


   
    public Vector3[] visionDetectionVOneebug()
    {
        Vector3[] ellementToDodge = new Vector3[10];

        int layerMask = 1 << 6;

        // This would cast rays only against colliders in layer 6.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        //layerMask = ~layerMask;

        var right45 = (Vector3.forward + Vector3.right).normalized;
        var left45 = (Vector3.forward - Vector3.right).normalized;
        var left = (Vector3.left).normalized;
        var right = (Vector3.right).normalized;
        var back = (Vector3.forward * -1).normalized;

        RaycastHit hit;
        int count = 0;
        // Does the ray intersect any objects excluding the player layer
        //Forward
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, raydistance, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raydistance, Color.yellow);
            //Debug.Log("Did Hit");
            ellementToDodge[count] = hit.point + (hit.normal) * weightOfDodge;
            newPositionVisualiser.transform.position = hit.point + (hit.normal) * weightOfDodge;

            count++;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * raydistance, Color.white);
            //Debug.Log("Did not Hit");
        }



        // Left45
        if (Physics.Raycast(transform.position, transform.TransformDirection(left45), out hit, raydistance / divident, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(left45) * (raydistance / divident), Color.yellow);
            // Debug.Log("Did Hit");
            ellementToDodge[count] = hit.point + (hit.normal) * weightOfDodge;
            newPositionVisualiser.transform.position = hit.point + (hit.normal) * weightOfDodge;

            count++;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(left45) * (raydistance / divident), Color.white);
            // Debug.Log("Did not Hit");
        }


        //Right 45
        if (Physics.Raycast(transform.position, transform.TransformDirection(right45), out hit, (raydistance / divident), layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(right45) * (raydistance / divident), Color.yellow);
            //Debug.Log("Did Hit");
            ellementToDodge[count] = hit.point + (hit.normal) * weightOfDodge;
            newPositionVisualiser.transform.position = hit.point + (hit.normal) * weightOfDodge;

            count++;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(right45) * (raydistance / divident), Color.white);
            //Debug.Log("Did not Hit");
        }

        //Right
        if (Physics.Raycast(transform.position, transform.TransformDirection(right), out hit, (raydistance / divident), layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(right) * (raydistance / divident), Color.yellow);
            //Debug.Log("Did Hit");
            ellementToDodge[count] = hit.point + (hit.normal) * weightOfDodge;
            newPositionVisualiser.transform.position = hit.point + (hit.normal) * weightOfDodge;

            count++;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(right) * (raydistance / divident), Color.white);
            //Debug.Log("Did not Hit");
        }
        //left
        if (Physics.Raycast(transform.position, transform.TransformDirection(left), out hit, (raydistance / divident), layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(left) * (raydistance / divident), Color.yellow);
            //Debug.Log("Did Hit");
            ellementToDodge[count] = hit.point + (hit.normal) * weightOfDodge;
            newPositionVisualiser.transform.position = hit.point + (hit.normal) * weightOfDodge;

            count++;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(left) * (raydistance / divident), Color.white);
            //Debug.Log("Did not Hit");
        }
        //back
        if (Physics.Raycast(transform.position, transform.TransformDirection(back), out hit, (raydistance / divident), layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(back) * (raydistance / divident), Color.yellow);
            //Debug.Log("Did Hit");
            ellementToDodge[count] = hit.point + (hit.normal) * weightOfDodge;
            newPositionVisualiser.transform.position = hit.point + (hit.normal) * weightOfDodge;
            count++;
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(back) * (raydistance / divident), Color.white);
            //Debug.Log("Did not Hit");
        }

        stuckdetection += count;
        if (stuckdetection > 50)
        {
           // variableManager.isStuck = true;
            stuckdetection = 0;
        }



        return ellementToDodge;
    }
}
