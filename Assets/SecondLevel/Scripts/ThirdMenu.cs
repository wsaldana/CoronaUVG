﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ThirdMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
/*    public GameObject GameFinishedMenuUI;*/
    public AudioSource Song2D;


    // Start is called before the first frame update
    void Start()
    {
        Song2D.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        player_won();

        if (Input.GetKeyDown(KeyCode.Escape) /*&& !GameFinishedMenuUI.activeSelf*/)
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.visible = false;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void player_won()
    {
/*        if (final_counter == 6)
        {
            GameFinishedMenuUI.SetActive(true);
            Time.timeScale = 0f;
            Song2D.Stop();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }*/
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 4);
/*        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1f;*/
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        Cursor.visible = false;
/*        GameFinishedMenuUI.SetActive(false);*/
        Cursor.lockState = CursorLockMode.None;
    }
}
