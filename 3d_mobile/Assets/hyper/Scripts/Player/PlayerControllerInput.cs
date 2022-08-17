using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerInput : MonoBehaviour
{
    public InputMaster controls;

    public void Awake()
    {
        //controls.Player.Attack.performed += _ => Attack();
        //controls.Player.Movement.performed += _ => Movement(ctx.ReadValue<Vector2>());
    }

    void Movement(Vector2 direction)
    {
        Debug.Log(direction);
    }

    void Attack()
    {
        Debug.Log("attack");
    }

    private void OnEnable()
    {
        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}

