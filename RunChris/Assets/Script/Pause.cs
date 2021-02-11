using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject GamePasue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Pause GAME
    public void PauseGame()
    {
        GamePasue.SetActive(true);
        Time.timeScale = 0f;
    }
    //Resume Game
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        GamePasue.SetActive(false);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
