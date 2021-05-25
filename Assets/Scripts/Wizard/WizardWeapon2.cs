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
    float rotZ, rotZ2, rotZ3;
    public GameObject posToInitBullet;
    public GameObject player;
    WizardController wz;
    public GameObject wizard2;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        wz = FindObjectOfType<WizardController>();
    }

    // Update is called once per frame
    void Update()
    {
        //actualitza dades si s'ha canviat el player
        player = GameObject.FindGameObjectWithTag("Player");
        wz = FindObjectOfType<WizardController>();

        shootingDir =  new Vector3(player.transform.position.x,player.transform.position.y , 0) - posToInitBullet.transform.position ;
        shootingDir2 =  new Vector3(player.transform.position.x, player.transform.position.y+7,0) - posToInitBullet.transform.position;
        shootingDir3 = new Vector3(player.transform.position.x, player.transform.position.y -7,0) - posToInitBullet.transform.position;

        //Calculem els graus que rotarem per apuntar a la direcció
        rotZ = Mathf.Atan2(shootingDir.y, shootingDir.x) * Mathf.Rad2Deg + 90f;
        rotZ2 = Mathf.Atan2(shootingDir2.y, shootingDir2.x) * Mathf.Rad2Deg + 90f;
        rotZ3 = Mathf.Atan2(shootingDir3.y, shootingDir3.x) * Mathf.Rad2Deg + 90f;


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


        if (canAtak == true && wz.wiz2atac)
        {
            Attack();
            wizard2.GetComponent<Animator>().SetTrigger("Atak");

        }

    }

    private void Attack()
    {
        Instantiate(bullet, posToInitBullet.transform.position, Quaternion.Euler(0f, 0f, rotZ)).GetComponent<FireWizControl>().SetUp(shootingDir);
        Instantiate(bullet, posToInitBullet.transform.position, Quaternion.Euler(0f, 0f, rotZ2)).GetComponent<FireWizControl>().SetUp(shootingDir2);
        Instantiate(bullet, posToInitBullet.transform.position, Quaternion.Euler(0f, 0f, rotZ3)).GetComponent<FireWizControl>().SetUp(shootingDir3);

    }

}