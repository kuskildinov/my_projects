using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSlidController : MonoBehaviour
{
    private JointMotor2D motor;
    private SliderJoint2D slider;

    private void Start()
    {
        slider = GetComponent<SliderJoint2D>();
        motor = slider.motor;
    }
    private void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "slider_trigger")
        {
            motor.motorSpeed *= -1;
            slider.motor = motor;
            Debug.Log("Connect");
        }
    }

}
