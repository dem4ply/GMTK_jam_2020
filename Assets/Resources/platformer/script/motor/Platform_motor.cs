using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace platformer.motor.platform
{
	public class Platform_motor : chibi.motor.Motor
	{
		public int life_span = 10;

		protected override void _proccess_gravity( ref Vector3 velocity_vector )
		{
		}
	}
}
