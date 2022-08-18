using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler 
{
    private string dataDirPath = "";
    private string dataFileName = "";

    private bool useEncryption = false;
    private readonly string encryptionCodeWord = "word";

    public FileDataHandler(string dataDirPath, string dataFileName, bool useEncryption)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
        this.useEncryption = useEncryption;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);
        GameData loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                //load serialized data file
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                //decrypt
                if (useEncryption)
                {
                    dataToLoad = EncryptDecrypt(dataToLoad);
                }

                //deserialize data JSON -> C#
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch(Exception e)
            {
                Debug.LogError("Error trying load file" + fullPath + "\n" + e);
            }
        }

        return loadedData;
    }

    public void Save(GameData data)
    {
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        try
        {
            //create dir written when not exist
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //C# -> JSON
            string dataToStore = JsonUtility.ToJson(data, true);

            //encrypt
            if (useEncryption)
            {
                dataToStore = EncryptDecrypt(dataToStore);
            }

            //write serialized data to file
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }


        }catch(Exception e)
        {
            Debug.LogError("Error save data" + fullPath + "\n" + e);
        }
    }

    private string EncryptDecrypt(string data)
    {
        string modifiedData = "";
        for(int i = 0; i < data.Length; i++)
        {
            modifiedData += (char)(data[i] ^ encryptionCodeWord[i % encryptionCodeWord.Length]);
        }
        return modifiedData;
    }
}
