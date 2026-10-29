using UnityEngine;
using System.Collections.Generic;
using System;

public class HealthSystem
{
    private float maxHp;
    private float hp;

    public float MaxHp { get { return maxHp; } set { maxHp = value; } }
    public float Hp { get { return hp; } set { hp = Math.Clamp(0, value, maxHp); } }

    public event Action<float, float> hpChanged;
    public event Action<DamageInfo> damaged;
    public event Action<float> healed;
    public event Action died;

    public HealthSystem(float maxhp)
    {
        maxHp = maxhp;
    }

    public void TakeDamage(DamageInfo damageInfo)
    {
        var lastHp = hp;

        damaged?.Invoke(damageInfo);

        hpChanged?.Invoke(lastHp, hp);

        if (hp == 0)
        {
            died?.Invoke();
        }
    }

    public void Heal(float heal)
    {
        var lastHp = hp;
        healed?.Invoke(heal);

        hpChanged?.Invoke(lastHp, hp);
    }
}
