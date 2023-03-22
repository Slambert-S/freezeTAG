using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class valueOfBehaviour : MonoBehaviour
{
    public SteeringAgent _steeringAgentScript;
    public float valueForBeingClose;
   
    // Start is called before the first frame update
    void Start()
    {
        if (this.GetComponent<SteeringAgent>() != null)
            _steeringAgentScript = this.GetComponent<SteeringAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
