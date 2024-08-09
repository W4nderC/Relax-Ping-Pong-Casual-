using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SpawnBallUI : MonoBehaviour
{
    [SerializeField] private Button spawnBallBtn;
    [SerializeField] private SpawnBall spawnBall;

    private void Awake() {
        spawnBallBtn.onClick.AddListener(() => {
            spawnBall.SpawnNewBall();
            Hide();
        });  
    }

    private void Start() {
        spawnBall.OnRespawnBall += spawnBall_OnRespawnBall;
        Hide();
    }

    private void spawnBall_OnRespawnBall (object sender, EventArgs e) {
        Show();
    }

    private void Show () {
        gameObject.SetActive(true);
    }
    
    private void Hide () {
        gameObject.SetActive(false);
    }}
