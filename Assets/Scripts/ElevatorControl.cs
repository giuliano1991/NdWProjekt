namespace VRTK.Examples
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class ElevatorControl : VRTK_InteractableObject
	{
		Elevator e;

		public override void StopUsing(VRTK_InteractUse previousUsingObejct)
		{
			base.StopUsing(previousUsingObejct);
		}

		public override void StartUsing(VRTK_InteractUse currentUsingObject)
		{
			base.StartUsing(currentUsingObject);
			e.ButtonPress ();
		}

		protected void Start()
		{
			e = GetComponent<Elevator>();
		}

		protected override void Update()
		{
			base.Update();
		}
	}
}