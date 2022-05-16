using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvolutionManager : MonoBehaviour
{
    [SerializeField]private EvolutionStage[] evolutionStages;
    [SerializeField]private SpriteRenderer spriteRenderer;

    public int evolution_ID = 0;

    private bool loop = true;

    private void Awake()
    {
        ContentManager.capacity++;
    }

    private void OnDestroy()
    {
        ContentManager.capacity--;
    }

    private void Start()
    {
        //this.spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = evolutionStages[evolution_ID].Sprite;

        StartCoroutine(Money());
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

    /*
    public void Transfer()
    {
        switch (evolution_ID)
        {
            case 0:
                currencyManager.dogecoinAmount += 1f;
                break;
            case 1:
                currencyManager.dogecoinAmount += 2.5f;
                break;
            case 2:
                currencyManager.dogecoinAmount += 3.25f;
                break;

            default:
                Debug.Log("Something wrong ye");
                break;
        }
    }
    */

    IEnumerator Money()
    {
        while (loop == true)
        {
            yield return new WaitForSeconds(1f);

            switch (evolution_ID)
            {
                case 0:
                    currencyManager.dogecoinAmount += 1f;
                    break;
                case 1:
                    currencyManager.dogecoinAmount += 2.5f;
                    break;
                case 2:
                    currencyManager.dogecoinAmount += 3.25f;
                    break;
                case 3:
                    currencyManager.dogecoinAmount += 5f;
                    break;
                case 4:
                    currencyManager.dogecoinAmount += 9f;
                    break;
                case 5:
                    currencyManager.dogecoinAmount += 15.5f;
                    break;
                case 6:
                    currencyManager.dogecoinAmount += 20f;
                    break;
                case 7:
                    currencyManager.dogecoinAmount += 35f;
                    break;
                case 8:
                    currencyManager.dogecoinAmount += 50f;
                    break;

                default:
                    Debug.Log("Something wrong ye");
                    break;
            }
        }
    }
}
