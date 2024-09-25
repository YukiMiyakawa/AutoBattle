using UnityEngine;
using UnityEditor; // ’Ç‰Á
using System.Collections;

public class Tools
{
    [MenuItem("Tools/Menu/HelloFromMenuBar %h")]
    static void SayHelloFromMenuBar()
    {
        Debug.Log("Hello From Menu Bar");
    }
}