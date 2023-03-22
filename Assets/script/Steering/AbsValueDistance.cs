using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsValueDistance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Vector3 getAbsoluteDistance( Vector3 target, Vector3 agentPosition)
    {

        Vector3 absTargetToPoss;

        float TPX = target.x;
        float TPY = target.y;
        float TPZ = target.z;

        float CPX = agentPosition.x;
        float CPY = agentPosition.y;
        float CPZ = agentPosition.z;



        absTargetToPoss.x = Mathf.Abs(TPX - CPX);
        absTargetToPoss.y = Mathf.Abs(TPY - CPY);
        absTargetToPoss.z = Mathf.Abs(TPZ - CPZ);

        return absTargetToPoss;
    }
}
