using UnityEngine;

public class Viberation{
    public int time;
    public float magnitude;
    public Viberation(int time,float magnitude){
        this.time = time;
        this.magnitude = magnitude;
    }
    
    public Vector2 GetVibeVec(){
        Unity Random rand = new Unity.Random();
        return new Vector2(rand.NextFloat()*this.magnitude,rand.NextFloat()*this.magnitude);
    }
}
