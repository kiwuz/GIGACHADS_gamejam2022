using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField]
    string password;
    [SerializeField]
    TextMeshProUGUI textBoard;
    [SerializeField]
    GameObject portal;
    public void checkPassowrd(string text)
    {
        if (password.Equals(text))
        {
            portal.SetActive(true);
        }
    }
}
