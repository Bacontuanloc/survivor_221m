using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Creep
{
    public float speed = 7f;
    public float health =20f;
    public float damage = 7f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveToMC();
    }

    protected void MoveToMC()
    {
        GameObject mc = GameObject.FindWithTag("MC");
        gameObject.transform.position = Vector3.MoveTowards(transform.position, mc.transform.position, speed * Time.deltaTime);
        
    }


}
