using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    public IObjectPool<GameObject> Pool { get; set; }

    void Update()
    {

        if (this.transform.position.y > 20 || this.transform.position.y < -20)
        {
            // 오브젝트 풀에 반환
            Pool.Release(this.gameObject);
        }
    }
}
    

