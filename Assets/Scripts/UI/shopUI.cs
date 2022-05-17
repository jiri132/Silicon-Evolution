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

     void Start()
    {
        ItemTemplate = ShopscrollView.GetChild(0).gameObject;

        int len = ShopItemList.Count;
        for(int i = 0; i < len; i++)
        {
            g = Instantiate(ItemTemplate, ShopscrollView);
            g.transform.GetChild(0).GetComponent<Image>().sprite = ShopItemList[i].Image;
            g.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Text>().text = ShopItemList[i].Price.ToString();
/*            buyBtn = g.transform.GetChild(2).GetComponent <Button> ();
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
