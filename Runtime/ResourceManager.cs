using System;
using System.Collections.Generic;
using UnityEngine;

using AYellowpaper.SerializedCollections;

namespace jmayberry.Shop {
    public class ResourceManager : MonoBehaviour {
        public static ResourceManager instance { get; private set; }

        private void Awake() {
            if (instance != null) {
                Debug.LogError("Found more than one BuildManager in the scene.");
            }
            instance = this;
        }

        [SerializedDictionary("Resource", "Amount")]
        public SerializedDictionary<Resource, int> resources;

        public void AddResource(Resource resource, int amount) {
            if (!resources.ContainsKey(resource)) {
                resources[resource] = 0;
            }

            resources[resource] += amount;
        }

        public bool ConsumeResources(List<ResourceAmount> costs) {
            foreach (var cost in costs) {
                if (!resources.ContainsKey(cost.resource) || resources[cost.resource] < cost.amount)
                    return false; // Not enough resources
            }

            foreach (var cost in costs) {
                resources[cost.resource] -= cost.amount;
            }

            return true;
        }
    }
}
