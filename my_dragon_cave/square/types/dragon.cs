using System;

class dragon:square{
	public dragon(){}

	public dragon(string id){
		base.Id = id;
	}

	public override void land_on(){
		Console.WriteLine (game.you.Name+" found the dragon");
		game.you.Alive = false;
	}
}