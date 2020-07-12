using UnityEngine;
using chibi.controller.npc;
using System.Collections.Generic;
using platformer.controller.platform;

namespace platformer.controller.player
{
	public class Danger_platform: chibi.controller.Controller
	{
		public Controller_npc player;
		public Controller_game_platform manager;

		private void OnTriggerEnter( Collider other )
		{
			var controller = other.GetComponent< Controller_npc >();
			if ( controller == player )
			{
				manager.set_lose();
			}
		}
	}
}
