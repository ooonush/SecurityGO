using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveLoadManager : MonoBehaviour
{
    string filePath;

    GameManager GM => GameManager.Instance;
    
    private void Start()
    {
        filePath = UnityEngine.Application.persistentDataPath + "/Save.save";

        if (File.Exists(filePath) && new FileInfo(filePath).Length > 0) Load();

        StartCoroutine(WaitAndSave(10));
    }

    private IEnumerator WaitAndSave(int sec)
    {
        while(true)
        {
            yield return new WaitForSeconds(sec);
            Save();
        }    
    }

    private void Save()
    {
        var bf = new BinaryFormatter();
        var fs = new FileStream(filePath, FileMode.Create);

        var save = new Save
        {
            Level = GM.Level,
            Points = GM.Points,
            PointsCurrentLevel = GM.PointsCurrentLevel,
            Gems = GM.Gems,
            DevicesLevel = new int[GM.Devices.Length]
        };

        for (var i = 0; i < GM.Devices.Length; i++)
        {
            save.DevicesLevel[i] = GM.Devices[i].Level;
        }

        bf.Serialize(fs, save);
        fs.Close();
    }

    private void Load()
    {
        var bf = new BinaryFormatter();
        var fs = new FileStream(filePath, FileMode.Open);

        var save = (Save)bf.Deserialize(fs);
        fs.Close();

        GM.Level = save.Level;
        GM.Points = save.Points;
        GM.PointsCurrentLevel = save.PointsCurrentLevel;
        GM.Gems = save.Gems;

        for(var i = 0; i < GM.Devices.Length; i++)
        {
            GM.Devices[i].Level = save.DevicesLevel[i];
        }

        GM.SetTexts();
    }
}

[System.Serializable]
public class Save
{
    public int Level;
    public int PointsCurrentLevel;
    public int Points;
    public int Gems;
    public int[] DevicesLevel;
}