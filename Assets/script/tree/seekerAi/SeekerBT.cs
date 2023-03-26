using System.Collections;
using System.Collections.Generic;
using BehaviorTree;

public class SeekerBT : Tree
{
    public List<node> waypoints = new List<node>();

    //public static float speed = 2f;
    //public static float fovRange = 6f;
    //public static float attackRange = 1f;
    //public seek seekScript;
    public List<node> debugPatrol = new List<node>();
    public bhv_strg_agent behaviourScript { set; get; }
    public List<node> pathFindingList = new List<node>();

    public scriptManager scriptReference;

    public node debugTargetNode;

   

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Selector(new List<Node>
            {
                //Selector if i am away not patrolling
                new Sequence(new List<Node>
                {
                    //Spot an evader
                    new atwo_seeker_CheckSpottedAgent(scriptReference),
                        
                    //Follow evader
                    new atwo_seeker_TaskPursue(transform,scriptReference)


                }),

                new Sequence(new List<Node>{ 
                    //check in variable if they need to check a missing node spot 
                    new atwo_seeker_checkNodeTrigger(scriptReference),

                    //if its the case , set the missing node spot at the last known node and stop the partol 
                    new atwo_seeker_TaskSetUpInvestigateCollectible(scriptReference)

                }),
                //go to last known node
                new Sequence(new List<Node>
                {
                     //find path to last knone node
                    new ateo_debug_spottedEnemyCheck(),
                    
                    //move toward last known node
                    new Selector(new List<Node>
                    {
                       
                            //check if i arrived at the taget node
                                  //Check for closet node
                            new Sequence(new List<Node>
                            {
                                new atwo_CheckMissingClosestNode(this.transform),
                                new atwo_TaskGetNearestNode(this.transform,scriptReference)
                
                
                               //TODO: Add check enemy and go to behavior
                            }),
                            //Check for pathfindig target node, set it and geth path
                            new Sequence(new List<Node>
                            {
                                new atwo_evade_CheckMissingTargetPathfinding(transform),
                               // new atwo_evader_TaskGeatRandomTarget(transform, pathFindingList, debugTargetNode)
                               new atwo_seeker_TaskGetLastKnownNodeOfEvader (transform, pathFindingList, debugTargetNode)



                            }),

                            new Sequence(new List<Node>
                            {

                                new atwo_CheckArrivedAtNode(this.transform, scriptReference),

                                //check for last node of if i need to get next node 
                                new Selector(new List<Node>
                                {


                                    new Sequence(new List<Node>
                                    {
                                        //check for last node
                                        new atwo_CheakLastNode(),


                                       
                                       new atwo_seeker_TaskRotate360(transform, scriptReference)


                                    }),

                                    new Sequence(new List<Node>
                                    {
                                        //select the next node in the path

                                        new atwo_TaskSelectNextNode(4),
                        
                                      

                                    }),

                                }),

                            }),

                            //Check if we need to rotate to face the target node
                            new Sequence(new List<Node>
                            {
                                new atwo_CheckFacingNode(transform),

                                new atwo_TaskRotateTowardPoint(transform , scriptReference)


                            }),



                            new  atwo_TaskGoToTarget(scriptReference)
                    }),

                    
                    
                    

                }),

            }),

            new Selector(new List<Node>
            {
                //Selector if i am patrolling

                //IF the Ai is away from the last patrol point
                new Sequence(new List<Node>
                {
                   //Is the agent away from the last chekpoint

                    new atwo_seeker_CheckAwayFromPath(),


                     new Selector(new List<Node>
                    {
                       
                            //check if i arrived at the taget node
                                  //Check for closet node
                            new Sequence(new List<Node>
                            {
                                new atwo_CheckMissingClosestNode(this.transform),
                                new atwo_TaskGetNearestNode(this.transform , scriptReference)
                
                
                               //TODO: Add check enemy and go to behavior
                            }),
                            //Check for pathfindig target node, set it and geth path
                            new Sequence(new List<Node>
                            {
                                new atwo_evade_CheckMissingTargetPathfinding(transform),
                                new atwo_seeker_TaskGetPathToPatrolPoint(transform, pathFindingList, debugTargetNode)



                            }),

                            new Sequence(new List<Node>
                            {

                                new atwo_CheckArrivedAtNode(this.transform, scriptReference),

                                //check for last node of if i need to get next node 
                                new Selector(new List<Node>
                                {


                                    new Sequence(new List<Node>
                                    {
                                        //check for last node
                                        new atwo_CheakLastNode(),



                                       new atwo_seeker_TaskGoBackToPatrol()


                                    }),

                                    new Sequence(new List<Node>
                                    {
                                        //select the next node in the path

                                        new atwo_TaskSelectNextNode(4),



                                    }),

                                }),

                            }),

                            //Check if we need to rotate to face the target node
                            new Sequence(new List<Node>
                            {
                                new atwo_CheckFacingNode(transform),

                                new atwo_TaskRotateTowardPoint(transform , scriptReference)


                            }),



                            new  atwo_TaskGoToTarget(scriptReference)
                    }),
                   //if yes then go back to last waypoint
                        //do once : get closest node 
                        //set the path

                    //  then move untill you find the node
                }),

                new Selector(new List<Node>
                {
                         //Patroling
                    //setUpPatrolPoint
                    new Sequence(new List<Node>
                    {
                        //2
                        new atwo_TaskSetUpPatrol(waypoints)

                    }),

                    //patroling : arrived at waypoint
                    new Sequence(new List<Node>
                    {
                        //2

                        //Check if at patrol point
                        new atwo_seeker_CheckAtWaypoint(transform),



                        //rotate around
                        new atwo_seekerLookLR(transform, scriptReference),
                        //ToDo
                        //set next patrol point at target
                        new atwo_seeker_TaskSetNextPatrolP()



                    }),

                    //patroling : Rotate to face the next waypoint
                    new Sequence(new List<Node>
                    {
                        //2
                        new atwo_CheckFacingNode(transform),

                        new atwo_TaskRotateTowardPoint(transform , scriptReference)

                    }),
                    new atwo_seker_TaskGoToWaypoint(scriptReference)


                }),
            }),

           
            

           
            //Patroling : move to next patrol point

        //new TaskPatrol(transform, waypoints)
        }) ; ;

        return root;
    }

    
    protected override void CustumUpdate()
    {
        //throw new System.NotImplementedException();
    }
}
