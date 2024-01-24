using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settings;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (GameIsPaused && !settings.activeSelf){
                Resume();
            }
            else if(GameIsPaused && settings.activeSelf) {
                returnPauseMenu();
            }
            else{
                Pause();
            }
        }
    }
    public void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void LoadMenu(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(0);
    }
    public void OpenSettings(){
        pauseMenuUI.SetActive(false);
        settings.SetActive(true);
    }
    public void returnPauseMenu(){
        settings.SetActive(false);
        pauseMenuUI.SetActive(true);
    }
}