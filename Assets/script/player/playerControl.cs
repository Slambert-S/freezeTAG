using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Animator animator;
   
    // Update is called once per frame
    void Update()
    {

        Camera cam = Camera.main;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        if(movement.magnitude != 0)
        {
            transform.rotation = Quaternion.LookRotation(movement);
            animator.SetBool("walking", true);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("running", true);
            }
            else
            {
                animator.SetBool("running", false);
            }
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }
}
