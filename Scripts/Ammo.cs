using Assets.Scripts.Char;
using Assets.Scripts.WeaponManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaponFactory = Assets.Scripts.WeaponManagement.WeaponFactory;

public class Ammo : MonoBehaviour
{
    private int damage = 5;
    private Bounds screenBounds;
    private WeaponFactory weaponFactory;
    public Observable<bool> UpdateScore = new Observable<bool>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Xu ly va cham giua bullet weapon cua character vs enemy
        if (collision.gameObject.CompareTag("Enemy") && gameObject.CompareTag("Bullet"))
        {
            weaponFactory = gameObject.AddComponent<WeaponFactory>();
            GameObject pickedWeapon = weaponFactory.CreateWeapon(MainBehaviour.pickedCharacter);
            Weapon weapon = pickedWeapon.GetComponent<Weapon>();
            Pistol pistol = weapon as Pistol;
            Kunai kunai = weapon as Kunai;
            float weaponDamage = pistol != null ? pistol.damage : kunai.damage;
            Creep creep = collision.gameObject.GetComponent<Creep>();
            if (creep is Monster)
            {
                Monster monster = creep as Monster;
                monster.health = monster.health - weaponDamage;
                if (monster.health <= 0)
                {
                    Destroy(collision.gameObject);
                    UpdateScore.Notify(true);
                }
                this.gameObject.SetActive(false);
            }
            else if (creep is FastMonster)
            {
                FastMonster fastMonster = creep as FastMonster;
                fastMonster.health = fastMonster.health - weaponDamage;
                if (fastMonster.health <= 0)
                {
                    Destroy(collision.gameObject);
                    UpdateScore.Notify(true);
                }
                this.gameObject.SetActive(false);
            }
            else
            {
                TankMonster tankMonster = creep as TankMonster;
                tankMonster.health = tankMonster.health - weaponDamage;
                if (tankMonster.health <= 0)
                {
                    Destroy(collision.gameObject);
                    UpdateScore.Notify(true);
                }
                this.gameObject.SetActive(false);
            }
        }
        if (collision.gameObject.CompareTag("Boss") && gameObject.CompareTag("Bullet"))
        {
            Boss boss = collision.gameObject.GetComponent<Boss>();
            boss.health = boss.health - damage;
            if (boss.health <= 0)
            {
                Destroy(collision.gameObject);
            }
            this.gameObject.SetActive(false);
        }
        //Xu ly va cham giua bullet cua boss vs character
        if (collision.gameObject.CompareTag("MC") && gameObject.CompareTag("BossBullet"))
        {
            Boss boss = collision.gameObject.GetComponent<Boss>();
            Character character = collision.gameObject.GetComponent<Character>();
            Luciano luciano = character as Luciano;
            Geran geran = character as Geran;
            Tomee tomee = character as Tomee;
            if (luciano != null)
            {
                luciano.health -= boss.damage;
                if (luciano.health <= 0)
                {
                    Destroy(collision.gameObject);
                }
                this.gameObject.SetActive(false);
            }
            else if(geran != null)
            {
                geran.health -= boss.damage;
                if (geran.health <= 0)
                {
                    Destroy(collision.gameObject);
                }
                this.gameObject.SetActive(false);
            }
            else
            {
                tomee.health -= boss.damage;
                if (tomee.health <= 0)
                {
                    Destroy(collision.gameObject);
                }
                this.gameObject.SetActive(false);
            }
        }
        screenBounds = OrthographicBounds(Camera.main);
        Vector3 DownLeft = new Vector3(screenBounds.min.x, screenBounds.min.y, 0);
        Vector3 UpLeft = new Vector3(screenBounds.min.x, screenBounds.max.y, 0);
        Vector3 DownRight = new Vector3(screenBounds.max.x, screenBounds.min.y, 0);
        Vector3 UpRight = new Vector3(screenBounds.max.x, screenBounds.max.y, 0);
        if (this.transform.position.y < DownLeft.y || this.transform.position.x > DownRight.x
            || this.transform.position.x < DownLeft.x || this.transform.position.y > UpRight.y)
        {
            this.gameObject.SetActive(false);
        }

    }
    private Bounds OrthographicBounds(Camera camera)
    {

        float screenAspect = (float)Screen.width / (float)Screen.height;

        float cameraHeight = camera.orthographicSize * 2;

        Bounds bounds = new Bounds(

            camera.transform.position,

            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));

        return bounds;
    }
}
