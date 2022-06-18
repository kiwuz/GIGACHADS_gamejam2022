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
    public void checkPassowrd(string text)
    {
        if (password.Equals(text))
        {
            Debug.Log("You Win");
            textBoard.text="Portal otworzony na dachu";
        }
    }
}
