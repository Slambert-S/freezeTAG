using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freeze : MonoBehaviour
{
    public SteeringAgent steeringAgent;
    private targetControl _targetControl;
    private float radius = 0.5f;

    public delegate void playerDied();
    public static event playerDied callPlayerDied;
    // Start is called before the first frame update
    void Start()
    {
        steeringAgent = gameObject.GetComponent<SteeringAgent>();
    }

    // Update is called once per frame
    void Update()

    {
        if(_targetControl  == null && GameObject.Find("gameManager").GetComponent<targetControl>() != null)
        {
            _targetControl = GameObject.Find("gameManager").GetComponent<targetControl>();
        }
        if (!steeringAgent.isFreezed)
        {
            checkAroundforSeeker();
        }
    }

    public void getFreezed()
    {
        
       // Debug.Log("In freezing");
        if(steeringAgent.isFreezed == false)
        {
            steeringAgent.isFreezed = true;
            steeringAgent.GetComponent<Animator>().enabled = false;
            StartCoroutine( timeBeforSwitching(5));

        }
        

    }
    public void getUnFreezed() {

        if(steeringAgent.isFreezed == true)
        {
            _targetControl.removeFromListFrozenAgent(this.GetComponent<SteeringAgent>());
            steeringAgent.isFreezed = false;
            steeringAgent.wandering = true;
            if (!gameObject.CompareTag("Player"))
            {
                steeringAgent.checkPathFinding();
            }
            steeringAgent.GetComponent<Animator>().enabled = true;

        }
    }

    IEnumerator timeBeforSwitching(int secs)
    {
        _targetControl.addToListFrozenAgent(this.GetComponent<SteeringAgent>());
        yield return new WaitForSeconds(secs);

        if (gameObject.CompareTag("Player"))
        {
            Debug.Log("Stop the game");
            if (callPlayerDied != null)
            {
                
                callPlayerDied();
            }
        }
        if (steeringAgent.isFreezed == true)
        {
            _targetControl.removeFromListFrozenAgent(this.GetComponent<SteeringAgent>());



            Object.FindObjectOfType<createObject>().createNewObject(steeringAgent.transform.position, steeringAgent.transform.rotation, 0);
            GameObject.Destroy(this.gameObject);
            gameObject.SetActive(false);
        }
        
    }

    public void checkAroundforSeeker()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

      
        foreach (Collider hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("evader"))
            {
                if (hitCollider.gameObject.GetComponent<SteeringAgent>().isFreezed)
                {
                    hitCollider.gameObject.GetComponent<freeze>().getUnFreezed();
                }

                
            }
        }


    }
}
