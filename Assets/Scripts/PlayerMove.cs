using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{   
    CharacterController cr;
    Animator animator;

    private void Start()
    {
        cr = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    [SerializeField]
    float  speed = 0f;
    [SerializeField]
    float MaxSpeed = 5f;

    Vector3 dir = Vector3.zero;

    public void OnMove(InputValue inputValue)
    {
         Vector2 gogi = inputValue.Get<Vector2>();
        dir = new Vector3(gogi.x, 0f, gogi.y).normalized;

    }

    public void Update()
    {
        Movespeed();
    }

    void Movespeed() 
    {

        if(dir == Vector3.zero) 
        {
            speed = 0f;
        }

        speed += Time.deltaTime;

        if(speed > MaxSpeed)
        {
            speed = MaxSpeed;
        }

        animator.SetFloat("XSpeed", dir.x * speed);
        animator.SetFloat("YSpeed", dir.z * speed);

        cr.Move(dir * speed * Time.deltaTime);


    }
}
