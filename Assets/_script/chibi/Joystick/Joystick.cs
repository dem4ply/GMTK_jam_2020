using UnityEngine;
using System.Collections.Generic;
using chibi.controller;

namespace chibi.joystick
{
	public class Joystick : chibi.Chibi_behaviour
	{
		#region public vars
		public string key_map = "player 1";
		public Controller controller;

		public Axis desire_direction;

		public List<string> actions = new List<string>() {
			"fire1", "fire2", "fire3", };
		public List<Axis> axis_actions = new List<Axis>() {};
		private List<bool> axis_is_up;

		public List<Axis> axis = new List<Axis>();
		#endregion

		#region public properties
		#endregion

		#region public functions
		public void update_all_axis()
		{
			desire_direction.update();
		}
		#endregion

		#region funciones protegdas
		protected void Update()
		{
			update_all_axis();
			if ( desire_direction.pass_dead_zone )
			{
				controller.desire_direction = desire_direction.vector;
				controller.speed = 1f;
			}
			else
			{
				controller.desire_direction = Vector3.zero;
				controller.speed = 0f;
			}

			foreach ( Axis axi in axis )
			{
				axi.update();
				if ( axi.pass_dead_zone )
					controller.direction( axi );
			}

			foreach ( string action in actions )
			{
				if ( check_action_down( action ) )
					controller.action( action, "down" );
				if ( check_action_up( action ) )
					controller.action( action, "up" );
			}

			for ( int i = 0; i < axis_actions.Count; ++i )
			{
				var axis = axis_actions[ i ];
				axis.update();
				if ( axis_is_up[ i ] )
				{
					if ( !axis.pass_dead_zone )
					{
						controller.action( axis.name, "up" );
						axis_is_up[ i ] = false;
					}
				}
				else
				{
					if ( axis.pass_dead_zone )
					{
						controller.action( axis.name, "down" );
						axis_is_up[ i ] = true;
					}
				}
			}
			/*
			debug.log(
				"{0} {1}",
				Input.GetAxis( "p1__trigger__left" ),
				Input.GetAxis( "p1__trigger__right" ) );

			debug.log(
				"{0} {1}",
				Input.GetButton( "p1__bumper__left" ),
				Input.GetButton( "p1__bumper__right" ) );
			*/
		}

		/// <summary>
		/// inicializa el chache del script
		/// </summary>
		protected override void _init_cache()
		{
			if ( controller == null )
				controller = GetComponent<Controller>();
			if ( !desire_direction )
			{
				debug.error( "no hay un axis de desire_direction" );
			}
			axis_is_up = new List<bool>( axis_actions.Count );
			for ( int i = 0; i < axis_actions.Count; ++i )
				axis_is_up.Add( false );
		}

		protected virtual bool check_action_down( string action )
		{
			return Input.GetButtonDown( action );
		}

		protected virtual bool check_action_up( string action )
		{
			return Input.GetButtonUp( action );
		}
		#endregion
	}
}
