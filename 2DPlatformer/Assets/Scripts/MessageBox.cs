using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour
{
    public Text messageText;
    public void SetText(string data)
    {
        messageText.text = data;
    }
}
