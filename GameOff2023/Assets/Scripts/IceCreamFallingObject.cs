using UnityEngine;
using UnityEngine.Events;

public class IceCreamFallingObject : MonoBehaviour
{
    [field: SerializeField] public Collider2D Collider { get; private set; }
    [field: SerializeField] public SpriteRenderer Renderer { get; private set; }
    [field: SerializeField] public bool IsFalling { get; private set; }

    public UnityEvent OnSuccess { get; private set; } = new();
    public UnityEvent OnFail { get; private set; } = new();

    private const float fallingSpeed = 5f;
    private const string DeathTag = "Death zone";

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

                OnSuccess?.Invoke();

                IceCreamPlatform newPlatform = gameObject.AddComponent<IceCreamPlatform>();
                platform.CatchObject(newPlatform);
                newPlatform.Initialise(Collider);

                Destroy(this);
            }
            else if (collision.tag.Equals(DeathTag))
            {
                OnFail?.Invoke();
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
