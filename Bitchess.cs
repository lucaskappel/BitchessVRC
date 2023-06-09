using System;

namespace ZBCvr{
	public class Bitchess{
		
		public ulong[][] Gamestate;
		private int GamestateIndex;
		private ulong[][] GamestateShadow;
		private int GamestateShadowIndex;
		
		public Bitchess(){}//Bitchess
		
		public void Engine(){
			Gamestate = new ulong[2][]{
				Bitboard.NewBitboard(configuration),
				Bitboard.NewBitboard("empty")
			}; // Give it 2 to allow for generic calculation of en passante without extra logic to skip the first check.
			GamestateIndex = 0;
			
			GamestateShadow = new ulong[4][];
			GamestateShadowIndex = 0;
			return;
		}//Engine
		
		#region gamestate manipulation
		
		public ulong[] GetCurrentGamestate(){
			return Gamestate[GamestateIndex];
		}//GamestateCurrent
		
		public void GamestateAdd(ulong[] bitboard){
			// main array
			Gamestate[GamestateIndex + 1] = bitboard;
			GamestateIndex++;
			
			// shadow array
			GamestateShadow[GamestateShadowIndex] = Gamestate[GamestateShadowIndex];
			GamestateShadowIndex++;
			GamestateShadow[GamestateShadowIndex] = Gamestate[GamestateShadowIndex];
			GamestateShadowIndex++;
			
			// Once GamestateShadowIndex has caught up to the GamestateIndex, Gamestate is full and must be replaced by GamestateShadow.
			// Replace GamestateShadow with a new array twice the previous length.
			if(GamestateIndex == GamestateShadowIndex){
				Gamestate = GamestateShadow;
				GamestateShadow = new ulong[Gamestate.Length * 2][];
			}
			return;
		}//BitboardAdd
		
		public void GamestateUndo(){
			// we don't actually need to overwrite anything, since it will be overwritten when the data is added back. Just roll back the indices.
			GamestateIndex--;
			GamestateShadowIndex -= 2;
			return;
		}//BitboardUndo
		
		#endregion gamestate manipulation
		
		#region move logic
		
		
		
		#endregion move logic
		
	}// end class Bitgame
}// end namespace ZBCvr