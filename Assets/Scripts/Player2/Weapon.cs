using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float offset;
    public GameObject bullet;

    float cooldown;

    [Header("Time of cooldown")]
    public float startCooldown;

    public Player2Moviment player;


    Vector3 shootingDir;

    bool active;

    private void Start()
    {
        active = true;

    }

    private void Update()
    {
        //Calculem el vector direcció de el shooting point fins el cursor
        shootingDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //Calculem els graus que rotarem per apuntar a la direcció
        float rotZ = Mathf.Atan2(shootingDir.y, shootingDir.x) * Mathf.Rad2Deg;
        //Rotem el firePoint
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        //Mirem si el cooldown ens deixa disparar
        if (cooldown <= 0)
        {
            if (active && Input.GetButtonDown("Fire1"))
            {
                //Animació de disparar
                //player.anim.SetTrigger("isAttacking");
                Shoot();
                cooldown = startCooldown;
            }
        }
        else
        {
            //Decrementem el cooldown
            cooldown -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        //Instantiate(bullet, transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce(Vector2.right * 15, ForceMode2D.Impulse);
        //Instantiate(bullet, transform.position, transform.rotation).GetComponent<Rigidbody2D>().AddForce(shootingDir.normalized * 20, ForceMode2D.Impulse);
        Instantiate(bullet, transform.position, transform.rotation).GetComponent<ShootController>().SetUp(shootingDir);
    }

    public void Activate()
    {
        active = true;
    }
}