using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using jmayberry.Shop;
using AYellowpaper.SerializedCollections;

public enum BuildingResource {
    Gold,
    Wood,
    Stone,
    Gem,
}

public class ResourceManager : ResourceManagerBase<BuildingResource> {
    public static ResourceManager instance { get; private set; }
    private void Awake() {
        if (instance != null) {
            Debug.LogError("Found more than one BuildManager in the scene.");
        }
        instance = this;
    }

    public void TestGainGold() {
        Debug.Log($"Adding Gold...; {this.resources[BuildingResource.Gold]}");
        this.AddResource(BuildingResource.Gold, 10);
        Debug.Log($"Gold Added; {this.resources[BuildingResource.Gold]}");
    }
    public void TestGainWood() {
        //Debug.Log($"Adding Wood...; {this.resources[BuildingResource.Wood]}");
        this.AddResource(BuildingResource.Wood, 10);
        Debug.Log($"Wood Added; {this.resources[BuildingResource.Wood]}");
    }
    public void TestCostWoodAndGold() {
        var cost = new SerializedDictionary<BuildingResource, int>();
        cost[BuildingResource.Wood] = 3;
        cost[BuildingResource.Gold] = 7;

        if (!this.ConsumeResources(cost)) {
            Debug.Log("Not Enough!");
        }
    }
}
