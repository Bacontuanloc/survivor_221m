using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.WeaponManagement
{
    public class Bat : MonoBehaviour, IWeapon
    {
        private float rotZ;
        public float rotationSpeed;
        void Start()
        {
            //InvokeRepeating("Shoot", 0f, rotationSpeed);
        }

        // Update is called once per frame
        void Update()
        {
            Shoot();
        }
        public void Shoot()
        {
            rotZ += Time.deltaTime * rotationSpeed;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
        }

        public void ExecuteSkill()
        {
            throw new NotImplementedException();
        }
    }
}
