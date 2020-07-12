using UnityEngine;
using chibi.controller.npc;
using System.Collections.Generic;

namespace platformer.controller.platform
{
	public class Spawn_platform_lateral : chibi.controller.Controller
	{
		public Controller_npc player;
		public Rigidbody npc_rigidbody;
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
					if ( is_falling() )
					{
						var mag = Mathf.Min( platform_1_position.localPosition.magnitude, 2f );
						var vector = npc_rigidbody.velocity.normalized * mag;
						vector = transform.TransformPoint( vector );
						spawn( vector, platform_1_prefab, Quaternion.identity );
					}
					else
					{
						spawn( platform_1_position.position, platform_1_prefab, Quaternion.identity );
					}
					break;
				case 2:
					if ( is_falling() )
					{
						var mag = Mathf.Min( platform_2_position.localPosition.magnitude, 2f );
						var vector = npc_rigidbody.velocity.normalized * mag;
						vector = transform.TransformPoint( vector );
						spawn( vector, platform_1_prefab, Quaternion.identity );
					}
					else
					{
						spawn( platform_2_position.position, platform_1_prefab, Quaternion.identity );
					}
					break;
				case 3:
					spawn( platform_3_position.position, platform_3_prefab, Quaternion.identity );
					break;
				case 4:
					spawn( platform_4_position.position, platform_4_prefab, Quaternion.identity );
					break;
			}
		}

		public bool is_falling()
		{
			return npc_rigidbody.velocity.y < -0.5f;
		}

		public Vector3 get_falling_vector()
		{
			return npc_rigidbody.velocity;
		}

		public void spawn( Vector3 position, GameObject obj, Quaternion rotation )
		{
			var g = helper.instantiate._( obj, position );
			var p = g.GetComponent<platformer.controller.player.Destroy_on_player_exit>();
			p.player = player;
		}
	}
}
