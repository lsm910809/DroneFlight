using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneGoundContactTrigger : MonoBehaviour
{
    public DroneController droneController;
    [SerializeField] public String triggerTag = "Floor";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag(triggerTag)) {
            droneController.SetDroneStartupFlg(0);
            collider.tag = "Untagged";
        }
    }
    void OnTriggerExit(Collider collider) {
        collider.tag = triggerTag;
    }
}
