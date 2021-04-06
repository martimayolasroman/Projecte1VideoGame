﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject torretAnim;
    Animator animator;
    private bool canAtak = true;
    float cooldown = 0;
    public float startCooldown;
   public GameObject bullet;
    Vector3 shootingDir;
    float rotZ;
    public GameObject posToInitBullet;
    public float directiony;
    public float directionx;

    void Start()
    {
        animator = torretAnim.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        shootingDir =  transform.position - new Vector3(0, directiony, directionx);
        //Calculem els graus que rotarem per apuntar a la direcció
        rotZ = Mathf.Atan2(shootingDir.y, shootingDir.x) * Mathf.Rad2Deg + 90f;

        if (cooldown <= 0)
        {
            cooldown = startCooldown;
            canAtak = true;
        }
        else
        {
            //Decrementem el cooldown
            cooldown -= Time.deltaTime;
            canAtak = false;
        }

        
        
          
            if (canAtak == true)
            {
                Attack();
                animator.SetBool("IsInactive", false);

            }
        

        
       
    }

    private void Attack()
    {
        Instantiate(bullet, posToInitBullet.transform.position, Quaternion.Euler(0f, 0f, rotZ)).GetComponent<FIreBullet>().SetUp(shootingDir);

    }
}