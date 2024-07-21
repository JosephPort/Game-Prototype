using UnityEngine;

public class Steel
{
    public string customName;
    public string vehicleType;
    public string prefabName;

    public int wins;
    public int racesCompleted;

    public float bestTime;
    
    // public List<Upgrades> upgrades = new List<Upgrades>
    //     {
    //         new Upgrades(5),
    //         new Upgrades(3),
    //         new Upgrades(2),
    //         new Upgrades(2)
    //     };

    public Customization customization = new Customization();
    
    public Steel(string prefabName)
    {
        vehicleType = "Steel";
        this.prefabName = prefabName;
    }

    // public class Upgrades
    // {
    //     public int[] ownedStage { get; set; }
    //     public int[] equippedStage { get; set; }

    //     public Upgrades(int colSize)
    //     {
    //         ownedStage = new int[colSize];
    //         equippedStage = new int[colSize];
    //     }
    // }

    public class Customization
    {
        public float hue = 0;
        public float saturation = 0;
        public float value = 0.8f;
        public float reflectionPower = 0.15f;
    }
}