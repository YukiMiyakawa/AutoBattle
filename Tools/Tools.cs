using UnityEngine;
using UnityEditor; // �ǉ�
using System.Collections;

public class Tools
{
    [MenuItem("Tools/Menu/HelloFromMenuBar %h")]
    static void SayHelloFromMenuBar()
    {
        Debug.Log("Hello From Menu Bar");
    }
}