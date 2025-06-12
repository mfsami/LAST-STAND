using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUI : MonoBehaviour
{
    public Image weaponUI;
    public SpriteRenderer weaponSprite;
    void Update()
    {
        if (weaponUI.sprite != weaponSprite.sprite)
        {
            weaponUI.sprite = weaponSprite.sprite;
        }
    }



}
