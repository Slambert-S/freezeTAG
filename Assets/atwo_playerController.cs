using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atwo_playerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction;
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed = 200f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {


       // transform.position.(_direction * speed * Time.deltaTime);
        Vector3 movement = _direction * speed * Time.deltaTime;

        // Move the character's position
        transform.position += movement;

        if (movement.magnitude > 0f)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
    }
   /* public void move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y);
    }*/
}
