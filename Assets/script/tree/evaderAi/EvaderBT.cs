using System.Collections;
using System.Collections.Generic;
using BehaviorTree;

public class EvaderBT : Tree
{
    // Start is called before the first frame update
    public scriptManager scriptReference;
    public List<node> pathFindingList = new List<node>();
    private Node _rootDebug;
    public node targetNode;

    public bhv_strg_agent behaviourScript { set; get; }

    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            // Fleeing from enemy
            new Selector(new List<Node>{
                
                //flee from close enemy
                new Sequence(new List<Node>{ 
                    //check if enemy is close 
                    new atwo_evader_CheckIfenemyClose(transform, scriptReference),
                    //if it is evade
                    new atwo_evaderTaskCloseEvade(transform,scriptReference)

                
                }),

                //farther away from enemy / was able to escape
                /*new Sequence (new List<Node>{ 
                   //check if the enemy can be seen
                   
                    
                    //if not and far away, then find path in the opposing direction

                })*/


            }),

            //normally Wanedring Around the map
            new Selector(new List<Node>{
                new Sequence(new List<Node>
                {
                    new atwo_CheckMissingClosestNode(this.transform),
                    new atwo_TaskGetNearestNode(this.transform, scriptReference)
                
                
                   //TODO: Add check enemy and go to behavior
                }),
                //Check for pathfindig target node, set it and geth path
                new Sequence(new List<Node>
                {
                    new atwo_evade_CheckMissingTargetPathfinding(transform),
                    new atwo_evader_TaskGeatRandomTarget(transform, pathFindingList)



                }),

                new Sequence(new List<Node>
                {
                    //check if i arrived at the taget node

                    new atwo_CheckArrivedAtNode(this.transform, scriptReference),

                    //check for last node of if i need to get next node 
                    new Selector(new List<Node>
                    {


                        new Sequence(new List<Node>
                        {
                            //check for last node
                            new atwo_CheakLastNode(),


                            //get new path
                            new atwo_evader_TaskGeatRandomTarget(transform, pathFindingList)


                        }),

                        new Sequence(new List<Node>
                        {
                            //select the next node in the path

                            new atwo_TaskSelectNextNode(4),
                        
                           // Debug.log(_rootDebug.GetData("nextNode"))

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
            //Check for closet node
            
        }) ; ;

       
        _rootDebug = root;
        return root;
    }

    protected override void CustumUpdate()
    {
        pathFindingList = (List<node>)_rootDebug.GetData("pathFindingList");
        targetNode = (node)_rootDebug.GetData("nextNode");
    }
}
