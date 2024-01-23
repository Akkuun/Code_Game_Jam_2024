 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCount : MonoBehaviour
{
    TMPro.TMP_Text text;
    int count;
    public float fixedXPosition = 0f;
    public float fixedYPosition = 10f;
    public float fixedZPosition = 0f;

    private void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();

    }

    void Start() => updatecount();
     void OnEnable() => collectible.onCollected += onCollectibleCollected;
     void OnDisable() => collectible.onCollected -= onCollectibleCollected;

    void onCollectibleCollected()
    {
        count++;
        updatecount();
    }

    void updatecount()
    {
        text.text = $"{count}";
    }
}
