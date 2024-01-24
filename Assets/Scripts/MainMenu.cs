using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settings;
    public void PlayGame(){
        SceneManager.LoadSceneAsync("HUB");
    }
    public void Quit(){

        Application.Quit();
    }
    public void OpenSettings(){
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }
    public void returnMenu(){
        settings.SetActive(false);
        mainMenu.SetActive(true);
    }
}
