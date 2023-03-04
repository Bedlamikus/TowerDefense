using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public enum UnitType 
{ 
    PLAYER,
    FRIENDLY,
    ENEMY,
}

public enum UnitRace
{ 
    SKELETON,
    PLAYER,
    ENEMY,
}

[RequireComponent(typeof(AnimatorController), typeof(NavMeshAgent))]
public class Unit : WorldObject
{
    public UnitType unitType = UnitType.FRIENDLY;
    public UnitRace unitRace = UnitRace.SKELETON;
    public int maxHealth = 100;
    public int health = 100;
    public int speed = 10;

    private NavMeshAgent m_agent;
    private AnimatorController animatior;

    public void ApplyDamage(int damage)
    {
        health = Mathf.Clamp(health - damage, 0, maxHealth);
    }

    protected override void Start()
    {
        base.Start();
        m_agent = GetComponent<NavMeshAgent>();
        animatior = GetComponent<AnimatorController>();
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
        animatior.Run();
        StartCoroutine(GetStopedAnimation());
    }

    IEnumerator GetStopedAnimation()
    {
        bool stoped = false;
        while (!stoped)
        {
            yield return null;
            if (m_agent.velocity.magnitude < 0.01f)
            {
                stoped = true;
                animatior.Stop();
            }
        }
    }

    public virtual void ChaseTheGameObject(GameObject target)
    {
        StartCoroutine(Chase(target));
        animatior.Run();
        StartCoroutine(GetStopedAnimation());
    }

    IEnumerator Chase(GameObject target)
    {
        bool stoped = false;
        while (!stoped)
        {
            
            Vector3 targetPosition = target.transform.position;
            MoveTo(targetPosition);
            while ((transform.position - targetPosition).magnitude > 2.3f)
            {
                yield return null;
            }
            if ((transform.position - target.transform.position).magnitude <= 2.3f)
            {
                stoped = true;
            }
        }
    }
}
