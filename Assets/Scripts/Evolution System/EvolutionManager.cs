using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionManager : MonoBehaviour
{
    [SerializeField]private EvolutionStage[] evolutionStages;
    [SerializeField]private SpriteRenderer spriteRenderer;

    public int evolution_ID = 0;

    private void Start()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = evolutionStages[evolution_ID].Sprite;
    }

    public void SetImage()
    {
        spriteRenderer.sprite = evolutionStages[evolution_ID].Sprite;
    }

    public void Combine()
    {
        evolution_ID++;
        SetImage();
    }

    public void Transfer()
    {
        switch (evolution_ID)
        {
            case 1:
                currencyManager.dogecoinAmount += 1f;
                break;
            case 2:
                currencyManager.dogecoinAmount += 2.5f;
                break;
            case 3:
                currencyManager.dogecoinAmount += 3.25f;
                break;
        }
    }
}
