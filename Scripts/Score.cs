using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int scoreNum;
    public Text enemiesDestroyedText;
    // Start is called before the first frame update
    void Start()
    {
        scoreNum = 0;
        enemiesDestroyedText = GameObject.FindWithTag("Score").GetComponent<Text>();
    }

    public void updateScore(bool hit)
    {
        if (hit)
        {
            scoreNum += 1;
            enemiesDestroyedText.text = "Enemy: " + scoreNum;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
