using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sword", menuName = "Items/Weapons/Sword", order = 1)]
public class Sword : Weapon
{
    public float damage = 2f;

    public override void onEquip(Stats self)
    {
        base.onEquip(self);
        self.physDamage += damage;
    }

    public override void onUnEquip(Stats self)
    {
        self.physDamage -= damage;
    }
}
