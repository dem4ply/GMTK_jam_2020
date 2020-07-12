using UnityEngine;
using chibi.controller.npc;
using System.Collections.Generic;
using platformer.controller.platform;

namespace platformer.controller.player
{
	public class Target_reach: chibi.controller.Controller
	{
		public Controller_npc player;
		public bool act = false;
		public Controller_game_platform manager;

		protected override void _init_cache()
		{
			base._init_cache();
			if ( !player )
				debug.error( "no esta asignado el player" );
		}


		private void OnTriggerEnter( Collider other )
		{
			var controller = other.GetComponent< Controller_npc >();
			if ( controller == player )
			{
				if ( act )
				{
					manager.create_ranfom_platforms();
				}
			}
		}
	}
}
