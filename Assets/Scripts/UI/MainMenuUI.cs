using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [Header("Level Button")]
    [SerializeField] private Button lever1PlayButton;
    [SerializeField] private Button level2PlayButton;
    [SerializeField] private Button level3PlayButton;

    [Header("Other Button")]
    [SerializeField] private Button quitButton;
    

    private void Awake() {
        lever1PlayButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.Lever1GameScene);
        });
        quitButton.onClick.AddListener(() => {
            Application.Quit();
        });
        level2PlayButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.Level2GameScene);
        });
        level3PlayButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.Level3GameScene);
        });
        

        Time.timeScale = 1f; // resume the paused game
    }
}
