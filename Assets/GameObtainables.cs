using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObtainables : MonoBehaviour
{

    public Dictionary<string, Dictionary<string, int>> EnginesInGame;
    public Dictionary<string, Dictionary<string, int>> ChassisInGame;
    public Dictionary<string, Dictionary<string, int>> MaterialInGame;
    public Dictionary<string, Dictionary<string, int>> TiresInGame;
    public Dictionary<string, Dictionary<string, int>> NitrosInGame;
    void Start()
    {
        Engines();
        Chassises();
        Materials();
        Tires();
        Nitros();
    }
    public void Engines()
    {
        
        var HPBasic40 = new Dictionary<string, int>()
        {
            {"Weight", 50},
            {"MaxHP", 100},
            {"TopSpeed", 40},
            {"Torque", 2000},
            {"Price",10000},
        };
        var HPBoost60 = new Dictionary<string, int>()
        {
            {"Weight", 55},
            {"MaxHP", 120},
            {"TopSpeed", 60},
            {"Torque", 3500},
            {"Price",15000},
        };
        var HPCharge85 = new Dictionary<string, int>()
        {
            {"Weight", 60},
            {"MaxHP", 140},
            {"TopSpeed", 80},
            {"Torque", 4500},
            {"Price",25000},
        };
        var HPHybrid135 = new Dictionary<string, int>()
        {
            {"Weight", 70},
            {"MaxHP", 150},
            {"TopSpeed", 90},
            {"Torque", 5000},
            {"Price",50000},
        };
        var HPTwinTurbo240 = new Dictionary<string, int>()
        {
            {"Weight", 80},
            {"MaxHP", 180},
            {"TopSpeed", 115},
            {"Torque", 7500},
            {"Price",125000},
        };
        var HPTwinCharged350 = new Dictionary<string, int>()
        {
            {"Weight", 95},
            {"MaxHP", 210},
            {"TopSpeed", 135},
            {"Torque", 9500},
            {"Price",150000},
        };
        var HPTurboV6500 = new Dictionary<string, int>()
        {
            {"Weight", 100},
            {"MaxHP", 225},
            {"TopSpeed", 150},
            {"Torque", 12500},
            {"Price",200000},
        };
        var HPTwinTurboV6750 = new Dictionary<string, int>()
        {
            {"Weight", 120},
            {"MaxHP", 280},
            {"TopSpeed", 175},
            {"Torque", 15000},
            {"Price",300000},
        };
        var HPTurboV8800 = new Dictionary<string, int>()
        {
            {"Weight", 135},
            {"MaxHP", 350},
            {"TopSpeed", 200},
            {"Torque", 25000},
            {"Price",750000},
        };
        var HPTwinTurboV81050 = new Dictionary<string, int>()
        {
            {"Weight", 150},
            {"MaxHP", 450},
            {"TopSpeed", 225},
            {"Torque", 35000},
            {"Price",1000000},
        };
        var HPTurboV161250 = new Dictionary<string, int>()
        {
            {"Weight", 165},
            {"MaxHP", 750},
            {"TopSpeed", 250},
            {"Torque", 75000},
            {"Price",1500000},
        };
        var HPTwinTurboV161375 = new Dictionary<string, int>()
        {
            {"Weight", 185},
            {"MaxHP", 950},
            {"TopSpeed", 275},
            {"Torque", 100000},
            {"Price",2500000},
        };
        var HPQuadTurboV161595 = new Dictionary<string, int>()
        {
            {"Weight", 200},
            {"MaxHP", 1250},
            {"TopSpeed", 300},
            {"Torque", 125000},
            {"Price",3000000},
        };
        var HPQuadTurboW161885 = new Dictionary<string, int>()
        {
            {"Weight", 225},
            {"MaxHP", 1500},
            {"TopSpeed", 315},
            {"Torque", 175000},
            {"Price",5000000},
        };

        EnginesInGame = new Dictionary<string, Dictionary<string, int>>()
        {
            {"40 HP Basic", HPBasic40},
            {"60 HP Boost",HPBoost60},
            {"85 HP Charge",HPCharge85},
            {"135 HP Hybrid",HPHybrid135},
            {"240 HP Twin Turbo",HPTwinTurbo240},
            {"350 HP Twin Charged",HPTwinCharged350},
            {"500 HP Turbo V6",HPTurboV6500},
            {"750 HP Twin Turbo V6",HPTwinTurboV6750},
            {"800 HP Turbo V8 ",HPTurboV8800},
            {"1050 HP Twin Turbo V8",HPTwinTurboV81050},
            {"1250 HP Turbo V16",HPTurboV161250},
            {"1375 HP Twin Turbo V16",HPTwinTurboV161375},
            {"1595 HP Qaud Turbo Charged V16",HPQuadTurboV161595},
            {"1885 HP Quad Turbo Charged W16",HPQuadTurboW161885},
        };
    }
    public void Chassises()
    {
        Dictionary<string,int> Micro = new Dictionary<string, int>()
        {
            {"Weight",540},
            {"Speed",10},
            {"MaxHP",400}, 
            {"Price",15000},     
        };
        Dictionary<string,int> Compact = new Dictionary<string, int>()
        {
            {"Weight",600},
            {"Speed",15},
            {"MaxHP",450},     
            {"Price",30000},  
        };

        Dictionary<string,int> MPV = new Dictionary<string, int>()
        {
            {"Weight",750},
            {"Speed",25},
            {"MaxHP",1200},    
            {"Price",100000},
        };

        Dictionary<string,int> Muscle = new Dictionary<string, int>()
        {
            {"Weight",650},
            {"Speed",45},
            {"MaxHP",650},  
            {"Price",250000},     
        };

        Dictionary<string,int> Sedan = new Dictionary<string, int>()
        {
            {"Weight",550},
            {"Speed",50},
            {"MaxHP",550},   
            {"Price",500000},    
        };
        Dictionary<string,int> Roadster = new Dictionary<string, int>()
        {
            {"Weight",500},
            {"Speed",60},
            {"MaxHP",750},  
            {"Price",850000},     
        };
        Dictionary<string,int> Lightning = new Dictionary<string, int>()
        {
            {"Weight",300},
            {"Speed",100},
            {"MaxHP",450}, 
            {"Price",1000000},      
        };
        Dictionary<string,int> Sports = new Dictionary<string, int>()
        {
            {"Weight",400},
            {"Speed",120},
            {"MaxHP",950},    
            {"Price",1500000},  
        };

        ChassisInGame = new Dictionary<string, Dictionary<string, int>>()
        {
            {"Micro",Micro},
            {"Compact",Compact},
            {"MPV",MPV},
            {"Muscle",Muscle},
            {"Sedan",Sedan},
            {"Roadster",Roadster},
            {"Lightning",Lightning},
            {"Sports",Sports}
        };
    }
    public void Materials()
    {
        Dictionary<string,int> Iron = new Dictionary<string, int>()
        {
            {"HealthMultipliyer",1},
            {"WeightMultipliyer",3},
            {"SpeedMultipliyer",1},
            {"Price",10000},  
            
        };
        Dictionary<string,int> Aluminium = new Dictionary<string, int>()
        {
            {"HealthMultipliyer",2},
            {"WeightMultipliyer",1},
            {"SpeedMultipliyer",2},
            {"Price",75000},  
        };
        Dictionary<string,int> Steel = new Dictionary<string, int>()
        {
            {"HealthMultipliyer",2},
            {"WeightMultipliyer",4},
            {"SpeedMultipliyer",1},
            {"Price",75000},  
        };
        Dictionary<string,int> CarbonFiber = new Dictionary<string, int>()
        {
            {"HealthMultipliyer",4},
            {"WeightMultipliyer",1},
            {"SpeedMultipliyer",3},
            {"Price",150000},  
        };     

        MaterialInGame = new Dictionary<string, Dictionary<string, int>>()
        {
            {"Iron",Iron},
            {"Aluminium",Aluminium},
            {"Steel",Steel},
            {"Carbon Fiber",CarbonFiber},
        };
    }
    public void Tires()
    {
        Dictionary<string,int> LowGrip = new Dictionary<string, int>()
        {
            {"SteeringHelper",5},
            {"Traction",10},
            {"MaxHP",120},
            {"Price",4000},
        };

        Dictionary<string,int> MediumGrip = new Dictionary<string, int>()
        {
            {"SteeringHelper",7},
            {"Traction",10},
            {"MaxHP",180},
            {"Price",10000},
        };
        Dictionary<string,int> HighGrip = new Dictionary<string, int>()
        {
            {"SteeringHelper",10},
            {"Traction",10},
            {"MaxHP",240},
            {"Price",15000},
        };

        Dictionary<string,int> FlowGrip = new Dictionary<string, int>()
        {
            {"SteeringHelper",7},
            {"Traction",5},
            {"MaxHP",360},
            {"Price" ,25000},
        };

        Dictionary<string,int> SuperGrip = new Dictionary<string, int>()
        {
            {"SteeringHelper",8},
            {"Traction",3},
            {"MaxHP",400},
            {"Price",50000},
        };

        Dictionary<string,int> FastGrip = new Dictionary<string, int>()
        {
            {"SteeringHelper",9},
            {"Traction",1},
            {"MaxHP",640},
            {"Price",85000},
        };

        TiresInGame = new Dictionary<string, Dictionary<string, int>>()
        {
            {"Low Grip",LowGrip},
            {"Medium Grip",MediumGrip},
            {"High Grip",HighGrip},
            {"Flow Grip",FlowGrip},
            {"Super Grip",SuperGrip},
            {"Fast Grip",FastGrip},
        };
    }
    public void Nitros()
    {
        Dictionary<string,int> Litre1 = new Dictionary<string, int>()
        {
            {"Capacity",100},
            {"Price",2000},
        };
        Dictionary<string,int> Litre3 = new Dictionary<string, int>()
        {
            {"Capacity",300},
            {"Price",5000},
        };
        Dictionary<string,int> Litre5 = new Dictionary<string, int>()
        {
            {"Capacity",500},
            {"Price",8000},
        };
        Dictionary<string,int> Litre10 = new Dictionary<string, int>()
        {
            {"Capacity",1000},
            {"Price",15000},
        };
        Dictionary<string,int> Litre15 = new Dictionary<string, int>()
        {
            {"Capacity",1500},
            {"Price",20000},
        };        

        NitrosInGame = new Dictionary<string, Dictionary<string, int>>()
        {
            {"1 Litre",Litre1},
            {"3 Litre",Litre3},
            {"5 Litre",Litre5},
            {"10 Litre",Litre10},
            {"15 Litre",Litre15},
        };
    }
}
