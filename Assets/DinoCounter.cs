using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoCounter : MonoBehaviour
{
    [SerializeField] int dinos;
    [SerializeField] int foundDinos;
    [SerializeField] GameObject portal;

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
            //Debug.Log("zsad");
            MapManager.Instance.prehistory = true;
            portal.SetActive(true);

        }

    }
}
