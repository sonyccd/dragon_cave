using System;
using System.Collections;
using C5;
using System.Resources;
using System.Collections.Generic;

class user:square{
	bool alive=true;
	bool in_pit=false;
	int arrows=1;
	int direction=1;
	static string[] directions=new string[]{@"/\",">",@"\/","<"};
	
	int gold=0;

	public user(){}

	public user(String id){
		base.Id = id;
	}

	public bool Alive{
		get{
			return alive;
		}
		set{
			alive = value;
		}
	}

	public bool In_Pit{
		get{
			return in_pit;
		}
		set{
			in_pit = value;
		}
	}

	public int Direction{
		get{
			return direction;
		}
		set{
			direction = value;
		}
	}

	public int Gold{
		get{
			return gold;
		}
		set{
			gold = value;
		}
	}

	public void rotate(bool r){
		if(r){
			if(direction+1>=directions.Length){
				direction = 0;
			}else{
				direction++;
			}
		}else{
			if (direction - 1 < 0) {
				direction = 3;
			} else {
				direction--;
			}
		}
	}

	public int[] direction_to_move(){
		if(direction==0){
			return new int[]{ -1, 0 };
		}else if(direction==2){
			return new int[]{ 1, 0 };
		}else if(direction==3){
			return new int[]{ 0,-1 };
		}else if(direction==1){
			return new int[]{ 0, 1 };
		}else{
			return new int[]{ 0, 0 };
		}
	}

	//TODO make this more OOD please, it hurts to look at

	public void move(){
		int[] temp=direction_to_move ();
		int x = temp[0] + base.X;
		int y = temp[1] + base.Y;
		if(!on_map(x,y)){
			Console.WriteLine ("You hit a wall");
			return;
		}
		int hash = ((game.BOARD_SIZE * x) + y);
		if(game.locate.ContainsKey(hash)){
			game.locate [hash].land_on();
		}
		base.Px=base.X;
		base.Py = base.Y;
		base.X = x;
		base.Y = y;
	}
				
	public bool on_map(int x,int y){
		if(x>game.BOARD_SIZE-1||x<0||y>game.BOARD_SIZE-1||y<0){
			return false;
		}
		return true;
	}

	public override void land_on(){}

	public void fire_arrow(){//fire the arrow into some direction
		if(arrows<=0){
			Console.WriteLine ("Your out of arrows");
			return;
		}
		try{
			if(direction==0||direction==2){
				if(direction==0){
					for(int i=base.X;i>=0;i--){
						int hash = ((game.BOARD_SIZE * i) + base.Y);
						if (game.locate.ContainsKey (hash)) {
							if (game.locate [hash].GetType () == typeof(dragon)) {
								kill_dragon (hash);
								return;
							}
						}
					}
				}else{
					for(int i=base.X;i<game.BOARD_SIZE;i++){
						int hash = ((game.BOARD_SIZE * i) + base.Y);
						if (game.locate.ContainsKey (hash)) {
							if (game.locate [hash].GetType () == typeof(dragon)) {
								kill_dragon (hash);
								return;
							}
						}
					}
				}
			}else{
				if(direction==3){
					for(int i=base.Y;i>=0;i--){
						int hash = ((game.BOARD_SIZE * base.X) + i);
						if (game.locate.ContainsKey (hash)) {
							if (game.locate [hash].GetType () == typeof(dragon)) {
								kill_dragon (hash);
								return;
							}
						}
					}
				}else{
					for(int i=base.Y;i<game.BOARD_SIZE;i++){
						int hash = ((game.BOARD_SIZE * base.X) + i);
						if (game.locate.ContainsKey (hash)) {
							if (game.locate [hash].GetType () == typeof(dragon)) {
								kill_dragon (hash);
								return;
							}
						}
					}
				}
			}
			Console.WriteLine("You missed");
			arrows--;
		}catch(KeyNotFoundException){
			Console.WriteLine ("You missed");
		}
	}

	void kill_dragon(int hash){
		arrows--;
		Console.WriteLine ("You hear the roar of a dragon in the distance...");
		Console.WriteLine ("and then silence...");
		game.pieces.Remove (game.locate [hash]);
		game.locate.Remove (hash);
	}

	public void grab(){
		int hash = ((game.BOARD_SIZE * base.X) + base.Y);
		if(game.locate.ContainsKey(hash)){
			if(game.locate[hash].GetType()==typeof(gold)){
				gold++;
				Console.WriteLine ("You got the Gold!");
			}else{
				Console.WriteLine ("No gold here");
				return;
			}
		}else{
			return;
		}
	}

	public void climb(){
		int hash = ((game.BOARD_SIZE * base.X) + base.Y);
		if(game.locate.ContainsKey(hash)){
			if (game.locate [hash].GetType () == typeof(entrance) && gold > 0) {
				Console.WriteLine ("You got out!!");
				Environment.Exit (0);
			}else if(game.locate[hash].GetType()==typeof(entrance)&& gold<=0){
				Console.WriteLine ("You need to go back and get the gold!");
			}else{
				Console.WriteLine ("Not the way out");
				return;
			}
		}else{
			return;
		}
	}

	public string get_direction(){
		return directions [direction];
	}

	public void prox(){
		int hash;
		bool dr=true;
		bool pi=true;
		if (on_map (base.X + 1, base.Y)) {
			hash = ((game.BOARD_SIZE * (base.X + 1)) + base.Y);
			if (game.locate.ContainsKey (hash)) {
				if (game.locate [hash].GetType () == typeof(dragon)&&dr) {
					Console.WriteLine ("Something smells...");
					dr = false;
				}
				if (game.locate [hash].GetType () == typeof(pit)&&pi) {
					Console.WriteLine ("I feel a breeze...");
					pi = false;
				}
			}
		}
		if(on_map (base.X - 1, base.Y)){
			hash = ((game.BOARD_SIZE * (base.X-1)) + base.Y);
			if (game.locate.ContainsKey (hash)) {
				if (game.locate [hash].GetType () == typeof(dragon)&&dr) {
					Console.WriteLine ("Something smells...");
					dr = false;
				}
				if (game.locate [hash].GetType () == typeof(pit)&&pi) {
					Console.WriteLine ("I feel a breeze...");
					pi = false;
				}
			}
		}
		if(on_map (base.X, base.Y+1)){
			hash = ((game.BOARD_SIZE * base.X) + (base.Y+1));
			if (game.locate.ContainsKey (hash)) {
				if (game.locate [hash].GetType () == typeof(dragon)&&dr) {
					Console.WriteLine ("Something smells...");
					dr = false;
				}
				if (game.locate [hash].GetType () == typeof(pit)&&pi) {
					Console.WriteLine ("I feel a breeze...");
					pi = false;
				}
			}
		}
		if(on_map (base.X , base.Y-1)){
			hash = ((game.BOARD_SIZE * base.X) + (base.Y-1));
			if (game.locate.ContainsKey (hash)) {
				if (game.locate [hash].GetType () == typeof(dragon)&&dr) {
					Console.WriteLine ("Something smells...");
					dr = false;
				}
				if (game.locate [hash].GetType () == typeof(pit)&&pi) {
					Console.WriteLine ("I feel a breeze...");
					pi = false;
				}
			}
		}
	}

	public string[] toString(){//return an array of stats
		ArrayList<string> temp=new ArrayList<string>();
		foreach(string v in base.toString()){
			temp.Add (v);
		}
		temp.Add ("Alive: "+alive.ToString());
		temp.Add ("In Pit: "+in_pit.ToString());
		temp.Add ("Arrows: "+arrows.ToString());
		temp.Add ("Direction: "+directions[direction]);
		temp.Add ("Gold: "+gold.ToString());
		return temp.ToArray ();
	}

	public void toScreen(){//print stats to screen
		Console.WriteLine("\n==========");
		foreach(string s in this.toString()){
			Console.WriteLine (s);
		}
		Console.WriteLine("==========");
	}
}