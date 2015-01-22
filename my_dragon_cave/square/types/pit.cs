using System;
class pit:square{
	public pit(){
	}

	public pit(String id){
		base.Id = id;
	}

	public override void land_on(){
		Console.WriteLine ("Fell into a pit");
		game.you.Alive = false;
	}
}