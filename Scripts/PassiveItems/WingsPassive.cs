using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingsPassive : PassiveItem
{
    protected override void ApplyModifier()
    {
        
        player.CurrentSpeed *= 1+passiveItemData.Multipler/100;
    }
}
