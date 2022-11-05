using UnityEngine;

public class Skill : MonoBehaviour {
    protected Player player;
    void Awake()
    {
        player = GetComponent<Player>();
        GameMaster.instance.listeners.Add(CreateListener());
    }

    virtual protected EventListener CreateListener(){
        return null;
    }
}