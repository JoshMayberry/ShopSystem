using System;

namespace jmayberry.Shop {

	[System.Serializable]
	public class ResourceAmount<ResourceType> where ResourceType : Enum {
		public ResourceType resourceType;
		public int amount;
	}
}