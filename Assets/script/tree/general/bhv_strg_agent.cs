using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bhv_strg_agent : MonoBehaviour
{
    public Vector3 Velocity { get; set; }
    public float maxSpeed;
    private scriptManager _scriptManager;
    private atwo_variable_reference _variableManager;
    public collisionRayCast _colisionScript;
    public seek _seekScript;
    // Start is called before the first frame update
    void Start()
    {
        _scriptManager = gameObject.GetComponent<scriptManager>();
        _variableManager = gameObject.GetComponent<atwo_variable_reference>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.CompareTag("Player"))
        {

            playerVelocity();
        }
    }
    public void playerVelocity()
    {
        Debug.Log("potato");
       /* if (coinTarget && Vector3.Distance(transform.position, coinTarget.transform.position) < 1)
        {

            if (playerCollectedCoin != null)
            {
                playerCollectedCoin();
            }

            coinTarget.GetComponent<coin>().coinCollected();
            //coinTarget = null;
            wandering = true;
            coinNode = null;


        }*/

        Vector3[] neighbors = _colisionScript.visionDetectionVOneebug();

        Vector3 tempAcc = Vector3.zero;
        int nbSteering = 0;
        foreach (Vector3 obstacle in neighbors)
        {
            if (obstacle != Vector3.zero)
            {
                tempAcc += _seekScript.beaviourSeekWall(50, obstacle, this, true);

                nbSteering++;
            }

        }
        tempAcc.y = 0;

        Velocity += tempAcc * Time.deltaTime;
        //Velocity.Set(Velocity.x, 0 ,Velocity.z);
        Velocity = Vector3.ClampMagnitude(Velocity, maxSpeed);
        this.transform.position += Velocity;
        // this.transform.position = (Velocity.x, 20, Velocity.z);
        Velocity = Vector3.zero;
    }


    public void moveAgent(Vector3 mainVelocity)
    {
        Vector3 acceleration = Vector3.zero;
        Quaternion rotation = Quaternion.identity;
        acceleration += mainVelocity;

        //prevent colisions
        //wall collision handling
        Vector3[] neighbors = _scriptManager.collisionScript.visionDetection(_variableManager);

        Vector3 tempAcc = Vector3.zero;
        int nbSteering = 0;
        foreach (Vector3 obstacle in neighbors)
        {
            if (obstacle != Vector3.zero)
            {
                tempAcc += _scriptManager.seekScript.beaviourSeekWall(50, obstacle,this, true);

                nbSteering++;
            }

        }
        acceleration += tempAcc;
        acceleration.y = 0;

        Velocity += acceleration * Time.deltaTime;
        Velocity = Vector3.ClampMagnitude(Velocity, maxSpeed);
        this.transform.position += Velocity * Time.deltaTime;
    }

    public void pursueTarget(Vector3 mainVelocity)
    {

        //Debug.Log("In pursue target");
        moveAgent(mainVelocity);
        this.transform.rotation = faceForward(this);

    }
    public void avoidTarget(Vector3 mainVelocity)
    {

        //Debug.Log("In pursue target");
        moveAgent(mainVelocity);
        this.transform.rotation = faceBackward(this);

    }


    public Quaternion faceForward(bhv_strg_agent agent)
    {
        if (agent.Velocity == Vector3.zero)
        {
            return agent.transform.rotation;
        }

        return Quaternion.LookRotation(agent.Velocity);
    }
    public Quaternion faceBackward(bhv_strg_agent agent)
    {
        if (agent.Velocity == Vector3.zero)
        {
            return agent.transform.rotation;
        }

        return Quaternion.LookRotation(agent.Velocity*-1);
    }
}

