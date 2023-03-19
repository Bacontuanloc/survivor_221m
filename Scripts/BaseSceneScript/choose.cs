using Assets.Scripts.WeaponManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChoosePlayer()
    {
        MainBehaviour.pickedCharacter = gameObject.name;
        Application.LoadLevel("SampleScene");     
    }
}
