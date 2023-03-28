using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float doodgeSpeed;
    public float maxXDirection; // limitetion X position
    float xInput;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // TouchInput(); // mouse control
        xInput = Input.GetAxis("Horizontal"); // X movement

        transform.Translate(xInput * doodgeSpeed * Time.deltaTime, 0, 0); //Time.deltaTime we need, so that they do not depend on the power
                                                                          //of the computer

        float limitedx = Mathf.Clamp(transform.position.x, -maxXDirection, maxXDirection);// limitetion X position, MathF 

        transform.position = new Vector3(limitedx, transform.position.y, transform.position.z);
    }



    /// <summary>
    /// Mouse touch control
    /// </summary>
    /// <param name="col"></param>
  /*  void TouchInput()
    {

        if (Input.GetMouseButton(0))
        {

            Vector3 touchPos = Input.mousePosition;
                                                       
            float middle = Screen.width / 2;
            if(touchPos.x < middle)
            {
                xInput = -1;
            }
            else if (touchPos.x > middle)
            {
                xInput = 1;
            }
        
        }

    }
  */

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {

            GameManager.instance.Restart();

        }
    }
}
