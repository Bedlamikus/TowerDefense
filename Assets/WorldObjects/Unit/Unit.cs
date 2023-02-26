using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;
    public int speed = 10;
    private Rigidbody m_Rigidbody;

    public void ApplyDamage(int damage)
    {
        health = Mathf.Clamp(health - damage, 0, maxHealth);
    }
    public void Walk()
    {
        m_Rigidbody.velocity = transform.forward * speed * Time.deltaTime;
    }
    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print(transform.forward);
            Walk();
        }
    }
    private void OnMouseDown()
    {
        print(gameObject.name);
    }
}
