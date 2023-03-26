using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringAgent : MonoBehaviour
{
    // Start is called before the first frame update
    private float[] weightList;
    private  Vector3 originalDistanceFromGround;

    public Vector3 Velocity { get; set; }
    public collisionRayCast collisionDetection { get; set; }

    //Value to be set in the editor
    [Header("Value to be set")]
    public float maxSpeed;
    public GameObject target; // node target from general mouvment 
    public bool pathfindingMode = true; 
    public enum EBehaviorType { Evader, Seeker }
    public EBehaviorType behaviorType;
    
    
   
    

    [Header("Debug Value")]
    public List<node> pathFindingList = new List<node>();
    public AbsValueDistance distanceCalculator;
    public node lastNode = null; //Last node visited
    public node coinNode;
    public GameObject coinTarget;
    
    //List of all possible steering script;
    public seek seekScript { get; set; }
    public arrivedAtTarget arrivecript { get; set; }
    public Flee fleeScript { get; set; }
    public evade evadeScript;
    public pursue pursueScript;
    public targetControl targetControlScript;
    
    public node testStart;
    public node testGoal;
    public node targetLastknownNode;
    public GameObject tagTarget;
    public SteeringAgent unfrozeTarget = null;
    public GameObject testEvaidPoint;


    public humanBehaviourSM stateBheaviour;
    
    public bool debugFirstNode = false;
    public bool wandering = true;
    public bool isStuck = false;
    public bool isFreezed = false;
    public bool huntingCoin = false;

    public delegate void PlayerCoinCollected();
    public static event PlayerCoinCollected playerCollectedCoin;

    public delegate void AiCoinCollected();
    public static event AiCoinCollected aiCollectedCoin;

    void Start()
    {
        if (this.GetComponent<seek>() != null)
            seekScript = this.GetComponent<seek>();

        if (this.GetComponent<Flee>() != null)
            fleeScript = this.GetComponent<Flee>();

        if (this.GetComponent<evade>() != null)
            evadeScript = this.GetComponent<evade>();
        if (this.GetComponent<arrivedAtTarget>() != null)
            arrivecript = this.GetComponent<arrivedAtTarget>();
        if (this.GetComponentInChildren<collisionRayCast>() != null)
            collisionDetection = this.GetComponentInChildren<collisionRayCast>();
        if (this.GetComponentInChildren<pursue>() != null)
            pursueScript = this.GetComponent<pursue>();

       originalDistanceFromGround = getCurrentYpos(this.transform.position);
        

        if (this.GetComponent<slowBehaviour>() != null)
            stateBheaviour = this.GetComponentInChildren<slowBehaviour>();

       
            targetControlScript = GameObject.Find("gameManager").GetComponent<targetControl>();
       


    }

    private void OnEnable()
    {
        coin.onCollectedCoin += restCoinSeeker;
       
    }
    // Update is called once per frame
    void Update()
    {
        if(unfrozeTarget != null && isFreezed == false)
        {
            if (Vector3.Distance(this.transform.position, this.unfrozeTarget.transform.position) < 0.5)
            {
                //To-Do unfroze the target
                Debug.Log(gameObject.tag);
                unfrozeTarget.GetComponent<freeze>().getUnFreezed();
                this.target = null;
                unfrozeTarget = null;
                //seekerWander();
            }
        }
        

        if (debugFirstNode == false)
        {
            testGoal = GameObject.Find("Node List").GetComponent<nodeSelection>().getRandomNode();
            if (testGoal != null)
            {
                //Debug.Log("start of file " + testGoal.name);
                
                    testStart = findClosestNode.getClosestNode(this.transform.position);


                lastNode = testStart;
                getNewPath(testStart, testGoal);
                debugFirstNode = true;
            }

           // Debug.Log("start of file " + testGoal.name);
            //lastNode = testStart;
        }

        if (coinTarget != null && pathFindingList.Count > 0)
        {
            getNewPath(lastNode, coinNode);
        }


        if (!isFreezed)
        {
            if (this.CompareTag("Player"))
            {
                playerVelocity();
            }
            else
            {

                calculateVelocity();
            }

        }
     
        //stateBheaviour.testSpeed();
        

    }

   public void calculateVelocity()
   {


        Vector3 acceleration = Vector3.zero;
        Quaternion rotation = Quaternion.identity;
        int nbSteeringAction = 0;

       
       if(this.wandering == true && unfrozeTarget == null && isEvader() == true)
       {
            // get a new target to unfreeze
            SteeringAgent newFreezedTarget = targetControlScript.getUnfreezeTarget();
            node newTargetNode = null;

            if (newFreezedTarget != null)
            {
                unfrozeTarget = newFreezedTarget;
                newTargetNode = findClosestNode.getClosestNode(unfrozeTarget.transform.position);
            }
           
           

            if(newTargetNode != null){
                testGoal = newTargetNode;
                targetLastknownNode = newTargetNode;

                getNewPath(lastNode, testGoal);

                wandering = false;
            }

            


       }

        if (pathfindingMode)
        {
            if(pathFindingList.Count > 0)
            {
                
                this.target = pathFindingList[0].gameObject;
                if ((this.transform.position - this.target.transform.position).magnitude < 1)
                {
                    lastNode = pathFindingList[0];
                    pathFindingList.RemoveAt(0);
                    if(pathFindingList.Count != 0)
                    {
                        this.target = pathFindingList[0].gameObject;

                    }
                }
                acceleration += stateBheaviour.humanAction();
                nbSteeringAction++;

            }
            else
            {


                if (!huntingCoin)
                {
                    checkPathFinding();

                }
                else
                {
                    if (lastNode == coinNode)
                    {
                        target = coinTarget;

                        if (Vector3.Distance(transform.position, coinTarget.transform.position) < 1)
                        {

                            coinTarget.GetComponent<coin>().coinCollected();
                            transform.Find("Rig").Find("Bone").Find("VikingHelmet").transform.localScale = Vector3.one;

                            if (aiCollectedCoin != null)
                            {
                                aiCollectedCoin();
                            }

                            coinTarget = null;
                            wandering = true;
                            coinNode = null;
                            huntingCoin = false;
                           
                        }
                    }

                        acceleration += stateBheaviour.humanAction();
                        nbSteeringAction++;
                }
                
            }
            
        }
        else
        {

            //TO-Do removide this when the pathfinding end will be handled 
            
            Velocity = Vector3.zero;
        }



        if(behaviorType == EBehaviorType.Evader)
        {
            
            acceleration += this.gameObject.GetComponent<fleeMouvement>().checkAroundforSeeker();
            nbSteeringAction++;
        }

        if (isStuck)
        {
           // Debug.Log("closes node name : " + findClosestNode.getClosestNode(this.transform.position).name);
            node fixingNode = findClosestNode.getClosestNode(this.transform.position);
            acceleration = Vector3.zero;
            //Velocity = Vector3.zero;
            if(fixingNode !=  null)
                acceleration += seekScript.getSteeringSpecificPoint(6, this, fixingNode.transform.position, false);
            nbSteeringAction++;

            if(fixingNode == null)
            {
                this.transform.position = lastNode.transform.position;
                getNewPath(lastNode, testGoal);
            }
            else if (Vector3.Distance(this.transform.position, fixingNode.transform.position) < 1)
            {
                isStuck = false;
                lastNode = fixingNode;
                getNewPath(lastNode, testGoal);
            }

            unfrozeTarget = null;
            wandering = true;

        }

        //wall collision handling
        Vector3[] neighbors = collisionDetection.visionDetectionVOneebug();

        Vector3 tempAcc = Vector3.zero;
        int nbSteering = 0;
        foreach (Vector3 obstacle in neighbors)
        {
            if(obstacle != Vector3.zero)
            {
                tempAcc += seekScript.getSteeringSpecificPoint(20, this, obstacle, true);
                
               nbSteering++;
            }  

        }
    
        acceleration += tempAcc;
        //acceleration /= nbSteering;
      
        acceleration.y = 0;

        // acceleration.y += originalDistanceFromGround.y;
        Velocity += acceleration * Time.deltaTime;

       
        //Velocity += distanceDifference*Time.deltaTime;
        Velocity = Vector3.ClampMagnitude(Velocity, maxSpeed);

        Vector3 distanceFromGround = Vector3.zero;
        distanceFromGround = getCurrentYpos(Velocity);
        Vector3 difference = claculateDifference(originalDistanceFromGround, distanceFromGround);
        //Velocity += difference;
        //Debug.Log(Velocity);
       // Velocity.Set(Velocity.x, (Velocity.y - originalDistanceFromGround.y), Velocity.z);
        

        this.transform.position += Velocity * Time.deltaTime;
        //this.transform.rotation = faceForward(this) ;


    }

   public void playerVelocity() {

        if (coinTarget && Vector3.Distance(transform.position, coinTarget.transform.position) < 1)
        {

            if (playerCollectedCoin != null)
            {
                playerCollectedCoin();
            }

            coinTarget.GetComponent<coin>().coinCollected();
            //coinTarget = null;
            wandering = true;
            coinNode = null;
            

        }

        Vector3[] neighbors = collisionDetection.visionDetectionVOneebug();
       
        Vector3 tempAcc = Vector3.zero;
        int nbSteering = 0;
        foreach (Vector3 obstacle in neighbors)
        {
            if (obstacle != Vector3.zero)
            {
                tempAcc += seekScript.getSteeringSpecificPoint(1, this, obstacle, true);

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

    public Vector3  getCurrentYpos(Vector3 poss)
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.green);
           
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.blue);
            
        }
        Vector3 distanceFromGround = this.transform.position - hit.point;
        return distanceFromGround;
    }

    public Vector3 claculateDifference(Vector3 orignalDistance, Vector3 newDistance)
    {

        return (orignalDistance - newDistance).normalized;
    }


    Quaternion ratationalBehaviour(SteeringAgent agent)
    {
        Vector3 from = Vector3.ProjectOnPlane(agent.transform.forward, Vector3.up);
        Vector3 to = faceForward(agent) * Vector3.forward;
        float angleY = Vector3.SignedAngle(from, to, Vector3.up);
        return Quaternion.AngleAxis(angleY, Vector3.up);
    }

    public Quaternion faceForward(SteeringAgent agent)
    {
        if (agent.Velocity == Vector3.zero)
        {
            return agent.transform.rotation;
        }

        return Quaternion.LookRotation(agent.Velocity);
    }

    Quaternion kinematicFace(SteeringAgent agent)
    {
        Vector3 direction = target.transform.position - transform.position;
        if(direction.normalized == transform.forward || Mathf.Approximately(direction.magnitude, 0))
        {
            return transform.rotation;
        }

        return Quaternion.LookRotation(direction);
    }

    public Quaternion kinematicFaceAway(SteeringAgent agent, Vector3 targetPosition)
    {
        Vector3 direction =transform.position- targetPosition;
        if (direction.normalized == transform.forward || Mathf.Approximately(direction.magnitude, 0))
        {
            return transform.rotation;
        }

        return Quaternion.LookRotation(direction);
    }
    Quaternion XXX(SteeringAgent agent)
    {
        return Quaternion.FromToRotation(transform.forward, faceForward(agent) * Vector3.forward);
    }

    public bool isEvader()
    {
        
        if(behaviorType == EBehaviorType.Evader)
        {
            //Debug.Log("Is evader is called");
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool isEvaderDebug()
    {

        if (behaviorType == EBehaviorType.Evader)
        {
           // Debug.Log("Is evader is called");
            return true;
        }
        else
        {
            return false;
        }
    }

    public void checkPathFinding()
    {
        if(pathFindingList.Count < 1)
        {
            node newTargetNode = lastNode;
            do
            {
                
                newTargetNode = GameObject.Find("Node List").GetComponent<nodeSelection>().getRandomNode();
               // Debug.Log("in do while new node name = " + newTargetNode.name);
            } while (newTargetNode == this.lastNode);
            pathFindingList = gameObject.GetComponent<pathFinding>().findPath(lastNode, newTargetNode);
        }
        
    }

    public void GetPathFindingEvade()
    {

        node newTargetNode = lastNode;
        do
        {
            if(tagTarget == null)
            {
                newTargetNode = GameObject.Find("Node List").GetComponent<nodeSelection>().getRandomNode();
            }
            else
            {

                newTargetNode = GameObject.Find("Node List").GetComponent<nodeSelection>().getRandomObjectiveNode(transform.position, tagTarget.transform.position, true);
            }
        } while (newTargetNode == this.lastNode);
            
        pathFindingList = gameObject.GetComponent<pathFinding>().findPath(lastNode, newTargetNode);
        //Debug.Log(" I am fleeing from the enemy");
        

    }

    public void getNewPath( node currNode, node targetNode)
    {
        if (!this.CompareTag("Player"))
        {
            
            pathFindingList = gameObject.GetComponent<pathFinding>().findPath(currNode, targetNode);
        }
    }

    public void getAssigneCoin( GameObject newTarget)
    {
        coinTarget = newTarget;
        huntingCoin = true;
        coinNode = findClosestNode.getClosestNode(coinTarget.transform.position);
        wandering = false;
        transform.Find("Rig").Find("Bone").Find("VikingHelmet").transform.localScale = Vector3.zero;

       

        getNewPath(lastNode, coinNode);
    }

    private void restCoinSeeker()
    {
       /*if (this.CompareTag("seeker") )
        {
            transform.Find("Rig").Find("Bone").Find("VikingHelmet").transform.localScale = Vector3.one;
            //pathFindingList = gameObject.GetComponent<pathFinding>().findPath(currNode, targetNode);
        }*/
       
    }
}
