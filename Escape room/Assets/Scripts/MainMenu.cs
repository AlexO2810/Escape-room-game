using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string game;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(game);
    }
    public void OpenOptions()
    {

    }
    public void CloseOptions()
    {

    }
    public void QiutGame()
    {
        Application.Quit();
        Debug.Log("Qiting");
    }
}
