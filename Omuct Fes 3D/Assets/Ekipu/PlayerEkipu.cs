using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerEkipu : Player{
    public GameObject attackObject;
    public float attackForce=1000f;

    public float attackWidthAngle = 8.0f;
    public Vector2 attackVibration = new Vector2(1.5f, 1.5f);


    override protected void Attack()
    {
        Quaternion targetRot = Quaternion.Euler(0.0f, -Mathf.Rad2Deg * cameraRotation, Mathf.Rad2Deg * cameraRotationY);
        Quaternion targetRotInv = Quaternion.Inverse(targetRot);

        Quaternion[] rotations = new Quaternion[3];
        rotations[0] = Quaternion.Euler(0.0f, attackWidthAngle + attackVibration.x * (Random.value * 2.0f - 1.0f), attackVibration.y * (Random.value * 2.0f - 1.0f));
        rotations[1] = Quaternion.identity;
        rotations[2] = Quaternion.Inverse(rotations[0]);

        foreach (Quaternion rawrot in rotations)
        {
            // 1. revert camera rotation
            // 2. apply main rotation (rawrot)
            // 3. re-apply camera rotation
            Quaternion rot = targetRot * rawrot * targetRotInv;

            // launch way
            Vector3 way = rot * toTargetVec;

            GameObject cloneObject = Instantiate(attackObject, transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
            Rigidbody rb = cloneObject.GetComponent<Rigidbody>();
            rb.AddForce(way * attackForce);
            BulletEkipu bullet = cloneObject.GetComponent<BulletEkipu>();
            bullet.parent = this;
        }
    }
}