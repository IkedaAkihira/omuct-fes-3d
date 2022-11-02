using UnityEngine;

public class Viberation{
    public int time;
    public float magnitude;
    public Viberation(int time,float magnitude){
        this.time = time;
        this.magnitude = magnitude;
    }
    
    public Vector2 GetVibeVec(){
        return new Vector2(Random.Range(0f,1f)*this.magnitude,Random.Range(0f,1f)*this.magnitude);
    }
}
