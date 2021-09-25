
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameoverUI;
    //public bool pause = false;
   public Text endScoreText;
   public Text bestScoreText;

   public gamemaster gmaster;

    // Start is called before the first frame update
    void Start()
    {
    gmaster=GameObject.FindGameObjectWithTag("gamemaster").GetComponent<gamemaster>();
       gameoverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
           endScoreText.text =(""+gmaster.points);
           bestScoreText.text =(""+gmaster.highscore);
    }
    public void __retry(){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
         
    public void __restart(){
        SceneManager.LoadScene("Scene1");

        }
    public void __quit(){
            Application.Quit();

        }
    public void _gameOver(){
        gameoverUI.SetActive(true);
        Time.timeScale = 0;

    }
}