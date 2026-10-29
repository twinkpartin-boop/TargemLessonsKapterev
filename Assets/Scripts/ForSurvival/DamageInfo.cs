using UnityEngine;

public struct DamageInfo
{
    public readonly Entity damager;
    public readonly float damage;

    public DamageInfo(Entity damager, float damage) { this.damager = damager; this.damage = damage; }
}
