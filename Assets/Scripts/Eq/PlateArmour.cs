using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Plate", menuName = "Items/Armor/Plate", order = 1)]
public class PlateArmour : Armor
{
    public int armourAmount = 3;
    public float speedPenalty = 0.2f;

    public override void onEquip(Stats self)
    {
        base.onEquip(self);
        self.armour += armourAmount;
        self.movespeedMulti -= speedPenalty;
    }

    public override void onUnEquip(Stats self)
    {
        base.onEquip(self);
        self.armour += armourAmount;
        self.movespeedMulti -= speedPenalty;
    }
}
