using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pattern : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        string s = "\n";
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                s += "* ";
            }
            s+= "\n";
        }
        print(s);
    }


}
