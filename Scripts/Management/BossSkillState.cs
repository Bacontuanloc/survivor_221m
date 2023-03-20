using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Management
{
    public class BossSkillState:State
    {
        private Boss Boss;

        public BossSkillState(Boss boss)
        {
            this.Boss = boss;
        }
        public override void EnterState()
        {
            
        }

        public override void ExitState()
        {
            
        }

        public override void UpdateState()
        {
            int skillIndex = Random.Range(0, 3);
            switch (skillIndex)
            {
                case 0:
                    Skill1();
                    break;
                case 1:
                    Skill2();
                    break;
                case 2:
                    Skill3();
                    break;
            }
            Boss.ChangeState(new BossChaseState(Boss));
        }

        public void Skill1()
        {
            float radius = 5f;
            float duration = 2f;
            float damage = 10f;
            GameObject mc = GameObject.FindWithTag("MC");
            float timeElapsed = 0.0f; 

            GameObject circle = new GameObject("Circle");
            circle.transform.position = Boss.transform.position;
            circle.transform.localScale = new Vector3(radius * 2, 0.1f, radius * 2);
            circle.AddComponent<MeshRenderer>().material.color = Color.red;
            while (timeElapsed < duration)
            {
                timeElapsed += Time.deltaTime;

                if (timeElapsed >= duration)
                {
                    Collider[] hits = Physics.OverlapSphere(circle.transform.position, radius);
                    foreach (Collider hit in hits)
                    {
                        if (hit.CompareTag("MC"))
                        {
                            Character player = hit.gameObject.GetComponent<Character>();
                            player.health -= damage;
                            break;
                        }
                    }
                    Object.Destroy(circle);
                    return;
                }
            }
            
            Object.Destroy(circle);
        }
        public void Skill2()
        {
            float radius = 5f;
            float duration = 2f;
            float damage = 10f;
            GameObject mc = GameObject.FindWithTag("MC");
            float timeElapsed = 0.0f;
            for (int i = 0; i < 10; i++)
            {

                Vector3 position = Camera.main.ViewportToWorldPoint(new Vector3(Random.value, Random.value, 0));
                GameObject circle = new GameObject("Circle");
                circle.transform.position = position;
                CircleCollider2D collider = circle.AddComponent<CircleCollider2D>();
                collider.radius = radius;
                CircleDamage circleDamage = circle.AddComponent<CircleDamage>();
                
                circleDamage.damage = damage;
                Object.Destroy(circle, 10f);
                SpriteRenderer renderer = circle.AddComponent<SpriteRenderer>();
                renderer.sprite = Sprite.Create(new Texture2D(1, 1), new Rect(0, 0, 1, 1), new Vector2(0.5f, 0.5f));
                float diameter = radius * 2f;
                renderer.transform.localScale = new Vector3(diameter, diameter, 1f);
            }
        }
        public void Skill3()
        {

        }
    }
}
