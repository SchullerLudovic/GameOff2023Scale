using UnityEngine;
using UnityEngine.SceneManagement;

public class IceCreamTowerMinigame : MonoBehaviour
{
    [field: SerializeField] public IceCreamHorizontalMover mover { get; private set; }
    [field: SerializeField] public IceCreamSpawner iceCreamSpawner { get; private set; }
    [field: SerializeField] public GameObject spawner { get; private set; }
    public int TowerHeight { get; private set; } = 0;

    private IceCreamPlatform cone;
    private IceCreamFallingObject currentFallingIceCream;

    private void Start()
    {
        SpawnIceCream();
    }

    private void SpawnIceCream()
    {
        if(currentFallingIceCream != null)
        {
            currentFallingIceCream.OnSuccess.RemoveAllListeners();
            currentFallingIceCream.OnFail.RemoveAllListeners();
        }

        TowerHeight += 1;
        float scale = 2f - (TowerHeight * 0.15f);

        currentFallingIceCream = iceCreamSpawner.SpawnIceCream(scale);
        mover.SetIceCream(currentFallingIceCream);

        currentFallingIceCream.OnSuccess.AddListener(() => { SpawnIceCream(); });
        currentFallingIceCream.OnFail.AddListener(() => { SceneManager.LoadScene(0); });
    }
}
