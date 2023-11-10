using UnityEngine;

public class IceCreamFallingObject : MonoBehaviour
{
    [field: SerializeField] public Collider2D Collider { get; private set; }
    [field: SerializeField] public SpriteRenderer Renderer { get; private set; }
    [field: SerializeField] public bool IsFalling { get; private set; }
    private const float fallingSpeed = 5f;

    private void Update()
    {
        if (IsFalling)
            transform.position -= new Vector3(0, fallingSpeed) * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsFalling)
        {
            if(collision.TryGetComponent(out IceCreamPlatform platform))
            {
                if (!platform.CanCatchFallingObjects)
                    return;

                IceCreamPlatform newPlatform = gameObject.AddComponent<IceCreamPlatform>();
                platform.CatchObject(newPlatform);
                newPlatform.Initialise(Collider);

                Destroy(this);
            }
        }
    }

    public void Fall()
    {
        if (IsFalling)
            return;

        IsFalling = true;
    }
}
