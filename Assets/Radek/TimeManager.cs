using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] Light light;

    [SerializeField] float DayLength;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float currentTime;//0 means 14:00, 72 mean 20:00, -72 means 8:00
    [SerializeField] private GameObject timeStick;
    [SerializeField] private GameObject sunClock;

    //multiplayer = 1 -> 5 minut w przod
    private void UpdateSunTime(float multiplayer)
    {
        light.transform.Rotate(0, multiplayer * _rotationSpeed, 0);
        currentTime += multiplayer;
        if (light.transform.rotation.y > 0.453154) {

            light.transform.Rotate(0, -multiplayer * _rotationSpeed, 0);//+60
            currentTime = 72;
        }
        else if (light.transform.rotation.y < -0.7848859)
        {
            light.transform.Rotate(0, -multiplayer * _rotationSpeed, 0);//-120
            currentTime = -72;
        }
        Debug.Log(currentTime);
        //Debug.Log(light.transform.rotation.y);
    }

    private void Start()
    {
        //_rotationSpeed = Time.deltaTime / DayLength;
        //_rotationSpeed = (180 / 144) * (1);//180 - zakres dnia i nocy (rownonoc), 144 ustawienia czasu (zmiana 5 minut)
        //90 klikniec(90 * '5 minut'), aby od 14 do 8 przejsc
        _rotationSpeed = 1.25f;
    }


    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            UpdateSunTime(-1);
        }
        if (Input.GetKeyUp(KeyCode.T))
        {
            UpdateSunTime(1);
        }


    }


}
