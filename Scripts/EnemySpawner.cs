using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemyPrototype meleeEnemyPrototype;
    public EnemyPrototype rangedEnemyPrototype;

    public void SpawnMeleeEnemy()
    {
        EnemyPrototype enemy = meleeEnemyPrototype.Clone();
        Instantiate(enemy, transform.position, transform.rotation);
    }

    public void SpawnRangedEnemy()
    {
        EnemyPrototype enemy = rangedEnemyPrototype.Clone();
        Instantiate(enemy, transform.position, transform.rotation);
    }
}
