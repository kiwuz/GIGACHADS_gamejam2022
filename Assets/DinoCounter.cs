using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoCounter : MonoBehaviour
{
    [SerializeField] int dinos;
    [SerializeField] int foundDinos;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.CompareTag("dino"))
        {
            foundDinos++;
            CheckDinos();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("exit trigger");
        if (other.CompareTag("dino"))
        {
            foundDinos--;
        }
    }
    private void CheckDinos()
    {
        if (dinos <= foundDinos)
        {
            Debug.Log("zsad");
        }

    }
}
