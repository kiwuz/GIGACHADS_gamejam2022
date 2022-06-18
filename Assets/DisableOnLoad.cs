using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnLoad : MonoBehaviour
{
    [SerializeField] GameObject portalPrehistory;
    [SerializeField] GameObject portalRome;
    [SerializeField] GameObject portalWW2;
    [SerializeField] GameObject portalSciFi;

    [SerializeField] Laser cylinderPrehistory;
    [SerializeField] Laser cylinderRome;
    [SerializeField] Laser cylinderWW2;
    [SerializeField] Laser cylinderSciFi;


    // Start is called before the first frame update
    void Start()
    {
        int count = 0;
        if (MapManager.Instance.prehistory)
        {
            portalPrehistory.SetActive(false);
            cylinderPrehistory.startLaser = true;
            count++;
        }
        if (MapManager.Instance.rome)
        {
            portalRome.SetActive(false);
            cylinderRome.startLaser = true;
            count++;
        }
        if (MapManager.Instance.ww2)
        {
            portalWW2.SetActive(false);
            cylinderWW2.startLaser = true;
            count++;
        }
        if (MapManager.Instance.sciFi)
        {
            portalSciFi.SetActive(false);
            cylinderSciFi.startLaser = true;
            count++;
        }

        if (count == 4) ActivateLastPortal();
    }

    private void ActivateLastPortal()
    {
        Debug.Log("aktywuje ostatni portal");
    }
}
