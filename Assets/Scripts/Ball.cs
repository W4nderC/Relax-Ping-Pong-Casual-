using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector3 force;
    [SerializeField] private Vector3 spawnPos;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float ballSpeed;

    private Rigidbody rigidbody;
    private Vector3 ballDir;
    private float timePassed = 10f;

    private void Awake() {
        GameManager.Instance.OnGameOver += GameManager_OnGameOver;
    }

    private void GameManager_OnGameOver (object sender, System.EventArgs e) {
        Destroy(gameObject);
    }

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.AddForce(force, ForceMode.Impulse);
    }

    private void FixedUpdate(){

        ballDir = rigidbody.velocity.normalized;
        rigidbody.velocity = ballDir * ballSpeed;

        timePassed -= Time.deltaTime;
        if(timePassed <= 0) {
            ballSpeed += 1;
            timePassed = 10;
        }
        print(ballSpeed);
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Bounds"){
            Destroy(gameObject);
        }   
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameOver -= GameManager_OnGameOver;
    }
}
