using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigureScreen : MonoBehaviour
{

    [SerializeField] private Button _returnButton;

    private void Start()
    {
        _returnButton.onClick.AddListener(BackButtonClicked);
    }

    public void BackButtonClicked()
    {
        _returnButton.interactable = false;
        GameManager.Instance.MainMenu();
    }
}