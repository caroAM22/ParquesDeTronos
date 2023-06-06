using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionScreen : MonoBehaviour
{

    [SerializeField] private Button _instruButton;

    private void Start()
    {
        _instruButton.onClick.AddListener(IButtonClicked);
    }

    public void IButtonClicked()
    {
        _instruButton.interactable = false;
        GameManager.Instance.Instruction();
    }
}

