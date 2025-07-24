using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerInvertorySystem : MonoBehaviour
{
    public PlayerGameObjects playerobjdata;
    public Player playerdata;
    public GameObtainables InGameItems;

    void Start()
    {

    }

    public void InvertoryGenerator()
    {
        ItemGenerator<CloneEngineObjects>("Engine",playerdata.Engine,playerdata.Material, playerobjdata.scrollViewCloneEngine,
        playerobjdata.EngineCloneTransform, playerobjdata.currentEngine, playerdata.currentEngine
        , playerobjdata.currentEngineHealth, InGameItems.EnginesInGame
        , playerdata.SelectedEngine, (index) =>
        {
            playerdata.SelectedEngine = index;
        });

        ItemGenerator<CloneChassisObject>("Chassis",playerdata.Chassis,playerdata.Material, playerobjdata.scrollViewCloneChassis,
        playerobjdata.ChassisCloneTransform, playerobjdata.currentChassis, playerdata.currentChassis
        , playerobjdata.currentChassisHealth, InGameItems.ChassisInGame
        , playerdata.SelectedChassis, (index) =>
        {
            playerdata.SelectedChassis = index;
        });

        ItemGenerator<CloneMaterialObject>("Material",playerdata.Engine,playerdata.Material, playerobjdata.scrollViewCloneMaterial,
        playerobjdata.MaterialCloneTransform, playerobjdata.currentMaterial, playerdata.currentMaterial
        , playerobjdata.currentChassisHealth, InGameItems.MaterialInGame
        , playerdata.SelectedMaterial, (index) =>
        {
            playerdata.SelectedMaterial = index;
        });

        ItemGenerator<CloneTireObject>("Tires",playerdata.Tires,playerdata.Material, playerobjdata.scrollViewCloneTire,
        playerobjdata.TireCloneTransform, playerobjdata.currentTire, playerdata.currentTires
        , playerobjdata.currentTireHealth, InGameItems.TiresInGame
        , playerdata.SelectedTires, (index) =>
        {
            playerdata.SelectedTires = index;
        });

        ItemGenerator<CloneNitrosObject>("Nitros",playerdata.Nitros,playerdata.Material, playerobjdata.scrollViewCloneNitors,
        playerobjdata.NitrosCloneTransform, playerobjdata.currentNitros, playerdata.currentNitros
        , playerobjdata.currentNitrosLeft, InGameItems.NitrosInGame
        , playerdata.SelectedNitros, (index) =>
        {
            playerdata.SelectedNitros = index;
        });

    }

    public void ItemGenerator<T>(string Equipment,List<List<string>> PlayerItemMap,List<string> MaterialMap,GameObject IsToBeCloned, Transform transform,
    Text currentEngineDisplayText, string currentEngine, Slider HealthSlider,
    Dictionary<string, Dictionary<string, int>> ItemList, int initialSelected, System.Action<int> onIndexChange)
    {
        List<Text> EquipmentSelectedTextList = new List<Text>();
        int count = 0;

        if(Equipment == "Material")
        {
            count = MaterialMap.Count;
        }
        else
        {
            count = PlayerItemMap.Count;
        }

        for (int currIndex = 0; currIndex < count; currIndex++)
        {
            dynamic item;
            dynamic CurrentEquippedItem;
            var presentIndex = currIndex;
            if(Equipment == "Material")
            {
                item = MaterialMap[currIndex];
                CurrentEquippedItem = item;
            }
            else
            {
                item = PlayerItemMap[currIndex];
                CurrentEquippedItem = item[0];
            }


            GameObject temp = Instantiate(IsToBeCloned);
            dynamic obj = temp.GetComponent<T>();
            temp.SetActive(true);

            temp.transform.SetParent(transform, false);

            Button ChangeEquipment = temp.GetComponent<Button>();
            ChangeEquipment.onClick.AddListener(() => selectedChanger(presentIndex));

            obj.cloneText.text = CurrentEquippedItem + "";
            EquipmentSelectedTextList.Add(obj.selectedText);

            if (currIndex == initialSelected)
            {
                obj.selectedText.text = "Selected";
                currentEngineDisplayText.text = CurrentEquippedItem + "";
                currentEngine = CurrentEquippedItem;

                Dictionary<string, int> data = new Dictionary<string, int>();
                ItemList.TryGetValue(CurrentEquippedItem, out data);
                var MaxHEALTH = 0;
                if (Equipment=="Engine")
                {
                    data.TryGetValue("MaxHP", out MaxHEALTH);
                    HealthSlider.value = Convert.ToSingle(getHealthEngine()) / MaxHEALTH;
                }
                else if(Equipment=="Chassis")
                {
                    data.TryGetValue("MaxHP", out MaxHEALTH);
                    HealthSlider.value = Convert.ToSingle(getHealthChassis()) / MaxHEALTH;
                }
                else if(Equipment=="Tires")
                {
                    data.TryGetValue("MaxHP", out MaxHEALTH);
                    HealthSlider.value = Convert.ToSingle(getHealthTires()) / MaxHEALTH;
                }
                else if(Equipment == "Nitros")
                {
                    data.TryGetValue("Capacity", out MaxHEALTH);
                    HealthSlider.value = Convert.ToSingle(getHealthNitros()) / MaxHEALTH;
                }
                else if(Equipment == "Material")
                {
                    //data.TryGetValue("Capacity", out MaxHEALTH);
                    //HealthSlider.value = Convert.ToSingle(getHealth()) / MaxHEALTH;
                    Debug.Log("Material");
                }


            }
            void selectedChanger(int index)
            {
                onIndexChange.Invoke(index);
                currentEngineDisplayText.text = CurrentEquippedItem + "";
                foreach (Text EquipmentText in EquipmentSelectedTextList)
                {
                    EquipmentText.text = "";
                }

                Dictionary<string, int> data = new Dictionary<string, int>();
                ItemList.TryGetValue(CurrentEquippedItem, out data);
                var MaxHEALTH = 0;
                if (Equipment=="Engine")
                {
                    data.TryGetValue("MaxHP", out MaxHEALTH);
                    HealthSlider.value = Convert.ToSingle(getHealthEngine()) / MaxHEALTH;
                }
                else if(Equipment=="Chassis")
                {
                    data.TryGetValue("MaxHP", out MaxHEALTH);
                    HealthSlider.value = Convert.ToSingle(getHealthChassis()) / MaxHEALTH;
                }
                else if(Equipment=="Tires")
                {
                    data.TryGetValue("MaxHP", out MaxHEALTH);
                    HealthSlider.value = Convert.ToSingle(getHealthTires()) / MaxHEALTH;
                }
                else if(Equipment == "Nitros")
                {
                    data.TryGetValue("Capacity", out MaxHEALTH);
                    HealthSlider.value = Convert.ToSingle(getHealthNitros()) / MaxHEALTH;
                }
                else if(Equipment == "Material")
                {
                    //data.TryGetValue("Capacity", out MaxHEALTH);
                    //HealthSlider.value = Convert.ToSingle(getHealth()) / MaxHEALTH;
                    Debug.Log("Material");
                }

                obj.selectedText.text = "Selected";
                currentEngine = CurrentEquippedItem;
                Debug.Log("Changed to Engine to index " + index);
            }
        }

    }

    public string getHealthEngine()
    {
        return playerdata.Engine[playerdata.SelectedEngine][Constants.ENGINE_HEALTH_INDEX];
    }
    public string getHealthChassis()
    {
        return playerdata.Chassis[playerdata.SelectedChassis][Constants.ENGINE_HEALTH_INDEX];
    }
    public string getHealthTires()
    {
        return playerdata.Tires[playerdata.SelectedTires][Constants.ENGINE_HEALTH_INDEX];
    }
    public string getHealthNitros()
    {
        return playerdata.Nitros[playerdata.SelectedNitros][Constants.ENGINE_HEALTH_INDEX];
    }

}
