using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    private int score;
    public int Ammo1;
    public TextMeshProUGUI Ammo;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI scoreText;
    public Button restartButton;
    
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateAmmo(0);
        Ammo1=1;
        UpdateScore(0);
        isGameActive = true;
       
    }
    public void UpdateAmmo(int AmmoToAdd)
    {
        Ammo1 = AmmoToAdd;
        Ammo.text = "Ammo:" + Ammo1 ;
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score;" + score;
    }

    public void GameOver()
    {

        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }
    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
