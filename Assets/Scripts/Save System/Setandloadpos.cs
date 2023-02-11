using CI.QuickSave;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class Setandloadpos : MonoBehaviour
{
	public Transform trns;
	SaveData inv;
	public PlayerMovement movement;
	public bool autosave;
	int i = 0;

	// Start is called before the first frame update
	void Start ()
	{
		QuickSaveReader.Create("PLayer")
					   .Read<Vector3>("invpos", (r) => { trns.position = r; })
					   .Read<Quaternion>("invrot", (r) => { trns.rotation = r; });
		i++;
	}

	// Update is called once per frame
	void Update ()
	{
		if (i == 1)
		{
			if (movement.isGrounded)
			{
				if (autosave)
				{
					Scene uscene = SceneManager.GetActiveScene();
					QuickSaveWriter.Create("Player")
						.Write("invpos", trns.position)
						.Write("invrot", trns.rotation)
						.Write("Scene", uscene)
						.Commit();
				}
			}
		}
	}

	public void SavePosition ()
	{
		Scene uscene = SceneManager.GetActiveScene();
		QuickSaveWriter.Create("Player")
			.Write("invpos", trns.position)
			.Write("invrot", trns.rotation)
			.Write("Scene", uscene)
			.Commit();
	}
}