using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    [SerializeField] GameManager gameManager;

    public event EventHandler OnRespawnBall;

    private int numberOfBallOnScene;

    private void Awake()
    {
        gameManager.OnWaitingToStart += gameManager_OnWaitingToStart;
    }

    private void Update() {
        numberOfBallOnScene = GameObject.FindGameObjectsWithTag("Ball").Length;

        if(numberOfBallOnScene == 0 && GameManager.Instance.IsGamePlaying()) {
            OnRespawnBall?.Invoke(this, EventArgs.Empty);
        }
    }

    private void gameManager_OnWaitingToStart (object sender, EventArgs e) {
        SpawnNewBall();
    }

    public void SpawnNewBall () {
        Instantiate(ballPrefab, transform.position, Quaternion.identity);
    }

    private void OnDestroy()
    {
        gameManager.OnWaitingToStart -= gameManager_OnWaitingToStart;
    }
}
