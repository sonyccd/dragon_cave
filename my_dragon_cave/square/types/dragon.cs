using System;

class dragon:square{
	public dragon(){}

	public dragon(string id){
		base.Id = id;
	}

	public override void land_on(){
		Console.WriteLine ("You found the dragon");
		game.you.Alive = false;
	}
}