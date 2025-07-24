using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shoppingSystem : MonoBehaviour
{
    public PlayerGameObjects playerobjdata;
    public Player playerdata;
    public PlayerInvertorySystem InvertorySystem;
    public GameObtainables InGameItems;

    public void Start()
    {
        GenerateStoreItems();
    }

    public void GenerateStoreItems()
    {
        Debug.Log(playerdata.Engine);
        /// Generating Engine Data
        generateItem<ShopEngine>(InGameItems.EnginesInGame, playerobjdata.EngineStoreClone,
        playerobjdata.ShopEngineCloneTransform, playerobjdata.EngineSprite, (eq) =>
        {
            playerdata.Engine.Add(eq);
            playerdata.save();
        });

        generateItem<ShopChassis>(InGameItems.ChassisInGame, playerobjdata.ChassisStoreClone,
        playerobjdata.ShopChassisCloneTransform, playerobjdata.ChassisSprite, (eq) =>
        {
            playerdata.Chassis.Add(eq);
            playerdata.save();
        });

        generateItem<ShopMaterial>(InGameItems.MaterialInGame, playerobjdata.MaterialStoreClone,
        playerobjdata.ShopMaterialCloneTransform, playerobjdata.MaterialSprite, (eq) =>
        {
            playerdata.Material.Add(eq);
            playerdata.save();
        }, additional: null);

        generateItem<ShopTires>(InGameItems.TiresInGame, playerobjdata.TiresStoreClone,
        playerobjdata.ShopTireCloneTransform, playerobjdata.TireSprite, (eq) =>
        {
            playerdata.Tires.Add(eq);
            playerdata.save();
        });

        generateItem<ShopNitros>(InGameItems.NitrosInGame, playerobjdata.NitrosStoreClone,
        playerobjdata.ShopNitrosCloneTransform, playerobjdata.NitrosSprite, (eq) =>
        {
            playerdata.Nitros.Add(eq);
            playerdata.save();
        }, additional: "Capacity");

    }

    public void generateItem<T>(Dictionary<string, Dictionary<string, int>> itemMap,
        GameObject gameObject, Transform transform, Sprite sprite, System.Action<dynamic> onAdded,
        string additional = "MaxHP")
    {
        foreach (KeyValuePair<string, Dictionary<string, int>> entry in itemMap)
        {
            var itemName = entry.Key;
            var itemData = entry.Value;
            var itemPrice = 0;
            itemData.TryGetValue("Price", out itemPrice);
            var additionalData = -1;
            if (additional != null)
            {
                itemData.TryGetValue(additional, out additionalData);
            }

            GameObject temp = Instantiate(gameObject);
            temp.transform.SetParent(transform, false);
            temp.SetActive(true);

            dynamic obj = temp.GetComponent<T>();
            obj.Name.text = itemName;

            Button infoButton = temp.GetComponent<Button>();

            infoButton.onClick.AddListener(() =>
            {
                playerobjdata.ShopInfoPrice.text = itemPrice + "";
                playerobjdata.ShopInfoItemName.text = itemName + "";
                playerobjdata.ShopNotEnoughMoney.text = "";
                playerobjdata.ShopInfoImage.sprite = sprite;
            });

            (obj.BuyButton as Button).onClick.AddListener(() =>
            {
                playerobjdata.ShopInfoPrice.text = itemPrice + "";
                playerobjdata.ShopInfoItemName.text = itemName + "";
                playerobjdata.ShopNotEnoughMoney.text = "";
                playerobjdata.ShopInfoImage.sprite = sprite;
                if (playerdata.playermoney >= itemPrice)
                {
                    playerdata.playermoney -= itemPrice;
                    if (additionalData != -1)
                    {
                        List<string> Equipment = new List<string>(new string[] { itemName, additionalData.ToString() });
                        onAdded.Invoke(Equipment);
                    }
                    else
                    {
                        onAdded.Invoke(itemName);
                    }
                }
                else
                {
                    playerobjdata.ShopNotEnoughMoney.text = "Not Enough Money";
                }
            });


        }
    }
}
