using System;
using C5;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

class game{

	//TODO have some kind of config file that can be read it to get rid of static use
	//TODO craping squids, i got the x anf y axis mixed up
	//****************************
	//CONFIG
	public static int BOARD_SIZE=4;
	public static int NUM_DRAGON = 1;
	public static int NUM_PIT=3;
	public static int NUM_ENTRANCE = 1;
	public static int NUM_GOLD=1;
	public static int NUM_USER=1;
	public static int TOTAL_PIECES=NUM_DRAGON+NUM_PIT+NUM_ENTRANCE+NUM_GOLD;

	public static string DRAGON_ID="D";
	public static string PIT_ID="P";
	public static string ENTRANCE_ID="E";
	public static string GOLD_ID="G";
	public static string USER_ID="U";
	//****************************

	//****************************
	//DATA STRUCTURES
	public static board dungeon=new board();//the board the game is played on 
	public static ArrayList<square> pieces = new ArrayList<square> ();//all the pieces
	public static user you=new user(USER_ID);
	public static Dictionary<int,square> locate = new Dictionary<int,square> ();
	public static command_line cl=new command_line();
	//****************************

	public game(){//TODO make this not part of the constructor but as an init
		pieces_init ();
		game_board_init ();
		place_pieces ();
		init_locate ();
		cl.prompt ();
	}

	void pieces_init(){//build pieces
		int i = 0;
		for(i=0;i<NUM_DRAGON;i++){pieces.Add (new dragon(DRAGON_ID));}
		for(i=0;i<NUM_PIT;i++){pieces.Add (new pit (PIT_ID));}
		for(i=0;i<NUM_GOLD;i++){pieces.Add (new gold (GOLD_ID));}
		for(i=0;i<NUM_ENTRANCE;i++){pieces.Add (new entrance (ENTRANCE_ID));}
	}

	void init_locate(){//this creates a simple lookup for how to react to landing
		foreach(square s in pieces){
			if (!s.Id.Equals(USER_ID)) {//filter users
				locate.Add ((BOARD_SIZE*s.X)+s.Y, s);
			}
		}
	}
		
	void place_pieces(){
		Random seed=new Random();
		try{
			int count=0;
			while(count<pieces.Count){
				while(true){
					int xt=seed.Next(0,BOARD_SIZE-1);
					int yt=seed.Next(0,BOARD_SIZE-1);
					if(dungeon.get_piece(xt,yt)=="[ ]"){
						pieces[count].X=xt;
						pieces[count].Y=yt;
						dungeon.board_update();
						count++;
						break;
					}
				}
			}
		}catch(NullReferenceException){
			Console.WriteLine ("The pieces have not be initalized");
			Environment.Exit (-1);//TODO create exit code for errors
		}
	}

	void game_board_init(){//builds blank board and inserts pieces
		dungeon.init_board();
	}

	public static void status(){
		if(!you.Alive){
			Console.WriteLine ("You died");
			Environment.Exit (0);
		}
	}
}