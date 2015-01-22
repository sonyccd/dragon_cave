using System;
using System.Collections;
using C5;

abstract class square{
	string id;
	string name;
	int x;
	int y;
	int px;
	int py;

	public square(){}

	public abstract void land_on();

	public string Id{
		get{
			return id;
		}
		set{
			id = value;
		}
	}

	public string Name{
		get{
			return name;
		}
		set{
			name = value;
		}
	}

	public int X{
		get{
			return x;
		}
		set{
			x = value;
		}
	}

	public int Y{
		get{
			return y;
		}
		set{
			y = value;
		}
	}

	public int Px{
		get{
			return px;
		}
		set{
			px=value;
		}
	}

	public int Py{
		get{
			return py;
		}
		set{
			py = value;
		}
	}
		
	public string[] toString(){
		ArrayList<string> temp = new ArrayList<string> ();
		temp.Add ("X: "+x.ToString ());
		temp.Add ("Y: "+y.ToString ());
		temp.Add ("Id: "+id);
		temp.Add ("Name: "+name);
		return temp.ToArray ();
	}

	public void toScreen(){
		Console.WriteLine("\n==========");
		Console.WriteLine ("Name: " + name);
		Console.WriteLine ("ID: " + id);
		Console.WriteLine ("X: " + x);
		Console.WriteLine ("Y: " + y);
		Console.WriteLine ("==========");
	}
}