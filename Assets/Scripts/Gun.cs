using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    [SerializeField]
  GameObject Prefab;
    [SerializeField]
    Transform fire;
    [SerializeField]
    Animator animator;

    public void OnFire(InputValue inputValue)
    {
       if (inputValue.isPressed)
        {
            Fire();
        }
    }

    public void OnReload(InputValue inputValue)
    {
        if (inputValue.isPressed)
        {
        animator.SetTrigger("Reload");
        }
    }

    void Fire()
    {
        animator.SetTrigger("Fire");
        GameObject gameObject = Instantiate(Prefab,fire.position,fire.rotation);

    }
    




}
