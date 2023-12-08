using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HolyAura", menuName = "Spells/ArmourAura", order = 1)]
public class HolyAura : spell
{
    public int intensity = 5;

    public override void OnUse(Stats user)
    {
        base.OnUse(user);
        user.armour += intensity;
        intensity *= -1;
    }
}
