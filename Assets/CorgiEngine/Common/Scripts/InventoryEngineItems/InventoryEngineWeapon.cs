using UnityEngine;
using System.Collections;
using MoreMountains.Tools;
using System;
using MoreMountains.InventoryEngine;

namespace MoreMountains.CorgiEngine
{	
	[CreateAssetMenu(fileName = "InventoryEngineWeapon", menuName = "MoreMountains/CorgiEngine/InventoryEngineWeapon", order = 2)]
	[Serializable]
	/// <summary>
	/// Pickable health item
	/// </summary>
	public class InventoryEngineWeapon : InventoryItem 
	{

		[Header("Weapon")]
		[Information("Here you need to bind the weapon you want to equip when picking that item.",InformationAttribute.InformationType.Info,false)]
		public Weapon EquippableWeapon;

		public override void Equip()
		{
			if (EquippableWeapon == null)
			{
				return;
			}
			if (TargetInventory.Owner == null)
			{
				return;
			}
			CharacterHandleWeapon characterHandleWeapon = TargetInventory.Owner.GetComponent<CharacterHandleWeapon>();
			if (characterHandleWeapon != null)
			{
				characterHandleWeapon.ChangeWeapon (EquippableWeapon);
			}
		}
	}
}
