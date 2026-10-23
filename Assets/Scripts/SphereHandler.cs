using UnityEngine;
using UnityEngine.Pool;

public class SphereHandler : MonoBehaviour
{
    private Rigidbody sphereRB;
    private float lifetime = 2f;

    private ObjectPool<SphereHandler> poolReference;

    private void Awake()
    {
        sphereRB = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        //invoke calls a function after a certain amount of time
        Invoke(nameof(BackToPool), lifetime);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Update()
    {
        //Debug.Log(lifetime);
        sphereRB.AddForce(transform.right * 0.5f * Time.deltaTime, ForceMode.Impulse);
    }

    //puts it back in da pool
    private void BackToPool()
    {
        //Debug.Log("sent back to pool");
        poolReference.Release(this);
    }

    public void SetPool(ObjectPool<SphereHandler> pool)
    {
        poolReference = pool;
    }

}
