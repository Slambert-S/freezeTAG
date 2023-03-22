using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dictionaryOfNode : MonoBehaviour
{
    /*
     *  nextNode        = [ node ] The node agent is trying to reach.
     *  targetNode      = [ node ] The node that is the final destination of the agent , the last node on the list.
     *  pathFindingList = [ List<node>] object that containe the path of node to follow to reach targetNode.
     *  
     *  
     *  [Seeker specific]
     *  lastPatrolPoint = [ node ] The last patrol point visited by the Ai.
     *  nextPatrolPoint = [ node ] The patrol point the ai want to ge to.
     *  numberOfWaypoint = [ int ] The number of waypoint in the patroll rout of the Ai.
     *  waypointIndex   = [ int ]  Index of the last patroling node.
     *  listOfWaypoint  = [ List<node> ] list of all the waypoint.
     *  isLookingAround = [ bool ] is the Ai currently looking around at a node.
     *  lookingStep     = [ int ]   Wich dirrection the ai is lookin toward.
     *  seeTaargetAgent = [ bool ] True is the Agent can see an evader agent.
     *  stopPatrol      = [ bool ] Set as true if the agent does not want to patrol.
     *  awayFromWaypoint = [ bool ] True if the Agent is not currently in their patrol area.
     *  targetLastKnownNode = [ node ] The last knonw node of the target the Agent saw.
     *  
     *  
     *  
     *  
     *  [Evader specific]
     *  listEnemy       = [List<Collider>] Contain the list of all the seeker that are close to the evader.
     *  collectible     = [ GameObject ] Collectible that the ai want to collect.
     *  needEvadePath   = [ bool ] Indicate if the evader need to get a new escape path. 
     * 
     * 
     * 
     * 
     * 
     * 
     * 
     */
}
