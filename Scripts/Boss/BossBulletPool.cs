using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletPool : MonoBehaviour
{
    public static BossBulletPool SharedInstance;
    public List<GameObject> poolBullet;
    public GameObject bulletPrefab;
    public int poolSize;

    void Awake()
    {
        SharedInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        poolBullet = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < poolSize; i++)
        {
            tmp = Instantiate(bulletPrefab);
            tmp.SetActive(false);
            poolBullet.Add(tmp);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (!poolBullet[i].activeInHierarchy)
            {
                poolBullet[i].SetActive(true);
                return poolBullet[i];
            }
        }
        GameObject bullet = Instantiate(bulletPrefab);
        poolBullet.Add(bullet);
        return bullet;
    }


    // Update is called once per frame
    void Update()
    {

    }
}
