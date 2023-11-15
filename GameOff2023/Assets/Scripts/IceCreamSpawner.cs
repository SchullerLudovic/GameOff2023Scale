using System.Collections.Generic;
using UnityEngine;

public class IceCreamSpawner : MonoBehaviour
{
    [SerializeField] private GameObject IceCreamPrefab;
    [SerializeField] private List<Color> colors = new List<Color>();

    public IceCreamFallingObject SpawnIceCream(float scale)
    {
        GameObject obj = Instantiate(IceCreamPrefab);
        obj.transform.localScale = Vector3.one * scale;

        IceCreamFallingObject ice = obj.GetComponent<IceCreamFallingObject>();

        if (colors.Count <= 0)
        {
            ice.Renderer.color = Color.white;
        }
        else
        {
            int index = Random.Range(0, colors.Count);
            ice.Renderer.color = colors[index];
        }

        return ice;
    }
}