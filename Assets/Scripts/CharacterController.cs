using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Animator _animator;
    [SerializeField] private int _speedMultiplier = 2;
    // Update is called once per frame 
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        movement.Normalize();

        transform.position = Vector3.MoveTowards(transform.position, transform.position + movement, Time.deltaTime * _movementSpeed);
        Quaternion targetRotation = Quaternion.LookRotation(new Vector3(horizontalInput, 0, verticalInput));
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * _rotationSpeed);

        float calculatedSpeed = Mathf.Clamp(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput), 0, 1);

        if (Input.GetKey(KeyCode.LeftShift)) {
            calculatedSpeed *= _speedMultiplier;
            _movementSpeed = Mathf.Clamp(_movementSpeed, 2, _movementSpeed * _speedMultiplier);
        } 

        if (Input.GetKeyDown(KeyCode.Space)) {
            _animator.SetTrigger("JumpTrigger");
        }

        _animator.SetFloat("MovementSpeed", calculatedSpeed);
    }
}
