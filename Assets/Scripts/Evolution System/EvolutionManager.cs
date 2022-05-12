using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionManager : MonoBehaviour
{
    [SerializeField]private EvolutionStage[] evolutionStages;
    private SpriteRenderer spriteRenderer;

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
}
