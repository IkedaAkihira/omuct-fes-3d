abstract public class Effect{
    public int time;
    public int type;
    protected abstract void Tick(Player player);
}