using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class shopUI : MonoBehaviour
{
    [System.Serializable] class ShopItem
    {
        public Sprite Image;
        public int Price;
        public bool IsPurchased;
    }
    [SerializeField] List<ShopItem> ShopItemList;

    public GameObject ItemTemplate;
    GameObject g;
    [SerializeField] Transform ShopscrollView;
    Button buyBtn;
    int heigestId=0;
    [SerializeField]int visiblenum =1;
     void Start()
    {


        ItemTemplate = ShopscrollView.GetChild(0).gameObject;

        int Length = ShopItemList.Count;
        EvolutionManager[] obj = GameObject.FindObjectsOfType<EvolutionManager>();


        //check if the evolution_ID is bigger then 5
        for (int j = 0; j < obj.Length; j++)
        {
            if (heigestId < obj[j].evolution_ID)
            {
                heigestId = obj[j].evolution_ID;
                visiblenum = heigestId - 5;
                if (visiblenum < 0) { visiblenum = 2; }
            }
        }

        for (int i = 0; i < visiblenum; i++)
        {
            

           g = Instantiate(ItemTemplate, ShopscrollView);
           g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemList[i].Image;
           g.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = ShopItemList[i].Price.ToString();
/*          buyBtn = g.transform.GetChild(2).GetComponent <Button> ();
            Debug.Log("BUY");
          buyBtn.interactable =!ShopItemList [i].IsPurchased;;
          buyBtn.AddEventListener(i, OnShopItemBtnClicked);*/
        }
        Destroy(ItemTemplate);
    }
      void OnShopItemBtnClicked(int itemIndex)
    {
        if (Game.Instance.HasEnoughCoins (ShopItemList[itemIndex].Price)) {
            Game.Instance.UseCoins (ShopItemList[itemIndex].Price);
        }
        else
        {
            Debug.Log("You don't have enough!!");
        }
    }
    
}
