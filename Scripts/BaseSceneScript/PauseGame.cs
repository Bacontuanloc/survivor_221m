using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
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
        Time.timeScale = 0;
        pausePanel.SetActive(false);

    }

    public void BackToMainMenu()
    {
        
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 0;
        pausePanel.SetActive(false);
    }
}
