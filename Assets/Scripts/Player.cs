using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float doodgeSpeed;

    float xInput;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       xInput = Input.GetAxis("Horizontal");

        transform.Translate(xInput * doodgeSpeed * Time.deltaTime,0,0);
    }
}
