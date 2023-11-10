using UnityEngine;

public class IceCreamHorizontalMover : MonoBehaviour
{
    [SerializeField] private InputReader InputReader;
    public IceCreamFallingObject iceCream;

    private void Awake()
    {
        InputReader.ShootEvent.AddListener(HandleShoot);
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