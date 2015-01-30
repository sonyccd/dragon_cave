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
		Console.WriteLine(Name+" climbeds out of the entrace\n" +
			"and feels the warm sunlight.\n" +
			"You made it out.");
		Environment.Exit (0);
	}
}