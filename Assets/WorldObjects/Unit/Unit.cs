using UnityEngine;
using UnityEngine.AI;

public enum UnitType 
{ 
    PLAYER,
    FRIENDLY,
    ENEMY,
}

public class Unit : WorldObject
{
    public UnitType unitType = UnitType.FRIENDLY;
    public int maxHealth = 100;
    public int health = 100;
    public int speed = 10;

    private NavMeshAgent m_agent;

    public void ApplyDamage(int damage)
    {
        health = Mathf.Clamp(health - damage, 0, maxHealth);
    }

    protected override void Start()
    {
        base.Start();
        m_agent = GetComponent<NavMeshAgent>();
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        PlayerEvents.clickUnit.Invoke(this);
    }

    public virtual void Activation()
    {
        return;
    }
    public virtual void DeActivation()
    {
        return;
    }
    public virtual void MoveTo(Vector3 destination)
    {
        m_agent.destination = destination;
    }
}
