using System;
using System.Collections;
using C5;

class user:square{
	bool alive=true;
	bool in_pit=false;
	int arrows=1;
	string direction=@"/\";
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

	public string Direction{
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

	//TODO make this more OOD please, it hurts to look at

	public void move(int x,int y){
		//TODO use events to update px and py
		x = x + base.X;
		y = y + base.Y;
		if(x>game.BOARD_SIZE-1||x<0||y>game.BOARD_SIZE-1||y<0){
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
				
	public override void land_on(){}

	public bool fire_arrow(string direction){//fire the arrow into some direction
		return false;
	}

	public string[] toString(){//return an array of stats
		ArrayList<string> temp=new ArrayList<string>();
		foreach(string v in base.toString()){
			temp.Add (v);
		}
		temp.Add ("Alive: "+alive.ToString());
		temp.Add ("In Pit: "+in_pit.ToString());
		temp.Add ("Arrows: "+arrows.ToString());
		temp.Add ("Direction: "+direction);
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