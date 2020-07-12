using UnityEngine;
using chibi.controller.npc;
using System.Collections.Generic;
using platformer.controller.platform;

namespace platformer.controller.player
{
	public class Intro_script: chibi.controller.Controller
	{
		public Controller_npc player;
		public chibi.pomodoro.Pomodoro_obj pomo;
		public GameObject tuto;
		public GameObject score;

		private void Update()
		{
			if ( pomo.tick( Time.deltaTime ) )
			{
				if ( Input.anyKey )
				{
					gameObject.SetActive( false );
					tuto.SetActive( true );
					score.SetActive( true );
				}
			}
			else
			{
				player.speed = 0f;
			}
		}
	}
}
