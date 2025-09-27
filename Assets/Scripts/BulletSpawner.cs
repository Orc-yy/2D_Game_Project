using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public PlayerController playerCon;

    void Start()
    {
        InvokeRepeating("Shout", 2.0f, 1.0f);
    }

    void FixedUpdate()
    {
        // 총알의 방향을 계산
        if(playerCon.direction.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(playerCon.direction.y, playerCon.direction.x) * Mathf.Rad2Deg;
            angle -= 90;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = targetRotation;
        }
    }
    
    // 넉백 기능은 고려하지 않아서 나중에 추가하면 FixedUpdate로 옮기기
    void Shout()
    {
        // 총알을 생성 및 발사
        var bullet = ObjectPoolManager.instance.Pool.Get();
        bullet.transform.position = this.transform.position;
        bullet.transform.rotation = this.transform.rotation;
        bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * 10, ForceMode2D.Impulse);
    }
}
