using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }
    public float speed = 5f;

    void Update()
    {

        if (this.transform.position.y > 5 || this.transform.position.y < -5)
        {
            // 오브젝트 풀에 반환
            Pool.Release(this.gameObject);
        }

        this.transform.Translate(Vector3.up * this.speed * Time.deltaTime);
    }
}
    

