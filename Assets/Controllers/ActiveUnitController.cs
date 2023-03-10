using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveUnitController : MonoBehaviour
{
    private Unit activeUnit = null;

    void Start()
    {
        PlayerEvents.clickUnit.AddListener(SetUnits);
        PlayerEvents.moveTo.AddListener(MoveTo);
        PlayerEvents.deActivateUnit.AddListener(UnLink);
    }

    private void SetUnits(Unit unit)
    {
        if (activeUnit == unit) return;
        if (activeUnit == null)
        {
            activeUnit = unit;
            activeUnit.Activation();
            return;
        }
        if (activeUnit.unitType == UnitType.PLAYER 
            && unit.unitType == UnitType.ENEMY)
        {
            activeUnit.ChaseTheGameObject(unit.gameObject);
            return;
        }
        if (activeUnit.unitType == UnitType.ENEMY
            && unit.unitType == UnitType.ENEMY)
        {
            (activeUnit as Enemy).DeActivation();
            activeUnit = unit;
            (activeUnit as Enemy).Activation();
            return;
        }
        if (activeUnit.unitType == UnitType.ENEMY
            && unit.unitType == UnitType.PLAYER)
        {
            (activeUnit as Enemy).DeActivation();
            activeUnit = unit;
            (activeUnit as Player).Activation();
            return;
        }

    }

    private void MoveTo(Vector3 destination)
    {
        if (activeUnit == null) return;
        if (activeUnit.unitType != UnitType.PLAYER) return;
        activeUnit.MoveTo(destination);
    }

    public Unit link
    {
        get{ return activeUnit;}
    }

    public void UnLink(GameObject _)
    {
        activeUnit.DeActivation();
        activeUnit = null;
    }
}
