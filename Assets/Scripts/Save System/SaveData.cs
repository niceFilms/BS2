using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class SaveData : MonoBehaviour
{
    public Inventory inventory = new Inventory();

	[HideInInspector] public bool save;

	private void Start ()
	{
        LoadFromJson();
	}
	private void Update ()
	{
		if (save)
        {
            save = false;
            SaveToJson();
        }
	}
    public void SaveToJson ()
    {
            string inventoryData = JsonUtility.ToJson(inventory);
            string filePath = Application.persistentDataPath + "/SaveData.json";
			File.WriteAllText(filePath, inventoryData);
    }

    public void LoadFromJson ()
    {
        string filePath = Application.persistentDataPath + "/SaveData.json";
        if (File.Exists(filePath))
        {
            string inventoryData = File.ReadAllText(filePath);
            inventory = JsonUtility.FromJson<Inventory>(inventoryData);
        }
        else
        {
			string inventoryData = JsonUtility.ToJson(inventory);
			filePath = Application.persistentDataPath + "/SaveData.json";
			File.WriteAllText(filePath, inventoryData);
		}
        
    }
}

[System.Serializable]
public class Inventory
{
    public string Level;
    public Vector3 Position;
    public Quaternion Rotation;
    public List<Items> items = new List<Items>();
}

[System.Serializable]
public class Items
{
    public string name;
    public string desc;
}