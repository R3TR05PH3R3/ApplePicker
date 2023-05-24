using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Market_Handler : MonoBehaviour
{
    public ShopItem[] shopItems;
    public ShopTemplate[] shopPanels;
    public GameObject[] shopPanelsGO;
    public Button[] myPurchaseBtn;
    public Material[] materials;
    public GameObject ApplePrefab;
    private void Start()
    {
        for (int i = 0; i < shopItems.Length; i++)
        {
            shopPanelsGO[i].SetActive(true);
        }
        LoadPanels();
        CheckPurchase();
    }
    private void Update()
    {
        LoadPanels();
        CheckPurchase();
    }
    public void LoadPanels()
    {
        for(int i = 0; i < shopItems.Length; i++)
        {
            shopPanels[i].titleTxt.text = shopItems[i].title;
            shopPanels[i].descriptionTxt.text = shopItems[i].description;
            if(shopItems[i].isPurchased == false)
            {
                shopPanels[i].costTxt.text = shopItems[i].cost.ToString() + " Coins";
            }
            else
            {
                shopPanels[i].costTxt.text = "Purchased";
            }
        }
    }

    public void CheckPurchase()
    {
        for(int i = 0; i < shopItems.Length; i++)
        {
            if(CoinUI.COIN_COUNT >= shopItems[i].cost || shopItems[i].isPurchased == true)
            {
                myPurchaseBtn[i].interactable = true;
            }
            else
            {
                myPurchaseBtn[i].interactable = false;
            }
        }
    }

    public void PurchaseItem(int btnNo)
    {
        if (CoinUI.COIN_COUNT >= shopItems[btnNo].cost && shopItems[btnNo].isPurchased == false)
        {
            CoinUI.DeduceCoins(shopItems[btnNo].cost);
            shopItems[btnNo].isPurchased = true;
            Renderer prefabRenderer = ApplePrefab.GetComponentInChildren<Renderer>();
            if (prefabRenderer != null)
            {
                prefabRenderer.material = materials[btnNo];
            }
            CheckPurchase();
        }else if(shopItems[btnNo].isPurchased == true)
        {
            Renderer prefabRenderer = ApplePrefab.GetComponentInChildren<Renderer>();
            if (prefabRenderer != null)
            {
                prefabRenderer.material = materials[btnNo];
            }
            CheckPurchase();
        }
    }
    [Tooltip("Check this box to add 100 coins")]
    public bool addCoin = false;

    void OnDrawGizmos()
    {
        if (addCoin)
        {
            addCoin = false;
            int currentCoinValue = PlayerPrefs.GetInt("Coin", 0);
            int newValue = currentCoinValue + 100;
            PlayerPrefs.SetInt("Coin", newValue);
            Debug.LogWarning("PlayerPrefs Coin reset to 0.");
        }
    }
}
