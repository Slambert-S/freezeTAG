using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atwo_freezeBomb : MonoBehaviour
{
   public void trowFreezeBomb(Collider enemy, Vector3 bombPosition, int chargeLeft)
   {
        bool canTrowBomb = this.gameObject.GetComponent<atwo_variable_reference>().canTrowBomb;
        if (chargeLeft > 0 && canTrowBomb == true)
        {
            this.gameObject.GetComponent<atwo_variable_reference>().canTrowBomb = false;
            this.gameObject.GetComponent<atwo_variable_reference>().bombCharge--;
            enemy.transform.parent.GetComponent<atwo_variable_reference>().isFreesed = true;
            StartCoroutine(timerForNewBomb(enemy));
            Debug.Log("Trow a freeze bomb on " + enemy.transform.parent.name);
        }


   }
    
    public void getFreezed()
    {
        GetComponent<atwo_variable_reference>().isFreesed = true;

        StartCoroutine(timerForunfreeze());
    }
    IEnumerator timerForNewBomb(Collider enemy)
    {

        yield return new WaitForSeconds(5f);
        enemy.transform.parent.GetComponent<atwo_variable_reference>().isFreesed = false;
        this.gameObject.GetComponent<atwo_variable_reference>().canTrowBomb = true;
        //.SetData("needEvadePath", true);
        Debug.Log("can trow new bomb");
    }
    IEnumerator timerForunfreeze()
    {

        yield return new WaitForSeconds(5f);
        GetComponent<atwo_variable_reference>().isFreesed = false;
        //.SetData("needEvadePath", true);
       
    }
}
