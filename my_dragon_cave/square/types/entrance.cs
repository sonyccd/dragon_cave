using System;

class entrance:square{
	public entrance(){}

	public entrance(String id){
		base.Id = id;
	}

	public override void land_on(){
		Console.WriteLine ("The air seems fresh...");
	}

	public void climb(){
		Console.WriteLine("You climbed out of the entrace.\n" +
			"You feel warm sunlight on your face.\n" +
			"You made it out.");
		Environment.Exit (0);
	}
}