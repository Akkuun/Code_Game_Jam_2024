using System.Collections;
using System.Collections.Generic;
using UnityEditor.Compilation;
using UnityEngine;

public class ReadInput : MonoBehaviour
{
   
    private string reponse = "315";

    public GameObject ame; 
  

    public void readString(string s)
    {

        if (s == reponse)
            Instantiate(ame, transform.position+ new Vector3(5, 0, 0), Quaternion.identity);

    }
}
