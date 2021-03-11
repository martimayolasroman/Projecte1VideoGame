using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.EventSystems;

public class Weapon : MonoBehaviour
{
    public float offset;
    public GameObject bullet;

    float cooldown;
    public GameObject joystickPress;
    [Header("Time of cooldown")]
    public float startCooldown;

    public Player2Moviment player;
    
    bool active;

    private void Start()
    {
        active = true;
        
    }

    private void Update()
    {
        //Calculem el vector direcció de el shooting point fins el cursor
        //Calculem els graus que rotarem per apuntar a la direcció
        //Mirem si el cooldown ens deixa disparar
        float rotZ = Mathf.Atan2(joystickPress.GetComponent<ButtonAttakDragon>().pos.y, joystickPress.GetComponent<ButtonAttakDragon>().pos.x)  * Mathf.Rad2Deg +90;

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (cooldown <= 0)
        {
            if (active && joystickPress.GetComponent<ButtonAttakDragon>().Pressed)
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
        player.GetComponent<Animator>().SetTrigger("Atak");
        Instantiate(bullet, transform.position, transform.rotation).GetComponent<ShootController>().SetUp(joystickPress.GetComponent<ButtonAttakDragon>().pos);
    }

    public void Activate()
    {
        active = true;
    }
}