using UnityEngine;
using chibi.controller.npc;
using System.Collections.Generic;
using platformer.controller.platform;

namespace platformer.controller.player
{
	public class Destroy_on_player_exit : chibi.controller.Controller
	{
		public Controller_npc player;

		private void OnTriggerExit( Collider other )
		{
			var controller = other.GetComponent< Controller_npc >();
			if ( controller == player )
			{
				Destroy( this.gameObject );
			}
		}

		private void OnCollisionExit( Collision collision )
		{
			var controller = collision.gameObject.GetComponent< Controller_npc >();
			if ( controller == player )
			{
				Destroy( this.gameObject );
			}
		}
	}
}
