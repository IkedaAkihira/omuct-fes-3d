public class RiverListener: EventListener{
    override public void OnJump(JumpEvent e){
        if(e.player.effects.ContainsKey(EffectRiver.TYPE))
            e.Multiply(2f);
    }
}