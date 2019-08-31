using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextChange : MonoBehaviour
{

    public void Change(float f)
    {
        GetComponent<Text>().text = f.ToString();
    }
}