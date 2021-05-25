using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WizardWeapon2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject wizanim;
    private bool canAtak = true;
    float cooldown = 0;
    public float startCooldown;
    public GameObject bullet;
    Vector3 shootingDir, shootingDir2, shootingDir3;
    float rotZ;
    public GameObject posToInitBullet;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        shootingDir = transform.position - new Vector3(player.transform.position.x, player.transform.position.y, 0);
        shootingDir = transform.position - new Vector3(player.transform.position.x, player.transform.position.y, 0);
        shootingDir = transform.position - new Vector3(player.transform.position.x, -player.transform.position.y - 1000, 0);

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

        }




    }

    private void Attack()
    {
        Instantiate(bullet, posToInitBullet.transform.position, Quaternion.Euler(0f, 0f, rotZ)).GetComponent<FireWizControl>().SetUp(shootingDir);
        Instantiate(bullet, posToInitBullet.transform.position, Quaternion.Euler(0f, 0f, rotZ)).GetComponent<FireWizControl>().SetUp(shootingDir2);
        Instantiate(bullet, posToInitBullet.transform.position, Quaternion.Euler(0f, 0f, rotZ)).GetComponent<FireWizControl>().SetUp(shootingDir3);

    }

}