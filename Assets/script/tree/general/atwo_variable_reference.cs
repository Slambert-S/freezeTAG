using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atwo_variable_reference : MonoBehaviour
{
    public bool seeTargetAgent;
    public bhv_strg_agent tagTarget;
    public bool isEvader;
    public bool isFreezed;
    public node targetLastKnownNode;
    public node lastNode;
    public GameObject collectible;
    public bool needNewPath = true;
    public node nodeTrigger = null; 
    private void Start()
    {
        seeTargetAgent = false;
        tagTarget = null;
    }
}
