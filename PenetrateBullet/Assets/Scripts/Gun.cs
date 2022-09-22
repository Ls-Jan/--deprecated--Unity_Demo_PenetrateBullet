using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#pragma warning disable 0649//这0649警告是真的吵的要死

public class Gun : MonoBehaviour {
    [SerializeField] private Transform firePoint;//射击点
    [SerializeField] private Bullet bullet;//子弹预制件
    [SerializeField] private float bulletSpeed;//子弹速度
    [SerializeField] private float interval;//射击时延(秒)
    private float enable = 0;//判断是否可以射击。值小于0时无法射击。该值仅协程可以修改


    void Update() {
        Vector2 pos = Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition);//获取鼠标位置
        Vector2 vector = pos - (Vector2)gameObject.transform.position;//获取朝向
        gameObject.transform.right = vector;//设置方向

        if (Input.GetMouseButton(0)) {//判断左键是否按下。这里不用Input.GetButton纯属是个人故意这么做
            if (this.enable >= 0) {//可射击
                this.StartCoroutine(this.__Shoot(vector));//使用协程。为啥用那么多的this呢？这是个人习惯，刚从python回来，习惯了python的self语法，到这里就个人强制都使用this
            }
        }
    }

    private IEnumerator __Shoot(Vector2 vector) {
        var bullet = Instantiate(this.bullet, this.firePoint.position, this.firePoint.rotation);//打出的子弹
        bullet.GetComponent<Rigidbody2D>().velocity = vector.normalized * this.bulletSpeed;//赋予其速度

        this.enable = -this.interval;
        while (this.enable < 0) {
            yield return new WaitForSeconds(0.1f);//等0.1秒
            this.enable += 0.1f;
        }
        yield break;
    }
}
