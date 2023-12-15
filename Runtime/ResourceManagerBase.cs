using System;
using UnityEngine;

using AYellowpaper.SerializedCollections;

namespace jmayberry.Shop {
    public abstract class ResourceManagerBase<ResourceType> : MonoBehaviour where ResourceType : Enum {
        [SerializedDictionary("Resource", "Amount")]
        public SerializedDictionary<ResourceType, int> resources;

        public void AddResource(ResourceType resource, int amount) {
            if (!this.resources.ContainsKey(resource)) {
                this.resources[resource] = 0;
            }

            this.resources[resource] += amount;
        }

        public bool ConsumeResources(SerializedDictionary<ResourceType, int> costs) {
            foreach (var cost in costs) {
                if (!this.resources.ContainsKey(cost.Key)) {
                    return false;
                }

                if (this.resources[cost.Key] < cost.Value) {
                    return false;
                }
            }

            foreach (var cost in costs) {
                this.resources[cost.Key] -= cost.Value;
            }

            return true;
        }
    }
}
