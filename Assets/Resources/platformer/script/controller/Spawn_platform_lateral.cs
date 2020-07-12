using UnityEngine;
using chibi.controller.npc;
using System.Collections.Generic;

namespace platformer.controller.platform
{
	public class Spawn_platform_lateral : chibi.controller.Controller
	{
		public Transform platform_1_position;
		public GameObject platform_1_prefab;
		public Transform platform_2_position;
		public GameObject platform_2_prefab;
		public Transform platform_3_position;
		public GameObject platform_3_prefab;
		public Transform platform_4_position;
		public GameObject platform_4_prefab;

		public void spawn( int index )
		{
			switch ( index )
			{
				case 1:
					spawn( platform_1_position.position, platform_1_prefab, Quaternion.identity );
					break;
				case 2:
					spawn( platform_2_position.position, platform_2_prefab, Quaternion.identity );
					break;
				case 3:
					spawn( platform_3_position.position, platform_3_prefab, Quaternion.identity );
					break;
				case 4:
					spawn( platform_4_position.position, platform_4_prefab, Quaternion.identity );
					break;
			}
		}

		public void spawn( Vector3 position, GameObject obj, Quaternion rotation )
		{
			helper.instantiate._( obj, position );
		}
	}
}
