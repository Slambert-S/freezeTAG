using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerForNewPath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startCooldown()
    {
        StartCoroutine(timerNewPath());
    }
    IEnumerator timerNewPath()
    {

        yield return new WaitForSeconds(5f);
        this.GetComponent<atwo_variable_reference>().needNewPath = true;
            //.SetData("needEvadePath", true);
        Debug.Log("boop");
    }

}
