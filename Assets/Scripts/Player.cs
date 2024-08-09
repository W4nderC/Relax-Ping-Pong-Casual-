using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;
using System;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private float maxY;
    [SerializeField] private float minY;
    [SerializeField] private GameManager gameManager;

    private int numberOfCubeAvailable;
    private float timePassed = 0f;

    public event EventHandler OnPlayerShooting;

    private void Start () {

    }

    private void Update () {
        if(gameManager.IsGamePlaying()) {
            PlayerMovementControl();

            numberOfCubeAvailable = GameObject.FindGameObjectsWithTag("Cube").Length;

            // spawn bullet every 1s
            timePassed += Time.deltaTime;
            if(timePassed > 1f)
            {
                ShootingCheck(numberOfCubeAvailable);
                timePassed = 0f;
            } 
        }
        
    }

    private void PlayerMovementControl(){
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        Vector3 moveDir = new Vector3(0f, inputVector.y, 0f);

        float maxDistance = 1.3f;

        bool canMove = !Physics.Raycast(transform.position, moveDir, maxDistance);

        // if(transform.position.y <= maxY && transform.position.y >= minY) {
        //     transform.position += moveDir * moveSpeed * Time.deltaTime;
        // } else if(transform.position.y > maxY) {
        //     transform.position = new Vector3(transform.position.x, maxY - 0.001f, transform.position.z);
        // } else if(transform.position.y < minY){
        //     transform.position = new Vector3(transform.position.x, minY + 0.001f, transform.position.z);
        // }  

        if(canMove) {
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        } 
        
    }

    // Shoot bullet when only 20 cube left
    private void ShootingCheck (int numberOfCubeAvailable) {
        if(numberOfCubeAvailable <21) {
            OnPlayerShooting?.Invoke(this, EventArgs.Empty);
        }
    }
}
