using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveData
{
    static List<string> idBlocks = new List<string>();
    public static void Save(string _fileName, string _data)
    {

        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/" + _fileName);
        sw.WriteLine(_data);
        sw.Close();
    }

    public static void SaveBlock(string _fileName, string _data)
    {
        idBlocks.Add(_data);
        foreach(var n in idBlocks)
        {
            File.AppendAllText(Application.persistentDataPath + "/" + _fileName, n);
        }
        
    }


    public static int SaveLoader(string _fileName)
    {

        if (File.Exists(Application.persistentDataPath + "/" + _fileName))
        {
            string[] reader = File.ReadAllLines(Application.persistentDataPath + "/" + _fileName);
            string json = reader[reader.Length - 1];
            return Convert.ToInt32(json);
        }

        return 0;

    }

    public static string SaveLoaderBlock(string _fileName)
    {

        if (File.Exists(Application.persistentDataPath + "/" + _fileName))
        {
            if(File.ReadAllText(Application.persistentDataPath + "/" + _fileName) != null)
            {
         
                return File.ReadAllText(Application.persistentDataPath + "/" + _fileName);
            }
            else
            {
                return "0";
            }
            

        }

        return "0";

    }


}

