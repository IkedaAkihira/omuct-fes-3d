public class MoveEvent : Event{
    float defaultSpeed;
    float addNum = 0f;
    float mulNum = 1f;
    public Player player;

    public MoveEvent(Player p,float speed){
        this.player = p;
        this.defaultSpeed = speed;
    }

    public void Multiply(float magnification){
        this.mulNum *= magnification;
    }

    
    public void Add(float addSpeed){
        this.addNum += addSpeed;
    }


    public float DefaultSpeed{get{return defaultSpeed;}}
    public float Speed{get{return (defaultSpeed+addNum)*mulNum;}}
}