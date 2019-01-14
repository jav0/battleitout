using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    
    public Slider sl;
    
    public void Start() {
        if (Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (PlayerPrefs.HasKey("Sensitivity"))
        {
            sl.value = PlayerPrefs.GetFloat("Sensitivity");
        } else {
            PlayerPrefs.SetFloat("Sensitivity", 3f);
        }
    }
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void QuitGame() {
        Debug.Log("QUIT");
        Application.Quit();
    }
}
