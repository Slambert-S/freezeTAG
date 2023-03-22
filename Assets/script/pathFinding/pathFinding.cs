using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathFinding : MonoBehaviour
{
    List<node> open_List = new List<node>();
    List<node> close_List = new List<node>();
    Dictionary<node, node> come_From = new Dictionary<node, node>();
    public node startNode;
    public node goalNode;

    void Start()
    {
        // Loop trought all the connecting neibourg from the current list
        /* foreach (node.nodeStruct voisin in startNode.listNeighbour)
         {
             Debug.Log(voisin.listNeighbour);
             come_From.Add(voisin.listNeighbour, startNode)  ;
             open_List.Add(voisin.listNeighbour);
             //open_List.Sort();
             Debug.Log(come_From);
         }*/

        //findPath();
    }

    public List<node> findPath(node start, node goal)
    {

         open_List = new List<node>();
         close_List = new List<node>();
         come_From = new Dictionary<node, node>();
         
        
         startNode = start;
         goalNode = goal;
        // dictionary to keep track of g(n) values (movement costs)
        Dictionary<node, float> gnDict = new Dictionary<node, float>();
        gnDict.Add(startNode, default);

        // dictionary to keep track of f(n) values (movement cost + heuristic)
        Dictionary<node, float> fnDict = new Dictionary<node, float>();
        fnDict.Add(startNode, heuristic(startNode.transform.position, goalNode.transform.position) + gnDict[startNode]);

        Dictionary<node, node> pathDict = new Dictionary<node, node>();
        pathDict.Add(startNode, null);

        open_List.Add(startNode);
        node current_node = open_List[open_List.Count - 1];

        //check if path is in the 
        
        bool solutionFound = false;
        while (open_List.Count > 0)
        {
            
           
            open_List.Remove(current_node);
            

            close_List.Add(current_node);

            if(current_node == goalNode)
            {
                solutionFound = true;
                break;
            }
            

            foreach (node.nodeStruct voisin in current_node.listNeighbour)
            {

                float g_next = gnDict[current_node] + voisin.pathWeight;

                //check if  a value already exist in the dictionary of cost for g  or if the value in the dic ti greater than the current one
                if (!gnDict.ContainsKey(voisin.listNeighbour) || g_next < gnDict[voisin.listNeighbour])
                {
                    gnDict[voisin.listNeighbour] = g_next;
                    fnDict[voisin.listNeighbour] = g_next + heuristic(voisin.listNeighbour.transform.position, goalNode.transform.position);
                    open_List.Add(voisin.listNeighbour);
                    pathDict[voisin.listNeighbour] = current_node;
                }

            }
                //After this loop all the neighbour node are added into the open list.
                //next pop the folowing node with the shortest path.
             

                //This part of the code find the next node with the smallest F with a time of n
                node followingNode = null;
                float minValue = float.MaxValue;
                foreach(node n in open_List)
                {
                    if (fnDict[n] <= minValue)
                    {
                        followingNode = n;
                        minValue = fnDict[n];
                    };
                }

                 current_node = followingNode;

               /* Debug.Log(voisin.listNeighbour);
                come_From.Add(voisin.listNeighbour, startNode);
                open_List.Add(voisin.listNeighbour);
                //open_List.Sort();
                Debug.Log(come_From);*/
            

        }
        if (solutionFound)
        {
            node current = goalNode;
            List<node> pathToGoal = new List<node>();
            while(current != startNode)
            {
                pathToGoal.Add(current);
                current = pathDict[current];
            }

            pathToGoal.Reverse();
             //Debug.Log(printList(pathToGoal));
            return pathToGoal;
           
        }

        return new List<node>();
        
    }

    public string printDicValue(Dictionary<node, float> fnDict)
    {
        string exitString = " Value of all node in open list : \n";
        foreach (node n in open_List)
        {
            exitString += n.name + "  have a f value of : " + fnDict[n]+ " \n";
        }

        return exitString;
            
    }

    public string printList(List<node> path)
    {
        string outString = "";
        foreach (node n in path)
        {
            outString += n.name + " , ";
        }
        return outString;
    }
    

    public float heuristic(Vector3 currentPost, Vector3 goalPoss)
    {
        float x = goalPoss.x - currentPost.x;
        float y = goalPoss.y - currentPost.y;
        float z = goalPoss.z - currentPost.z;
        
        return Mathf.Abs(x + y + z);
    }


}
