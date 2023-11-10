using UnityEngine;

public class IceCreamTowerMinigame : MonoBehaviour
{
    [field: SerializeField] public GameObject spawner { get; private set; }
    [field: SerializeField] public IceCreamHorizontalMover mover { get; private set; }
    public int TowerHeight { get; private set; } = 0;

    [SerializeField] private GameObject IceCreamPrefab;

    private IceCreamPlatform cone;
    private IceCreamFallingObject iceCream;

    private void Start()
    {
        SpawnIceCream();
    }

    private void SpawnIceCream()
    {
        GameObject obj = Instantiate(IceCreamPrefab, spawner.transform.position, Quaternion.identity);

        iceCream = obj.GetComponent<IceCreamFallingObject>();
        mover.iceCream = iceCream;

        TowerHeight += 1;
    }
}
