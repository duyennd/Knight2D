
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuController : MonoBehaviour
{
    public GameObject guideUI;
    // Start is called before the first frame update

    public AudioMixer audioMixer;

    void Start()
    {
         guideUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void _PlayButton(){
        // dieu huong
        //Application.LoadLevel("GamePlay");
        SceneManager.LoadScene("Scene0");
    }
    public void _StartButton(){
        // dieu huong
        //Application.LoadLevel("GamePlay");
        SceneManager.LoadScene("Scene1");
    }

    // public void _GuideButton(){
    //     guideUI.SetActive(true);
    // }
    //  public void _ExitButton(){
    //     guideUI.SetActive(false);
    // }

    public void _QuitButton(){
        Application.Quit();
    }

    public void SetVolume(float volume){
       // Debug.Log(volume);
       audioMixer.SetFloat("volume",volume);
    }
}
