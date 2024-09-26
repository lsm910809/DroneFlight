using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Unity.Collections;

public class ClockHandsController : MonoBehaviour
{
    public GameObject hourHand;
    public GameObject minHand;
    public GameObject secHand;

    public GameObject[] dateFirstDigitObject;
    public GameObject[] dateSecondDigitObject;

    float timeHour = 0.0f;
    float timeMin = 0.0f;
    float timeSec = 0.0f;

    float angleHour = 0.0f;
    float angleMin = 0.0f;
    float angleSec = 0.0f;

    int dateFirstDigit = 0;
    int dateSecondDigit = 0;

    public RotationAxis rotationAxis;

    public enum RotationAxis
    {
        x,
        y,
        z
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("updateHands", 0.0f, 1.0f);
        InvokeRepeating("updateDate", 0.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void updateHands () {
        
        if ("00".Equals(DateTime.Now.ToString("hh"))) {
            timeHour = 0.0f;
        } else {
            timeHour = float.Parse(DateTime.Now.ToString("hh").TrimStart('0'));
        }

        if ("00".Equals(DateTime.Now.ToString("mm"))) {
            timeMin = 0.0f;
        } else {
            timeMin = float.Parse(DateTime.Now.ToString("mm").TrimStart('0'));
        }

        if ("00".Equals(DateTime.Now.ToString("ss"))) {
            timeSec = 0.0f;
        } else {
            timeSec = float.Parse(DateTime.Now.ToString("ss").TrimStart('0'));
        }
        
        // Debug.Log("timeHour : " + timeHour);
        // Debug.Log("timeMin : " + timeMin);
        // Debug.Log("timeSec : " + timeSec);
        
        angleHour = (timeHour + (timeMin / 60f)) * 30f;
        angleMin = (timeMin + (timeSec / 60f)) * 6f;
        angleSec = timeSec * 6f;
        
        if (rotationAxis == RotationAxis.x) {
            hourHand.transform.localRotation = Quaternion.AngleAxis(angleHour, Vector3.right);
            minHand.transform.localRotation = Quaternion.AngleAxis(angleMin, Vector3.right);
            secHand.transform.localRotation = Quaternion.AngleAxis(angleSec, Vector3.right);
        } else if (rotationAxis == RotationAxis.y) {
            hourHand.transform.localRotation = Quaternion.AngleAxis(angleHour, Vector3.up);
            minHand.transform.localRotation = Quaternion.AngleAxis(angleMin, Vector3.up);
            secHand.transform.localRotation = Quaternion.AngleAxis(angleSec, Vector3.up);
        } else if (rotationAxis == RotationAxis.z) {
            hourHand.transform.localRotation = Quaternion.AngleAxis(angleHour, Vector3.forward);
            minHand.transform.localRotation = Quaternion.AngleAxis(angleMin, Vector3.forward);
            secHand.transform.localRotation = Quaternion.AngleAxis(angleSec, Vector3.forward);
        }

    }

    void updateDate() {
        if ("00".Equals(DateTime.Now.ToString("dd"))) {
            dateFirstDigit = 0;
            dateSecondDigit = 0;
        } else {
            if (int.Parse(DateTime.Now.ToString("dd").TrimStart('0')) < 10) {
                dateFirstDigit = 0;
            } else {
                dateFirstDigit = int.Parse(DateTime.Now.ToString("dd").Substring(0,1));
            }
            dateSecondDigit = int.Parse(DateTime.Now.ToString("dd").Substring(1,1));
        }

        // Debug.Log("dateFirstDigit : " + dateFirstDigit);
        // Debug.Log("dateSecondDigit : " + dateSecondDigit);

        if (dateFirstDigitObject.Length != 0) {
            for (int i = 0; i < dateFirstDigitObject.Length; i++) {
                if (i == dateFirstDigit) {
                    dateFirstDigitObject[i].transform.localPosition = new Vector3(
                        dateFirstDigitObject[i].transform.localPosition.x,
                        0.0001f,
                        dateFirstDigitObject[i].transform.localPosition.z
                    );
                } else {
                    dateFirstDigitObject[i].transform.localPosition = new Vector3(
                        dateFirstDigitObject[i].transform.localPosition.x,
                        0.0f,
                        dateFirstDigitObject[i].transform.localPosition.z
                    );
                }
            }
        }

        if (dateSecondDigitObject.Length != 0) {
            for (int i = 0; i < dateSecondDigitObject.Length; i++) {
                if (i == dateSecondDigit) {
                    dateSecondDigitObject[i].transform.localPosition = new Vector3(
                        dateSecondDigitObject[i].transform.localPosition.x,
                        0.0001f,
                        dateSecondDigitObject[i].transform.localPosition.z
                    );
                } else {
                    dateSecondDigitObject[i].transform.localPosition = new Vector3(
                        dateSecondDigitObject[i].transform.localPosition.x,
                        0.0f,
                        dateSecondDigitObject[i].transform.localPosition.z
                    );
                }
            }
        }
    }

}
