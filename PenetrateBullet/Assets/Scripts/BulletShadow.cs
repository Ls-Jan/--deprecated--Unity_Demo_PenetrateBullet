using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShadow : MonoBehaviour{
    void OnCollisionEnter2D(Collision2D collision) {//撞到东西。如无设置错误，撞到的只会是墙
        print("击中墙壁");
    }
    void OnCollisionStay2D(Collision2D collision) {//子弹嵌入方块里头则直接销毁
        MonoBehaviour.Destroy(this.gameObject);
    }
}
