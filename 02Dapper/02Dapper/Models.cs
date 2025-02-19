namespace _02Dapper
{
	public class User
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Mail { get; set; }
		public string Password { get; set; }
		public string Phone { get; set; }
		public DateTime LastOnline { get; set; }
	}

	public class BattleHistory
	{
		public int Id { get; set; }
		public int AttackerId { get; set; }
		public int AttackerLosses { get; set; }
		public int DefenderId { get; set; }
		public int DefenderLosses { get; set; }
		public bool SuccessOfDefend { get; set; }
		public DateTime BattleDate { get; set; }
	}

	public class UserStatistic
	{
		public int UserId { get; set; }
		public int Wins { get; set; }
		public int Losses { get; set; }
		public int Kills { get; set; }
		public int Rating { get; set; }
	}

	public class CastleLevel
	{
		public int UserId { get; set; }
		public int Walls { get; set; }
		public int Barracks { get; set; }
		public int Farm { get; set; }
		public int Sawmill { get; set; }
		public int Quarry { get; set; }
		public int Mines { get; set; }
	}

	public class Resource
	{
		public int CastleId { get; set; }
		public int Money { get; set; }
		public int Wood { get; set; }
		public int Stone { get; set; }
		public int Iron { get; set; }
	}

	public class Army
	{
		public int CastleId { get; set; }
		public int Infantry { get; set; }
		public int Archers { get; set; }
		public int Knights { get; set; }
	}
}
