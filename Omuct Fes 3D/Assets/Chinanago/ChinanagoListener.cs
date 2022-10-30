public class ChinanagoListener: EventListener{
    public void OnMove(MoveEvent e){
        if(e.player is PlayerChinanago){
            PlayerChinanago chinanago = (PlayerChinanago)e.player;
            if(chinanago.diveTime>0 || chinanago.surfaceTime>0){
                e.isAvailable = false;
            }
        }
    }
    public void OnAttack(AttackEvent e){
        if(e.attacker is PlayerChinanago){
            PlayerChinanago chinanago = (PlayerChinanago)e.attacker;
            if(chinanago.diveTime>0 || chinanago.surfaceTime>0){
                e.isAvailable = false;
            }
        }
    }
    public void OnDamaged(DamageEvent e){
        if(e.damagedPlayer is PlayerChinanago){
            PlayerChinanago chinanago = (PlayerChinanago)e.damagedPlayer;
            if(chinanago.diveTime>0){
                e.isAvailable = false;
            }
        }
    }
    public void OnUseItem(UseItemEvent e){
        if(e.itemUser is PlayerChinanago){
            PlayerChinanago chinanago = (PlayerChinanago)e.itemUser;
            if(chinanago.diveTime>0 || chinanago.surfaceTime>0){
                e.isAvailable = false;
            }
        }
    }
    public void OnJump(JumpEvent e){
        if(e.player is PlayerChinanago){
            e.isAvailable = false;
            PlayerChinanago chinanago = (PlayerChinanago)e.player;
            if(chinanago.diveTime==0&&chinanago.surfaceTime==0){
                chinanago.animator.SetTrigger("Dive");
                chinanago.diveTime = 150;
            }
        }
    }
}