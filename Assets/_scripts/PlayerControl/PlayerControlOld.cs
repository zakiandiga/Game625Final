using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlOld : MonoBehaviour
{
    CharacterController control;

    [SerializeField] private float gravity;
    [SerializeField] private float allowMove;
    [SerializeField] private float moveSpeed, runSpeed, turnSpeed;
    private float inputX, inputY;
    private Vector3 moveDir = Vector3.zero;
    

    public Transform camera;

    // Start is called before the first frame update
    void Start()
    {
        control = GetComponent<CharacterController>();
    }

    private void PlayerMove()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        Vector3 forward = camera.forward;
        Vector3 right = camera.right;

        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        moveDir = forward * inputY + right * inputX;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDir), turnSpeed * Time.deltaTime);

    }

    void InputMagnitude()
    {
        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");

        //calculation
        moveSpeed = (new Vector2(inputX, inputY).sqrMagnitude);

        if(moveSpeed > allowMove)
        {
            PlayerMove();

        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        InputMagnitude();

        moveDir.y += Physics.gravity.y * gravity * Time.deltaTime;
        control.Move((moveDir * runSpeed) * Time.deltaTime);
    }
}
