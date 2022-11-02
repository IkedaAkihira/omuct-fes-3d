using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerEkipu : Player{
    public GameObject attackObject;
    public float attackForce=1000f;

    public float attackWidthAngle = 12.0f;
    public Vector2 attackVibration = new Vector2(1.5f, 1.5f);
    public int splitInterval = 30;

    override protected void Attack()
    {
        
        Quaternion[] rotations = new Quaternion[1];
        rotations[0] = Quaternion.identity;
        //rotations[1] = Quaternion.Euler(0.0f, attackWidthAngle + attackVibration.x * (Random.value * 2.0f - 1.0f), attackVibration.y * (Random.value * 2.0f - 1.0f));
        //rotations[2] = Quaternion.Inverse(rotations[0]);

        foreach (Quaternion rawrot in rotations)
        {
            // 1. revert camera rotation
            // 2. apply main rotation (rawrot)
            // 3. re-apply camera rotation
            Quaternion rot = CameraRotationAsQuaternion * rawrot;

            // launch way
            Vector3 way = rot * new Vector3(-1f, 0f, 0f);

            GameObject cloneObject = Instantiate(attackObject, transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
            Rigidbody rb = cloneObject.GetComponent<Rigidbody>();
            rb.AddForce(way * attackForce);
            BulletEkipu bullet = cloneObject.GetComponent<BulletEkipu>();
            bullet.parent = this;
            bullet.parentEkipu = this;
            bullet.targetRotation = targetRot * rawrot;
        }
    }
}