using System;
using System.Collections.Generic;
using C5;

class board{

	string[,] game_board=new string[game.BOARD_SIZE,game.BOARD_SIZE];
	public board(){
	}
		
	public void init_board(){//builds a blank board
		for (int i = 0; i < game_board.GetLength(0); i++) {
			for (int j = 0; j < game_board.GetLength(1); j++) {
				game_board [i,j] = "[ ]";
			}
		}
	}
		
	public void show_board(){
		board_update ();
		for(int i=0;i<game_board.GetLength(0);i++){
			Console.Write ("\n");
			for(int j=0;j<game_board.GetLength(1);j++){
				Console.Write (game_board [i, j] + " ");
			}
		}
	}

	public void board_update(){
		//TODO make the update one operation
		//TODO make this run once as a event call 
		foreach(square s in game.pieces){
			game_board[s.X,s.Y]="["+s.Id+"]";
			game_board[s.Px,s.Py]="[ ]";
		}
	}

	public dynamic get_piece(int x,int y){
		return game_board [x, y];
	}
}

