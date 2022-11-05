using System.Collections.Generic;

public class MasterListener : EventListener{
    List<EventListener>listeners;

    public MasterListener(ref List<EventListener>listeners){
        this.listeners = listeners;
    }
    override public void OnAttack(AttackEvent e){
        for(int i=0;i<listeners.Count;i++){
            listeners[i].OnAttack(e);
        }
    }

    override public void OnDamaged(DamagedEvent e){
        for(int i=0;i<listeners.Count;i++){
            listeners[i].OnDamaged(e);
        }
    }

    override public void OnPreDamaged(PreDamagedEvent e){
        for(int i=0;i<listeners.Count;i++){
            listeners[i].OnPreDamaged(e);
        }
    }

    override public void OnUseItem(UseItemEvent e){
        for(int i=0;i<listeners.Count;i++){
            listeners[i].OnUseItem(e);
        }
    }

    override public void OnMove(MoveEvent e){
        for(int i=0;i<listeners.Count;i++){
            listeners[i].OnMove(e);
        }
    }

    override public void OnJump(JumpEvent e){
        for(int i=0;i<listeners.Count;i++){
            listeners[i].OnJump(e);
        }
    }

    public override void OnFixedUpdate()
    {
        for(int i=0;i<listeners.Count;i++){
            listeners[i].OnFixedUpdate();
        }
    }
}