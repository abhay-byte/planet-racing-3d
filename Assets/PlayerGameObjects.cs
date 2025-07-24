using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGameObjects : MonoBehaviour
{
    public Text name;
    public Text homePlanet;
    public GameObject PlayerNamingPanel;

    public Text homePageUsername;
    public Text homePageHomePlanet;
    public Text spaceCoins;
    public Text spaceGems;
    public Text Reputation;

    public Text currentEngine;
    public Text currentChassis;
    public Text currentMaterial;
    public Text currentTire;
    public Text currentNitros;

    public Slider currentEngineHealth;
    public Slider currentChassisHealth;
    public Slider currentTireHealth;
    public Slider currentNitrosLeft;

    public Slider vehicleSpeed;
    public Slider vehicleAcceleration;
    public Slider vehicleDurability;

    public GameObject scrollViewCloneEngine;
    public GameObject scrollViewCloneChassis;
    public GameObject scrollViewCloneMaterial;
    public GameObject scrollViewCloneTire;
    public GameObject scrollViewCloneNitors;

    public Text cloneEngineText;
    public Text cloneChassisText;
    public Text cloneMaterialText;
    public Text cloneTireext;
    public Text cloneNitrosText;

    public Text selectedEngineText;
    public Text selectedChassisText;
    public Text selectedMaterialText;
    public Text selectedTireText;
    public Text selectedNitrosText;

    public Transform EngineCloneTransform;
    public Transform ChassisCloneTransform;
    public Transform MaterialCloneTransform;
    public Transform TireCloneTransform;
    public Transform NitrosCloneTransform;

    public GameObject EngineStoreClone;
    public GameObject ChassisStoreClone;
    public GameObject MaterialStoreClone;
    public GameObject TiresStoreClone;
    public GameObject NitrosStoreClone;

    public Transform ShopEngineCloneTransform;
    public Transform ShopChassisCloneTransform;
    public Transform ShopMaterialCloneTransform;
    public Transform ShopTireCloneTransform;
    public Transform ShopNitrosCloneTransform;

    public Image ShopInfoImage;
    public Text ShopInfoItemName;
    public Text ShopInfoPrice;
    public Text ShopNotEnoughMoney;

    public Sprite EngineSprite;
    public Sprite ChassisSprite;
    public Sprite MaterialSprite;
    public Sprite TireSprite;
    public Sprite NitrosSprite;


}
