using UnityEngine;
//Unity has it's own built-in funtionality to make pools streamlined
using UnityEngine.Pool;

public class SphereSpawner : MonoBehaviour
{
    [SerializeField]
    private SphereHandler spherePrefab;

    private ObjectPool<SphereHandler> pool;
    
    private void Awake()
    {
        pool = new ObjectPool<SphereHandler>
            (
            createFunc: CreateSphere,
            actionOnGet: OnGetSphere,
            actionOnRelease: OnReleaseSphere,
            actionOnDestroy: OnDestroySphere,
            collectionCheck: true,
            defaultCapacity: 8,
            maxSize: 10
            );
    }

    private void Update()
    {
        //prefab taken from pool on keypress
        if (Input.GetKeyDown(KeyCode.S))
        {
            SphereHandler sphere = pool.Get();
            sphere.transform.position = transform.position;
        }
    }

    private SphereHandler CreateSphere()
    {
        SphereHandler sphere = Instantiate(spherePrefab);
        sphere.SetPool(pool);
        return sphere;
    }

    private void OnGetSphere(SphereHandler sphere)
    {
        //activates the sphere when brought out da pool
        sphere.gameObject.SetActive(true);
    }

    private void OnReleaseSphere(SphereHandler sphere)
    {
        //deactivates the sphere when returned to da pool
        sphere.gameObject.SetActive(false);
    }

    private void OnDestroySphere(SphereHandler sphere)
    {
        //happens when the pool is not availible
        Destroy(sphere.gameObject);
    }

}

