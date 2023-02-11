using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSprite : MonoBehaviour
{
    public GameObject sprite;
    public void Event()
    {
        sprite.SetActive(!sprite.activeSelf);
    }
}
