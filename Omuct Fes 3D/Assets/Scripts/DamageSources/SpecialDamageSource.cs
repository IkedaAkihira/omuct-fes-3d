public class SpecialDamageSource : DamageSource{
    public const int TYPE_POISON = 0;
    public readonly int type;
    public SpecialDamageSource(int type,int amount) : base(amount){
        this.type=type;
    }
}