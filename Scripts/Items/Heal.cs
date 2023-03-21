using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Item
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("MC"))
        {
            GameObject mc = GameObject.FindWithTag("MC");
            if(mc.GetComponent<Character>().current_health+ mc.GetComponent<Character>().health*0.2f> mc.GetComponent<Character>().health)
            {
                mc.GetComponent<Character>().current_health = mc.GetComponent<Character>().health;
            }
            else
            {
                mc.GetComponent<Character>().current_health = mc.GetComponent<Character>().current_health + mc.GetComponent<Character>().health * 0.2f;
            }
            Destroy(gameObject);

        }
    }
}