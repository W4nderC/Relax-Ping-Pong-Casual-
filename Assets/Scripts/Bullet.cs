using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;

    [SerializeField] private Rigidbody rigidbody;

    private void Start()
    {

        rigidbody.AddForce(Vector3.right * bulletSpeed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Cube"){
            Cube cube = other.gameObject.GetComponent<Cube>();
            cube.state = Cube.State.GetHit;
            SelfDestroy();   
        } else if(other.gameObject.tag == "Wall"){
            SelfDestroy();
        }
    }

    private void SelfDestroy () {
        Destroy(gameObject);
    }
    
}
