public class JumpEvent : Event{
    float defaultJumpForce;
    float addNum = 0f;
    float mulNum = 1f;
    public Player player;

    public JumpEvent(Player p,float jumpForce){
        this.player = p;
        this.defaultJumpForce = jumpForce;
    }

    public void Multiply(float magnification){
        this.mulNum *= magnification;
    }

    
    public void Add(float addJumpForce){
        this.addNum += addJumpForce;
    }


    public float DefaultJumpForce{get{return defaultJumpForce;}}
    public float JumpForce{get{return (defaultJumpForce+addNum)*mulNum;}}
}