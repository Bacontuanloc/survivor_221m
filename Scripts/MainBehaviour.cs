using Assets.Scripts.Char;
using Assets.Scripts.WeaponManagement;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

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

    public WeaponType weaponType;

    public static string pickedCharacter;

    private Timer timer;

    List<Vector3> points;

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
        GameObject character = characterFactory.Create(pickedCharacter);
        //GameObject weapon = Instantiate(gunPrefab);
        GameObject weapon = weaponFactory.InstantiateWeapon(pickedCharacter);

        Renderer renderer = character.GetComponent<Renderer>();
        Vector3 size = renderer.bounds.size;
        Vector3 localTopRight = new Vector3(size.x / 2, size.y / 2, 0);
        Vector3 worldTopRight = character.transform.TransformPoint(localTopRight);
        Vector3 localTopLeft = new Vector3(-size.x / 2, size.y / 2, 0);
        Vector3 worldTopLeft = character.transform.TransformPoint(localTopLeft);

        weapon.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
        weapon.transform.position = (worldTopLeft + worldTopRight) / 2;
        weapon.transform.parent = character.transform;
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = duration;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
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

        if (timer.Finished)
        {
            //GameObject enemy = ObjectPoolManager.SharedInstance.GetPooledObject();
            //if(enemy != null)
            //{
            //    enemy.SetActive(true);
            //    enemy.transform.position = getRandomPoint();
            //}
            //GameObject enemy = Instantiate(enemyPrefab);
            int monster_total = 0;
            while (monster_total <= 3)
            {
                GameObject enemy = monsterFactory.Create("normal");
                enemy.transform.position = getRandomPoint();
            }
            while (monster_total <= 5)
            {
                GameObject fast = monsterFactory.Create("fast");
                fast.transform.position = getRandomPoint();
            }
            while (monster_total <= 8)
            {
                GameObject tank = monsterFactory.Create("tank");
                tank.transform.position = getRandomPoint();
            }
            timer.Duration = 5;
            timer.Run();
        }
    }
}
