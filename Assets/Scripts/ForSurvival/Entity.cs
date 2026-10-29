using Unity.VisualScripting;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] protected EntityData entityData;
    protected HealthSystem health;


    protected virtual void Awake()
    {
        health = new HealthSystem(entityData.MaxHp);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    protected virtual void OnEnable()
    {
        health.hpChanged += OnHpChanged;
        health.damaged += OnTakeDamage;
        health.healed += OnHeal;
    }

    protected virtual void OnDisable()
    {
        health.hpChanged -= OnHpChanged;
        health.damaged -= OnTakeDamage;
        health.healed -= OnHeal;
    }

    protected virtual void Attack(Entity target)
    {
        target.TakeDamage(new DamageInfo(this, entityData.BaseDamage));
    }

    public virtual void TakeDamage(DamageInfo info)
    {
        health.TakeDamage(info);
    }

    protected virtual void Heal(float heal)
    {
        health.Heal(heal);
    }

    private void OnTakeDamage(DamageInfo info)
    {
        Debug.Log($"сущность с тегом {gameObject.tag} получила урон = {info.damage} от сущности с тегом {info.damager.gameObject.tag}");
    }

    private void OnHeal(float heal)
    {
        Debug.Log($"сущность с тегом {gameObject.tag} вылечена на {heal}hp");
    }

    private void OnHpChanged(float startHp, float endHp)
    {
        if (endHp > startHp && endHp == entityData.MaxHp) Debug.Log($"сущность с тегом {gameObject.tag} полностью здорова");
    }
}
