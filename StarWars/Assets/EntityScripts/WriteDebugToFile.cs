using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using System;

public class WriteDebugToFile : MonoBehaviour
{
    string filename = " ";
    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        Application.logMessageReceived += Log;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= Log;
    }

    private void Start()
    {
        filename = Application.dataPath + "/LogFile.text";
    }

    public void Log(string logString,string stackTrace, LogType type) { 
        TextWriter tw = new StreamWriter(filename,true);

        tw.WriteLine("[" + DateTime.Now.ToString("hh.mm.ss.ffffff") + "]" + logString);

        tw.Close();
    }
}
