using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


namespace jmayberry.Shop {
	[CreateAssetMenu(menuName = "Resources/New Resource")]
	public class Resource : ScriptableObject {
		public string label;
		public Sprite icon;
		public string description;
	}

	[System.Serializable]
	public class ResourceAmount {
		public Resource resource;
		public int amount;
	}

	[System.Serializable]
	public class Purchasable : MonoBehaviour {
		public List<ResourceAmount> resourceCost;

		public bool Purchase() {
			return ResourceManager.instance.ConsumeResources(resourceCost);
		}
	}
}
