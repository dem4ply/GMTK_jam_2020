using UnityEngine;
using chibi.controller.npc;
using System.Collections.Generic;
using platformer.controller.platform;

namespace platformer.controller.player
{
	public class Danger_platform: chibi.controller.Controller
	{
		public Controller_npc player;

		private void OnTriggerEnter( Collider other )
		{
			var controller = other.GetComponent< Controller_npc >();
			if ( controller == player )
			{
				debug.error( "deberia de termiar la partida" );
			}
		}
	}
}
