using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cube : MonoBehaviour
{
    private const string BALL = "Ball";

    [SerializeField] int health;
    public event EventHandler OnCubeDestroy;
    public static event EventHandler OnAnyCubeTouched;

    public enum State{
        Idle,
        GetHit,
        Destroy,
    }

    public State state;

    private void Awake()
    {
        OnCubeDestroy += cube_OnCubeDestroy;
    }
    private void Update()
    {
        
        HandleState();

    }

    private void HandleState () {
        switch (state) {
            case State.Idle: 
                break;
            case State.GetHit: 
                health = health - 1;
                if(health>0) {
                    state = State.Idle;
                } else{
                    state = State.Destroy;
                }
                break;
            case State.Destroy:
                OnAnyCubeTouched?.Invoke(this, EventArgs.Empty);
                OnCubeDestroy?.Invoke(this, EventArgs.Empty);
                break;
        }
    }

    // public void DestroyCube(Cube cube){
    //     cube.OnCubeDestroy += cube_OnCubeDestroy;
    // }

    private void cube_OnCubeDestroy(object sender, EventArgs e){
        Destroy(gameObject);

    }

    private void OnDestroy()
    {
        OnCubeDestroy -= cube_OnCubeDestroy;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == BALL && health > 0){
            state = State.GetHit;

            OnAnyCubeTouched?.Invoke(this, EventArgs.Empty);
        } 
    }

}
