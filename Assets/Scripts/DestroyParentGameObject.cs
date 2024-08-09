using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParentGameObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(transform.childCount == 0) {
            Destroy(gameObject);
        }
    }
}
