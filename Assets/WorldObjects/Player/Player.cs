using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    protected override void Start()
    {
        base.Start();
        unitType = UnitType.PLAYER;
    }

    public override void Activation()
    {
        StartCoroutine(AnimationScale(0.1f));
        PlayerEvents.clickPlayer.Invoke(gameObject);
    }
    public override void DeActivation()
    {
        StartCoroutine(AnimationScale(-0.1f));
    }

    IEnumerator AnimationScale(float increase_scale)
    {
        float animation_time = 0.1f;
        Vector3 startScale = transform.localScale;
        Vector3 endScale = transform.localScale + new Vector3(increase_scale, increase_scale, increase_scale);
        float timer = 0;
        while (timer < animation_time)
        {
            timer += Time.deltaTime;
            if (timer > animation_time)
                timer = animation_time;
            transform.localScale = Vector3.Lerp(startScale, endScale, timer / animation_time);
            yield return null;
        }
    }
}
