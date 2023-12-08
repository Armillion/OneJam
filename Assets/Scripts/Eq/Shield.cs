using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Shield", menuName = "Items/Offhands/Shield", order = 1)]
public class Shield : Offhand
{
    public int bonusArmour = 1;

    public override void onEquip(Stats self)
    {
        base.onEquip(self);
        self.armour += bonusArmour;
    }

    public override void onUnEquip(Stats self)
    {
        base.onUnEquip(self);
        self.armour -= bonusArmour;
    }
}
