using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public abstract class Creep : MonoBehaviour {

    // Start is called before the first frame update
    public static int level = 0;
    public abstract void ChangeState(CreepState newState);
    public abstract void TakeDamage(int damageAmount);
}
