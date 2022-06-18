using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField]
    int sceneId;


    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Player"))
        {
            MapManager.Instance.Load(sceneId);
        }
    }
}
