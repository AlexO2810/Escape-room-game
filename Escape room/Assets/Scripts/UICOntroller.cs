using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UICOntroller : MonoBehaviour
{
    [SerializeField] UnityEvent onPasue;
    [SerializeField] UnityEvent onRun;
    [SerializeField] UnityEvent onNotesOpen;
    [SerializeField] UnityEvent onNotesClose;
    public UnityEvent OnPasue => onPasue;
    public UnityEvent OnRun => onRun;
    public UnityEvent OnNotesOpen => onNotesOpen;
    public UnityEvent OnNotesClose => onNotesClose;
    
    public static bool GameIsPaused = true;
    public static bool EnabledToPause = false;
    public static bool NotesOpen = false;
    public AudioMixer audioMixer;
    public string menu;
    private float volume;
    void Start()
    {
        Time.timeScale = 0f;
        audioMixer.SetFloat("Sounds",-80);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            
           if(EnabledToPause && !NotesOpen)
           {
            if(GameIsPaused)
            {
                GameIsPaused = false;
                Cursor.lockState = CursorLockMode.Locked;
                onRun?.Invoke();
                audioMixer.GetFloat("Buttons",out volume);
                audioMixer.SetFloat("Sounds",volume);
                Time.timeScale = 1f;
            }
            else
            {
                GameIsPaused = true;
                Cursor.lockState = CursorLockMode.None;
                onPasue?.Invoke();
                Time.timeScale = 0f;
                audioMixer.SetFloat("Sounds",-80);
            }
           }
           if(NotesOpen)
            {
                NotesOpen = false;
                Cursor.lockState = CursorLockMode.Locked;
                onNotesClose?.Invoke();
                audioMixer.GetFloat("Buttons",out volume);
                audioMixer.SetFloat("Sounds",volume);
                Time.timeScale = 1f;
            }
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
           if(!GameIsPaused)
           {
            if(!NotesOpen)
            {
                NotesOpen = true;
                Cursor.lockState = CursorLockMode.None;
                onNotesOpen?.Invoke();
                Time.timeScale = 0f;
                audioMixer.SetFloat("Sounds",-80);
            }
           }
        }
    }
    
    public void SetPause()
    {
        GameIsPaused = true;
        Time.timeScale = 0f;
        audioMixer.SetFloat("Sounds",-80);
    }
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void EnablePause()
    {
        EnabledToPause = true;
    }
    public void UnenabledToPause()
    {
        EnabledToPause = false;
    }
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(menu);
    }
    public void EndGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        audioMixer.GetFloat("Buttons",out volume);
        audioMixer.SetFloat("Sounds",volume);
    }
}
