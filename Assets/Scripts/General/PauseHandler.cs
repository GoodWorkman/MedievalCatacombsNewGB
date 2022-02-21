using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseHandler : MonoBehaviour
{
    public GameObject pauseScreen;
    public UnityEvent onStartPause;
    public UnityEvent onEndPause;
    
    private bool _isPaused = false;
    
    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) ChangeStatus();
    }
    private void ChangeStatus()
    {
        if (!_isPaused)
        {
            onStartPause.Invoke();
            pauseScreen.SetActive(true);
            Time.timeScale = 0;
        }
        else 
        {
            onEndPause.Invoke();
            pauseScreen.SetActive(false);
            Time.timeScale = 1;

        }
        _isPaused = !_isPaused;
    }

   
}
