using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Sounds
{
    BACKGROUND = 0,
    EFFECT =1
};

public class SoundManagerBehaviour : MonoBehaviour
{
    private AudioSource[] soundList;

    static private SoundManagerBehaviour instance;

    private SoundManagerBehaviour() 
    {
        instance = this;
    } 

    public static SoundManagerBehaviour GetInstance()
    {
        if (instance == null)
        {
            Debug.Log("Need create an instance");
        }
        return instance;
    }
    // Start is called before the first frame update
    void Start()
    {
        soundList = GetComponents<AudioSource>();
    }

    public void StartMusic(Sounds sid) 
    {
        int id = (int)sid;
        Debug.Log("Sound " + id);
        if (id < soundList.Length) 
        {
            soundList[id].Play();
        }
    }

    public void StopMusic(Sounds sid) 
    {
        int id = (int)sid;  
        if (id< soundList.Length)
        {
            soundList[id].Stop();
        }
    }

    public void StopAll() 
    {
        for (int i =0; i < soundList.Length; i++)
        {
            soundList[i].Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKey(KeyCode.P))
        {
            StopMusic(Sounds.BACKGROUND);
        }
        if (Input.GetKey(KeyCode.S))
        {
            StartMusic(Sounds.BACKGROUND);
        }
    }
}
