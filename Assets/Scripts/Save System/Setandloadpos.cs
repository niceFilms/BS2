using CI.QuickSave;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Setandloadpos : MonoBehaviour
{
	public Transform trns;
	SaveData inv;
	public PlayerMovement movement;
	public bool autosave;
	int i;

	// Start is called before the first frame update
	void Start ()
	{
		inv = GetComponent<SaveData>();
		i = 0;
		StartCoroutine(Load());
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
					inv.inventory.Position = trns.position;
					inv.inventory.Rotation = trns.rotation;
					Scene uscene = SceneManager.GetActiveScene();
					inv.inventory.Level = uscene.name;
					inv.save = true;
				}
			}
		}
	}

	public void SavePosition ()
	{
		inv.inventory.Position = trns.position;
		inv.inventory.Rotation = trns.rotation;
		Scene uscene = SceneManager.GetActiveScene();
		inv.inventory.Level = uscene.name;
		inv.save = true;
		health Health = GetComponent<health>();
		Health.Health = 1;
	}
	IEnumerator Load ()
	{
		yield return new WaitForEndOfFrame();
		trns.position = inv.inventory.Position;
		trns.rotation = inv.inventory.Rotation;
		i = 1;
	}
}