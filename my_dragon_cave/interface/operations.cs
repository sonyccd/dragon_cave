using System;

class operations{
	//TODO convert to event driven system
	//best part of this, events are built in
	//damn I love C#
	operations(){}

	public static void move_forward(){
		Console.WriteLine ("forward");
		game.you.move (-1, 0);
		game.you.Direction=@"/\";
	}
	public static void move_backward(){
		Console.WriteLine ("backward");
		game.you.move (1, 0);
		game.you.Direction=@"\/";
	}
	public static void move_left(){
		Console.WriteLine ("left");
		game.you.move (0, -1);
		game.you.Direction="<";
	}
	public static void move_right(){
		Console.WriteLine ("right");
		game.you.move (0, 1);
		game.you.Direction=">";
	}
	public static void climb_down(){
		//Console.WriteLine ("down");
	}
	public static void climb_up(){
		Console.WriteLine ("up");
	}
	public static void grab(){
		Console.WriteLine ("grab");

	}
	public static void debug(){
		game.dungeon.show_board ();
	}
	public static void stats(){
		game.you.toScreen ();
	}
}

