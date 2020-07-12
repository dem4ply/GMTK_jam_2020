using UnityEngine;
using chibi.controller.npc;
using System.Collections.Generic;
using platformer.controller.platform;

namespace platformer.controller.player
{
	public class Controller_game_platform: chibi.controller.Controller
	{
		public Controller_npc player;

		public List<GameObject> dangers_platforms;
		public List<GameObject> current_dangers;
		public List<Transform> helper_transforms;
		public GameObject platform_1;
		public GameObject platform_2;
		public Target_reach target_platform_1;
		public Target_reach target_platform_2;

		public Camera main_camera;

		public float radius_outside_platforms = 4;
		public float vertical_offset_random = 4;
		public float horizontal_offset_random = 4;

		public int current_platform = 0;

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !player )
				debug.error( "no esta asignado el player" );

			if ( !platform_1 )
				debug.error( "no esta asignado el target platform 1" );

			if ( !platform_2 )
				debug.error( "no esta asignado el target platform 2" );

			if ( !main_camera )
				debug.error( "no esta asignado la camara" );

			target_platform_1 = platform_1.GetComponentInChildren< Target_reach >();
			target_platform_2 = platform_2.GetComponentInChildren< Target_reach >();

			target_platform_1.player = player;
			target_platform_1.act = true;
			target_platform_1.manager = this;

			target_platform_2.player = player;
			target_platform_2.act = false;
			target_platform_2.manager = this;
		}

		public void set_next_level()
		{
			switch( current_platform )
			{
				case 0:
					target_platform_1.act = false;
					target_platform_2.act = true;
					current_platform = 1;
					break;
				case 1:
					target_platform_1.act = true;
					target_platform_2.act = false;
					current_platform = 0;
					break;
			}
		}

		public void create_ranfom_platforms()
		{
			set_next_level();
			var index = Mathf.FloorToInt( Random.value * dangers_platforms.Count );
			var new_platform = helper.instantiate._( dangers_platforms[ index ], new_position() );
			var danger = new_platform.GetComponentInChildren<Danger_platform>();
			danger.player = player;
			current_dangers.Add( new_platform );
			var temp = new GameObject( "helper_transform" );
			helper_transforms.Add( temp.transform );
			for ( int i = 0; i <= current_dangers.Count; ++i  )
			{
				var platform = current_dangers[ i ];
				var controller = platform.GetComponent< Platform_controller >();
				var trans = helper_transforms[ i ];
				trans.position = new_position();
				controller.seek( trans );
			}
		}

		public Vector3 new_position()
		{
			var camera_position = main_camera.transform.position;
			var vertical_offset = Random.Range( -vertical_offset_random, vertical_offset_random );
			var horizontal_offset = Random.Range( -horizontal_offset_random, horizontal_offset_random );
			var new_vector = new Vector3(
				0, camera_position.y + vertical_offset, camera_position.z + horizontal_offset );

			int max_try = 1000;
			int t = 0;

			while ( vector_near_to_platforms( new_vector ) && t <= max_try )
			{
				vertical_offset = Random.Range( -vertical_offset_random, vertical_offset_random );
				horizontal_offset = Random.Range( -horizontal_offset_random, horizontal_offset_random );
				new_vector = new Vector3(
					0, camera_position.y + vertical_offset, camera_position.z + horizontal_offset );
				t++;
			}
			return new_vector;
		}

		public bool vector_near_to_platforms( Vector3 v )
		{
			return Vector3.Distance( v, platform_1.transform.position ) <= radius_outside_platforms || Vector3.Distance( v, platform_2.transform.position ) <= radius_outside_platforms;
		}

		private void OnTriggerEnter( Collider other )
		{
			var controller = other.GetComponent< Controller_npc >();
			if ( controller == player )
			{
				debug.log( "target reach" );
			}
		}
	}
}
