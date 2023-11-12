using UnityEngine;

public class IceCreamHorizontalMover : MonoBehaviour
{
    [SerializeField] private IceCreamTowerMinigame minigame;
    [SerializeField] private InputReader InputReader;

    [SerializeField] private Transform leftTransform;
    [SerializeField] private Transform rightTransform;

    public IceCreamFallingObject IceCream { get; private set; }

    private Vector3 currentPosition;
    private Vector3 targetPosition;

    private bool goLeft;
    private float movementTimer;
    private const float MaxTime = 2f;
    private float currentMaxTime = 2f;

    private void Awake()
    {
        InputReader.ShootEvent.AddListener(HandleShoot);
        currentPosition = leftTransform.position;
        targetPosition = rightTransform.position;
        movementTimer = 0f;
    }

    private void Update()
    {
        if (IceCream.IsFalling)
            return;

        MoveSideways();
        ChangeTarget();
    }

    private void OnDisable()
    {
        InputReader.ShootEvent.RemoveListener(HandleShoot);
    }

    public void SetIceCream(IceCreamFallingObject iceCream)
    {
        IceCream = iceCream;

        Debug.Log(iceCream.transform.position + " - " + leftTransform.position);

        IceCream.transform.position = leftTransform.position;
        Debug.Log(iceCream.transform.position + " - " + leftTransform.position);
    }

    private void HandleShoot()
    {
        IceCream?.Fall();
    }

    private void MoveSideways()
    {
        movementTimer += Time.deltaTime;
        IceCream.transform.position = Vector3.Lerp(currentPosition, targetPosition, movementTimer / currentMaxTime);
    }

    private void ChangeTarget()
    {
        if (movementTimer < currentMaxTime)
            return;

        movementTimer = 0f;
        currentMaxTime = MaxTime - (minigame.TowerHeight * 0.1f);

        if (goLeft)
        {
            targetPosition = rightTransform.position;
            currentPosition = leftTransform.position;
        }
        else
        {
            targetPosition = leftTransform.position;
            currentPosition = rightTransform.position;
        }

        goLeft = !goLeft;
    }
}