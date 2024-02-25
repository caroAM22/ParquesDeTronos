using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private int jugadorActual=1;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        MainMenu();
    }

    public int getJugadorActual()
    {
        return jugadorActual;
    }
    public void configuration()
    {
        HandleConfigure();
    }

    public void MainMenu()
    {
        HandleMenu();
    }

    public void GamePlay()
    {
        HandleGameplay();
    }

    public void Instruction()
    {
        HandleInstruction();
    }

    void HandleMenu()
    {
        Debug.Log("Loading Menu...");
        SceneManager.LoadScene("MainMenu");
    }

    void HandleInstruction()
    {
        Debug.Log("Loading Menu...");
        SceneManager.LoadScene("Instruction");
    }

    void HandleConfigure()
    {
        Debug.Log("Loading Configure...");
        SceneManager.LoadScene("Configuration");
    }

    void HandleGameplay()
    {
        Debug.Log("Loading Gameplay...");
        StartCoroutine(LoadGameplayAsyncScene("Gameplay"));
    }

    public void movimiento()
    {
        Debug.Log("Movimiento...");
        if (jugadorActual == 4)
        {
            jugadorActual = 1;
        }
        else
        {
            jugadorActual++;
        }
    }


    IEnumerator LoadGameplayAsyncScene(string scene)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        yield return new WaitForSeconds(1f);

    }

}
