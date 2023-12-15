using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace jmayberry.Shop.Resource {
	[CreateAssetMenu(menuName = "Resources/New Resource")]
	public class ResourceType : ScriptableObject {
		public string label;
		public Sprite icon;
		public string description;
	}

    [System.Serializable]
    public class ResourceAmount {
        public ResourceType resourceType;
        public int amount;
    }


    [Serializable]
    public class ResourceDictionary : SerializableDictionary<ResourceType, int> { }

    public class ResourceManager : MonoBehaviour {
        public static ResourceManager instance { get; private set; }
        private void Awake() {
            if (instance != null) {
                Debug.LogError("Found more than one BuildManager in the scene.");
            }
			instance = this;
        }

        [SerializeField]
        private List<ResourceAmount> resourcesEntries = new List<ResourceAmount>();
        private Dictionary<ResourceType, int> resources = new Dictionary<ResourceType, int>();

		public void AddResource(ResourceType type, int amount) {
			if (!resources.ContainsKey(type))
				resources[type] = 0;

			resources[type] += amount;
		}

		public bool ConsumeResources(List<ResourceAmount> costs) {
			// First check if enough resources
			foreach (var cost in costs) {
				if (!resources.ContainsKey(cost.resourceType) || resources[cost.resourceType] < cost.amount)
					return false; // Not enough resources
			}

			// Deduct resources
			foreach (var cost in costs) {
				resources[cost.resourceType] -= cost.amount;
			}

			return true; // Successful consumption
		}
	}

	[System.Serializable]
	public class Purchasable : MonoBehaviour {
		public List<ResourceManager.ResourceAmount> resourceCost;

		public bool Purchase() {
			return FindObjectOfType<ResourceManager>().ConsumeResources(buildingCost);
		}
	}
}
