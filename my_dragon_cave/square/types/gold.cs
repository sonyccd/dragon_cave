using System;

class gold:square{
	public gold(){}

	public gold(String id){
		base.Id = id;
	}

	public override void land_on(){
		Console.WriteLine ("The light of your torch is reflecting off something...");
	}
	public void grab(){
		base.Id=" ";
	}
}