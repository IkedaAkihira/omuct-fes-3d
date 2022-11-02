public class ResultData{
    public bool isWin;
    public int attackCount;
    public int hitCount;
    public int useItemCount;
    public int hp;
    public int jumpCount;
    public int id;
    public ResultData(bool isWin,int id,int hp,int attackCount,int hitCount,int useItemCount,int jumpCount){
        this.isWin = isWin;
        this.hp = hp;
        this.attackCount = attackCount;
        this.hitCount = hitCount;
        this.useItemCount = useItemCount;
        this.jumpCount = jumpCount;
        this.id = id;
    }
}