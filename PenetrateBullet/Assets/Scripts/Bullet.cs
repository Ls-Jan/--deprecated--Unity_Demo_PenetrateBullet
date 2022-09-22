using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{
    void OnTriggerEnter2D(Collider2D collider) {//撞到东西
        print("击中目标(穿透)");
    }
    void OnCollisionEnter2D(Collision2D collision) {//撞到东西
        print("击中目标(碰撞)");
    }
}
