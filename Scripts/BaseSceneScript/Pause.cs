using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StopGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("ChoosePlayer");
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
