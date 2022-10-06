public interface EventListener{
    public void OnAttack(AttackEvent e);
    public void OnDamaged(DamageEvent e);
    public void OnUseItem(UseItemEvent e);
}