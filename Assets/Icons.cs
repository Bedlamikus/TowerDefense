using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icons : MonoBehaviour
{
    [SerializeField] private List<Icon> icons;

    public Icon GetIcon(UnitRace race)
    {
        Icon result = null;
        foreach (var ic in icons)
        {
            if (ic.iconRace == race)
                result = ic;
        }
        if (result == null)
            print($"List ICONS not have Icon with name {race}");
        return result;
    }
}
