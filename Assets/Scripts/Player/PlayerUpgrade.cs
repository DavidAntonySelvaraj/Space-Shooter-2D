using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrade : MonoBehaviour
{

    public WeaponSxript weaponUpgrade;

    private CollectableScript collectable;

    void DeatroyCollectable(CollectableScript coll)
    {
        if(coll.type!=CollectableType.Health)
        {
            Destroy(coll.gameObject);
        }
    }


    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(!collision.CompareTag(TagManager.COLLECTABLE_TAG))
            return;

        collectable = collision.GetComponent<CollectableScript>();

        if (collectable.type == CollectableType.Laser)
        {
            weaponUpgrade.SetOffWeapon(4);
            weaponUpgrade.SetOffWeapon(5);

            weaponUpgrade.SetWeapon(0);
            weaponUpgrade.SetWeapon(1);
        }
        if (collectable.type == CollectableType.MiniRocket)
        {
            weaponUpgrade.SetOffWeapon(2);

            weaponUpgrade.SetWeapon(3);
        }
        if(collectable.type ==CollectableType.Rocket)
        {
            weaponUpgrade.SetOffWeapon(3);

            weaponUpgrade.SetWeapon(2);
        }
        if(collectable.type == CollectableType.Blaster)
        {
            weaponUpgrade.SetOffWeapon(0);
            weaponUpgrade.SetOffWeapon(1);
            

            weaponUpgrade.SetWeapon(4);
            weaponUpgrade.SetWeapon(5);
        }
        DeatroyCollectable(collectable);
    }



}//class


































