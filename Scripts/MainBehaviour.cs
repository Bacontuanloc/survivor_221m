using Assets.Scripts.Char;
using Assets.Scripts.WeaponManagement;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MainBehaviour : MonoBehaviour
{
    private Bounds screenBounds;

    [SerializeField]
    public int duration;

    public GameObject enemyPrefab;

    public GameObject gunPrefab;

    public MonsterFactory monsterFactory;

    public CharacterFactory characterFactory;

    public WeaponFactory weaponFactory;
    public GameObject BossPrefab;
    public static string pickedCharacter;
    GameObject character;

    private Timer timer;

    List<Vector3> points;
    public Text enemiesDestroyedText;

    public Score score;

    private Bounds OrthographicBounds(Camera camera)
    {

        float screenAspect = (float)Screen.width / (float)Screen.height;

        float cameraHeight = camera.orthographicSize * 2;

        Bounds bounds = new Bounds(

            camera.transform.position,

            new Vector3(cameraHeight * screenAspect, cameraHeight, 0));

        return bounds;
    }

    Vector3 getRandomPoint()
    {
        return points[Random.Range(0, points.Count)];
    }

    // Start is called before the first frame update
    void Start()
    {
        monsterFactory= gameObject.AddComponent<MonsterFactory>();
        characterFactory = gameObject.AddComponent<CharacterFactory>();
        weaponFactory = gameObject.AddComponent<WeaponFactory>();

        //GameObject character = characterFactory.CreateLuciano();
        character = characterFactory.Create(pickedCharacter);
        //GameObject weapon = Instantiate(gunPrefab);
        GameObject weapon = weaponFactory.InstantiateWeapon(pickedCharacter);
        registerObserverEnemyKill(pickedCharacter);
        Physics2D.IgnoreCollision(weapon.GetComponent<Collider2D>(), character.GetComponent<Collider2D>());


        Renderer renderer = character.GetComponent<Renderer>();
        Vector3 size = renderer.bounds.size;
        Vector3 localTopRight = new Vector3(size.x / 2, size.y / 2, 0);
        Vector3 worldTopRight = character.transform.TransformPoint(localTopRight);
        Vector3 localTopLeft = new Vector3(-size.x / 2, size.y / 2, 0);
        Vector3 worldTopLeft = character.transform.TransformPoint(localTopLeft);
        //Vector3 rotation = new Vector3(0f, 0f, 90f);

        weapon.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
        weapon.transform.position = (worldTopLeft + worldTopRight) / 2;
        weapon.transform.parent = character.transform;
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = duration;
        timer.Run();
        Invoke("SummonBoss",120f);
    }

    void registerObserverEnemyKill(string pickedCharacter)
    {
        score = FindObjectOfType<Score>();
        if (score != null)
        {
            switch (pickedCharacter)
            {
                case "geran":
                    Bat batWeapon = FindObjectOfType<Bat>();
                    if (batWeapon != null)
                    {
                        batWeapon.UpdateScore.Subscribe(score.updateScore);
                    }
                    break;
                case "luciano":
                    Debug.Log("luciano");
                    
                    Ammo[] ammoList = FindObjectsOfType<Ammo>();
                   // GameObject[] ammoList = GameObject.FindGameObjectsWithTag("Bullet");
                    Debug.Log("Luciano "+ammoList.Length);
                    foreach (var ammo in ammoList)
                    {
                        ammo.UpdateScore.Subscribe(score.updateScore);
                    }
                    break;
                case "tomeee":
                    //Ammo[] ammoList = FindObjectsOfType<Ammo>();
                    GameObject[] ammoList1 = GameObject.FindGameObjectsWithTag("Bullet");
                    foreach (var ammo in ammoList1)
                    {
                        ammo.GetComponent<Ammo>().UpdateScore.Subscribe(score.updateScore);
                    }
                    break;
                default:
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // registerObserverEnemyKill(pickedCharacter);
        Ammo[] ammoList = FindObjectsOfType<Ammo>();
        // GameObject[] ammoList = GameObject.FindGameObjectsWithTag("Bullet");
        Debug.Log("Luciano " + ammoList.Length);
        foreach (var ammo in ammoList)
        {
            ammo.UpdateScore.Subscribe(score.updateScore);
        }
        screenBounds = OrthographicBounds(Camera.main);

        points = new List<Vector3>();
		Vector3 DownLeft = new Vector3(screenBounds.min.x, screenBounds.min.y, 0);
		points.Add(DownLeft);
        Vector3 UpLeft = new Vector3(screenBounds.min.x, screenBounds.max.y, 0);
        points.Add(UpLeft);
        Vector3 DownRight = new Vector3(screenBounds.max.x, screenBounds.min.y, 0);
        points.Add(DownRight);
        Vector3 UpRight = new Vector3(screenBounds.max.x, screenBounds.max.y, 0);
        points.Add(UpRight);
        GameObject boss = GameObject.FindWithTag("Boss");
        if (boss == null)
        {
            if (timer.Finished)
            {
                //GameObject enemy = ObjectPoolManager.SharedInstance.GetPooledObject();
                //if(enemy != null)
                //{
                //    enemy.SetActive(true);
                //    enemy.transform.position = getRandomPoint();
                //}
                //GameObject enemy = Instantiate(enemyPrefab);
                GameObject enemy = monsterFactory.Create("normal");
                enemy.transform.position = getRandomPoint();
                GameObject fast = monsterFactory.Create("fast");
                fast.transform.position = getRandomPoint();
                GameObject tank = monsterFactory.Create("tank");
                tank.transform.position = getRandomPoint();

                timer.Duration = duration;
                timer.Run();
            }
        }
    }
    void SummonBoss()
    {
        GameObject boss = Instantiate(BossPrefab);
        Vector3 bossSpawnLocation = Vector3.zero;
        bossSpawnLocation.x = character.transform.position.x;
        bossSpawnLocation.y = character.transform.position.y+5;
        boss.transform.position = bossSpawnLocation;
        GameObject[] monster = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject m in monster)
        {
            Destroy(m);
        }
        
    }
}
