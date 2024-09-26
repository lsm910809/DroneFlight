using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : MonoBehaviour
{

    [SerializeField] private FixedJoystick leftJoystick;
    [SerializeField] private FixedJoystick rightJoystick;
    [SerializeField] private GameObject droneObject;
    [SerializeField] private int droneStartupFlg = 0;
    [SerializeField] private Animator droneAnimator;
    [SerializeField] private AudioSource propellerAudio;
    public Camera mainCamera;
    public Camera subCamera;

    [SerializeField] private float rotationSpeed = 0.3f;
    [SerializeField] private float movementSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("leftJoystick.Horizontal : " + leftJoystick.Horizontal);
        // Debug.Log("leftJoystick.Vertical : " + leftJoystick.Vertical);
        // Debug.Log("rightJoystick.Horizontal : " + rightJoystick.Horizontal);
        // Debug.Log("rightJoystick.Vertical : " + rightJoystick.Vertical);

        if (droneStartupFlg == 1) {
            droneAnimator.SetBool("rotationTrigger", true);
        } else if (droneStartupFlg == 2) {
            droneAnimator.SetBool("rotationTrigger", true);
            droneObject.transform.Rotate(0, rotationSpeed * leftJoystick.Horizontal ,0);
            droneObject.transform.Translate(movementSpeed * leftJoystick.Vertical * Vector3.up);
            droneObject.transform.Translate(movementSpeed * rightJoystick.Vertical * Vector3.forward);
            droneObject.transform.Translate(movementSpeed * rightJoystick.Horizontal * Vector3.right);
        } else if (droneStartupFlg == 0) {
            droneAnimator.SetBool("rotationTrigger", false);
        }

        if (droneStartupFlg == 0 &&
            leftJoystick.Horizontal > 0.5f &&
            leftJoystick.Vertical < -0.5f &&
            rightJoystick.Horizontal < -0.5f &&
            rightJoystick.Vertical < -0.5f) {
                SetDroneStartupFlg(1);
            }
        if (droneStartupFlg == 1 &&
            leftJoystick.Horizontal < 0.5f &&
            leftJoystick.Vertical > -0.5f &&
            rightJoystick.Horizontal > -0.5f &&
            rightJoystick.Vertical > -0.5f) {
                SetDroneStartupFlg(2);
            }
        SetAudio();
    }

    public void SetDroneStartupFlg(int flg) {
        droneStartupFlg = flg;
    }

    public void SetAudio() {
        if (droneStartupFlg == 0) {
            propellerAudio.enabled = false;
        } else if (droneStartupFlg > 0) {
            propellerAudio.enabled = true;
        }
    }

    public void SwitchCamera() {
        mainCamera.enabled = !mainCamera.enabled;
        subCamera.enabled = !subCamera.enabled;
    }
}
