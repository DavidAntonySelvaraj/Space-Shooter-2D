using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSxript : MonoBehaviour
{

    [SerializeField]
    public WeaponManagerPool[] weapon;


    public void SetWeapon(int weaponIndex)
    {
        weapon[weaponIndex].enabled = true;
    }

    public void SetOffWeapon(int weaponIndex)
    {
        weapon[weaponIndex].enabled = false;
    }


}//class




















