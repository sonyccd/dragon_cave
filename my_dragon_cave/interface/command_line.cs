﻿using System;
using System.Collections.Generic;
using System.Reflection;

class command_line{
	HashSet<string> q_syns = new HashSet<string> {"q","Q","quit","Quit"};
	Dictionary<string,Action> ops=new Dictionary<string,Action>()
	{
		{"F",operations.move_forward},
		{"L",operations.move_left},
		{"R",operations.move_right},
		{"C",operations.climb_up},
		{"X",operations.debug},
		{"A",operations.arrow},
		{"S",operations.stats},
		{"G",operations.grab},
		{"H",operations.help}
	};

	string intro;

	string user_moves="Commands:\n" +
		"Move (F)orward, Turn (L)eft, Turn (R)ight,\n" +
		"(G) grab the Gold, (A) shoot the Arrow, (C) climb out.\n" +
		"(Q) quit the game, Use (X) for map and\n" +
		"use (S) for user stats\n"+
		"\n"+
		"GOOD LUCK!\n";

	public command_line(){}

	public void logo(){
		Console.WriteLine(@"  _______ _             _____                  ");
		Console.WriteLine(@" |__   __| |           / ____|   /\            ");
		Console.WriteLine(@"    | |  | |__   ___  | |       /  \__   _____ ");
		Console.WriteLine(@"    | |  | '_ \ / _ \ | |      / /\ \ \ / / _ \");
		Console.WriteLine(@"    | |  | | | |  __/ | |____ / ____ \ V /  __/");
		Console.WriteLine(@"    |_|  |_| |_|\___|  \_____/_/    \_\_/ \___|");
		Console.WriteLine ();
	}

	void set_intro(){
		intro =game.you.Name+" wakes up, it's dark, "+game.you.Name+" hears a drip of water in the distance.\n" +
			game.you.Name+" grabs a tourch and lights it.\n" +
			game.you.Name+" was in some kind of cave.\n" +
			"A loud ROAR!!!! comes from the distance.\n" +
			"A dragon is some where in this cave.\n" +
			"Reaching for the bow "+game.you.Name+" finds only one arrow thats not broken.\n" +
			"Find the gold, and get out before you find the dragon!!!!\n"+
			"Welcome to...\n";
	}

	public void prompt(){
		Console.WriteLine ("Whats your name?");
		game.you.Name = Console.ReadLine ();
		set_intro ();
		next_scene ();
		Console.Write (intro);
		next_scene ();
		logo ();
		next_scene ();
		Console.WriteLine (user_moves);
		next_scene ();
		while(true){
			Console.Write ("\n{"+game.you.get_direction()+"}>");
			string temp = Console.ReadLine();
			if(q_syns.Contains(temp)){
				break;
			}else{
				interpret (temp);
				game.dungeon.board_update ();
			}
		}
	}

	public void next_scene(){
		Console.WriteLine ("\nNext(N)...");
		while(Console.ReadLine()!="N"){}
		System.Console.Clear ();
		return;
	}

	void interpret(string command){//runs comands in the dictionay
		try{
			ops [command]();
			game.status();
			Console.WriteLine();
			game.you.prox();
		}catch(KeyNotFoundException ){
			Console.WriteLine("That is not a valid move");
			Console.WriteLine ("type H for help");
		}
	}
}

