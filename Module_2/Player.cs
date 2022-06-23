using System;

namespace Module_2
{
    public class Player
    {
		public int Rating { get; }
		public string NickName { get; }

		public Player(int rating, string nickName)
		{
			Rating = rating;
			NickName = nickName;
		}
		public Player() { }
	}
}
