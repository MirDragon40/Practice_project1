using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveAbility : PlayerAbility
{
    private float _gravity = -9.8f;  // 중력 변수
    private float _yVelocity = 0f;

    private CharacterController _characterController;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();

    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();
        dir = Camera.main.transform.TransformDirection(dir);

        _yVelocity += _gravity * Time.deltaTime;
        dir.y = _yVelocity;

        float moveSpeed = _owner.Stat.MoveSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = _owner.Stat.RunSpeed;
        }

        _characterController.Move(dir * (moveSpeed * Time.deltaTime));

        if (_characterController.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _yVelocity = _owner.Stat.JumpPower;
        }



    }
}
