public class EventListener{
    ///<Summary>
    ///プレイヤーの攻撃前に呼ばれるイベント
    ///</Summary>
    virtual public void OnAttack(AttackEvent e){
        
    }

    ///<Summary>
    ///プレイヤーがダメージを受ける直前に呼ばれるイベント
    ///</Summary>
    virtual public void OnPreDamaged(PreDamagedEvent e){

    }

    ///<Summary>
    ///プレイヤーがダメージを受けた後に呼ばれるイベント
    ///</Summary>
    virtual public void OnDamaged(DamagedEvent e){

    }

    ///<Summary>
    ///プレイヤーのアイテム使用直前に呼ばれるイベント
    ///</Summary>
    virtual public void OnUseItem(UseItemEvent e){

    }

    ///<Summary>
    ///プレイヤーの移動前に呼ばれるイベント
    ///</Summary>
    virtual public void OnMove(MoveEvent e){

    }

    ///<Summary>
    ///プレイヤーのジャンプ前に呼ばれるイベント
    ///</Summary>
    virtual public void OnJump(JumpEvent e){

    }
}