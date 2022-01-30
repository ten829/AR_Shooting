using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    private int hp;
    private int bulletCount;
    [SerializeField, Header("最大Hp値")]
    private int maxHp;
    [SerializeField, Header("最大弾数値")]
    private int maxBullet;
    [SerializeField, Header("リロード時間")]
    private float reloadTime;
    [Tooltip("球の攻撃力")]
    public int bulletPower;
    [Header("球の連射速度")]
    public float shootInterval;
    [Header("球の射程距離")]
    public float shootRange;
    [Header("リロード機能のオン/オフ")]
    public bool isReloading;

    public int BulletCount
    {
        //set
        //{
        //bulletCount = value;
        //bulletCount = Mathf.Clamp(bulletCount, 0, maxBullet);
        //}
        //get
        //{
        //return bulletCount;
        //}
        set => bulletCount = Mathf.Clamp(value, 0, maxBullet);
        get => bulletCount;
    }
    // Start is called before the first frame update
    void Start()
    {
        SetUpPlayer();
    }
    public void SetUpPlayer()
    {
        //if(maxHp == 0)
        //{
        //maxHp = 10;
        //}
        //hp = maxHp;
        //if(maxBullet == 0)
        //{
        //maxBullet = 10;
        //}
        //BulletCount = maxBullet;
        hp = maxHp = maxHp == 0 ? 10 : maxHp;
    }
    public void CalcHP(int amount)
    {
        hp = Mathf.Clamp(hp += amount, 0, maxHp);
        Debug.Log("現在のHp:" + hp);
        if(hp <= 0)
        {
            Debug.Log("Game Over");
        }
    }
    public void CalcBulletCount(int amount)
    {
        BulletCount += amount;
        Debug.Log("現在の球数" + BulletCount);
    }
    public IEnumerator ReloadBullet()
    {
        isReloading = true;

        BulletCount = maxBullet;
        Debug.Log("リロード");
        yield return new WaitForSeconds(reloadTime);
        isReloading = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
