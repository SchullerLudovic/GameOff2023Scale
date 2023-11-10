using UnityEngine;

public class IceCreamHorizontalMover : MonoBehaviour
{
    [SerializeField] private IceCreamTowerMinigame minigame;
    [SerializeField] private InputReader InputReader;
    public IceCreamFallingObject iceCream;

    [SerializeField] private Transform leftTransform;
    [SerializeField] private Transform rightTransform;

    private Vector3 goalPosition;
    private bool goLeft;

    private void Awake()
    {
        InputReader.ShootEvent.AddListener(HandleShoot);

        goalPosition = rightTransform.position;
    }

    private void Update()
    {
        if (iceCream.IsFalling)
            return;

        iceCream.transform.position = Vector3.Lerp(iceCream.transform.position, goalPosition, Time.deltaTime * (.5f * minigame.TowerHeight));

        float distance = Vector3.Magnitude(iceCream.transform.position - goalPosition);
        if (distance < 1 && distance > -1)
        {
            if(goLeft)
            {
                goalPosition = rightTransform.position;
            }
            else
            {
                goalPosition = leftTransform.position;
            }

            goLeft = !goLeft;
        }
    }

    private void OnDisable()
    {
        InputReader.ShootEvent.RemoveListener(HandleShoot);
    }

    private void HandleShoot()
    {
        iceCream?.Fall();
    }
}