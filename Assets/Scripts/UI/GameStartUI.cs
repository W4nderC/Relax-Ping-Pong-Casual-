using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameStartUI : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private GameManager gameManager;


    private void Awake() {
        startButton.onClick.AddListener(() => {
            gameManager.ClickToStartGame();
        });

    }

    private void Start() {
        gameManager.OnWaitingToStart += GameManager_OnWaitingToStart;

        Show();
    }


    private void GameManager_OnWaitingToStart (object sender, System.EventArgs e) {
        Hide();
    }

    private void Show () {
        gameObject.SetActive(true);

    }

    private void Hide () {
        gameObject.SetActive(false);
    }
}
