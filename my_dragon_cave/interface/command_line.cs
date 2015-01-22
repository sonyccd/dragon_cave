using System;
using System.Collections.Generic;
using System.Reflection;

class command_line{
	HashSet<string> q_syns = new HashSet<string> {"q","Q","quit","Quit"};//things someone might
	//use as a quit command
	Dictionary<string,Action> ops=new Dictionary<string,Action>()
	{
		{"F",operations.move_forward},
		{"B",operations.move_backward},
		{"L",operations.move_left},
		{"R",operations.move_right},
		{"U",operations.climb_up},
		{"D",operations.climb_down},
		{"X",operations.debug},
		//{"A",operations.arrow},
		{"S",operations.stats},
		{"G",operations.grab}
	};

	string intro="Welcome to Dragon Cave!\n" +
		"Try to find the gold and return here to climb back out.\n" +
		"You have 1 arrow that you can shoot.\n" +
		"Try the following commands:\n" +
		"Move (F)orward, Turn (L)eft, Turn (R)ight,\n" +
		"(G)rab the Gold, (A)hoot the Arrow, (C)limb out.\n" +
		"(Q)uit the game, Use (X) to cheat and\n" +
		"use (S) for user stats\n";

	public command_line(){}

	public void prompt(){
		Console.Write (intro);
		while(true){
			Console.Write ("\n{"+game.you.Direction+"}>");
			string temp = Console.ReadLine();
			if(q_syns.Contains(temp)){
				break;
			}else{
				interpret (temp);
				game.dungeon.board_update ();
			}
		}
	}

	void interpret(string command){//runs comands in the dictionay
		try{
			ops [command]();
			game.status();
		}catch(KeyNotFoundException e){
			Console.WriteLine("That is not a valid move");
		}
	}
}