﻿using System;

class operations{
	//TODO convert to event driven system
	//best part of this, events are built in
	//damn I love C#

	//CRAP I made a mess of this code
	//oooo well, will be fixed in an update
	//damn it, no this has to get fixed now
	operations(){}

	public static void move_forward(){
		Console.WriteLine ("forward");
		game.you.move ();
		//game.you.move (-1, 0);
	}
	public static void move_backward(){
		Console.WriteLine ("backward");
		//game.you.move (1, 0);
	}
	public static void move_left(){
		Console.WriteLine ("rotate left");
		game.you.rotate (false);
	}
	public static void move_right(){
		Console.WriteLine ("rotate right");
		game.you.rotate (true);
	}
	public static void climb_down(){
		//Console.WriteLine ("down");
	}
	public static void climb_up(){
		Console.WriteLine ("up");
	}
	public static void grab(){
		Console.WriteLine ("grab");
		//TODO need some operation for grab
	}
	public static void debug(){
		game.dungeon.show_board ();
	}
	public static void stats(){
		game.you.toScreen ();
	}
}

