using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class SaveData : MonoBehaviour
{
    public Inventory inventory = new Inventory();

	[HideInInspector] public bool save;

	private void Awake ()
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
        try 
        { 
            string inventoryData = JsonUtility.ToJson(inventory);
            string filePath = Application.persistentDataPath + "/SaveData.json";
            System.IO.File.WriteAllText(filePath, inventoryData);
        } catch { }
    }

    public void LoadFromJson ()
    {
        try 
        {
            string filePath = Application.persistentDataPath + "/SaveData.json";
            string inventoryData = System.IO.File.ReadAllText(filePath);

            inventory = JsonUtility.FromJson<Inventory>(inventoryData);
        } catch { }
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