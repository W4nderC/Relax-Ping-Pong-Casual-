using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event EventHandler OnWaitingToStart;
    public event EventHandler OnGamePaused;
    public event EventHandler OnGameUnpaused;
    public event EventHandler OnGameOver;

    [SerializeField] private GameInput gameInput;

    private bool isGamePaused = false;
    private int numberOfCube;

    public enum GameState{
        WaitingToStart,
        Playing,
        Paused,
        GameOver
    }

    public GameState gameState;

    private void Awake()
    {
        if(Instance != null && Instance != this) {
            Destroy(this);
        } else {
            Instance = this;
        }

        gameInput.OnPauseAction += GameInput_OnPauseAction;
    }

    private void Update()
    {
        numberOfCube = GameObject.FindGameObjectsWithTag("Cube").Length;
        GameStateHandler();
    }

    private void GameStateHandler(){
        switch (gameState){
            case GameState.WaitingToStart:
                break;
            case GameState.Playing:
                if(DestructableCubeRemainCheck(numberOfCube)) {
                    gameState = GameState.GameOver;
                }           
                break;
            case GameState.Paused:

                break;
            case GameState.GameOver:
                OnGameOver?.Invoke(this, EventArgs.Empty);
                break;             
        }
    }

    private void GameInput_OnPauseAction(object sender, EventArgs e){
        TogglePauseGame();
    }

    public void TogglePauseGame(){
        isGamePaused = !isGamePaused;
        if(isGamePaused) {
            Time.timeScale = 0f; //Pause the game

            OnGamePaused?.Invoke(this, EventArgs.Empty);
        } else {
            Time.timeScale = 1f; //Unpause

            OnGameUnpaused?.Invoke(this, EventArgs.Empty);
        }
    }

    public void ClickToStartGame(){
        if(IsWaitingToStart()) {
            OnWaitingToStart?.Invoke(this, EventArgs.Empty);
            gameState = GameState.Playing;
        } 
    }

    private bool DestructableCubeRemainCheck (int numberOfCubeRemain) {
        return numberOfCubeRemain <= 0;
    }

    public bool IsGamePlaying(){
        return gameState == GameState.Playing;
    }

    public bool IsWaitingToStart(){
        return gameState == GameState.WaitingToStart;
    }

    public bool IsGameOver(){
        return gameState == GameState.GameOver;
    }

    private void OnDestroy() {
        gameInput.OnPauseAction -= GameInput_OnPauseAction;
    }
}
