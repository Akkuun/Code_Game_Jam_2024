using System.Collections;
using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
   
    private string reponse = "315"; 
  

    public void readString(string s)
    {

        if (s == reponse)
            Debug.Log(s);

    }
}
