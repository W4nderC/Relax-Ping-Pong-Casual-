using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeExplode : MonoBehaviour
{
    [SerializeField] private Cube cube;
    [SerializeField] private GameObject explodeVFXPrefab;

    private Collider explodeRange;

    private void Start()
    {
        Explode(cube);

        explodeRange = gameObject.GetComponent<Collider>();
        explodeRange.enabled = false;

    }

    public void Explode(Cube cube){
        cube.OnCubeDestroy += Cube_OnCubeDestroy;
    }

    private void Cube_OnCubeDestroy(object? sender, EventArgs e){
        explodeRange.enabled = true;

        Instantiate(explodeVFXPrefab, transform.position, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "Cube"){
            Cube cube = other.gameObject.GetComponent<Cube>();
            cube.state = Cube.State.GetHit;        
            print("CubeExplode activate");
            Destroy(gameObject);
        }
    }

}
