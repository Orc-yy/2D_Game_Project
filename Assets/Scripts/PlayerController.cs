using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float rotationSpeed = 10f;
    private Vector2 moveInput;

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 direction = moveInput.normalized;

        if (direction.sqrMagnitude > 0.01f)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            angle -= 90;
            Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }

        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
    
    // 넉백 기능은 고려하지 않아서 나중에 추가하면 FixedUpdate로 옮기기
    void Shout()
    {
        var bullet = ObjectPoolManager.instance.Pool.Get();
        bullet.transform.position = this.transform.position;
    }
}
