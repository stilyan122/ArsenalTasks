namespace _04._02._2025
{
    public class Player
    {
		private string position = string.Empty;
		private string name = string.Empty;

        public Player(string position, string name)
        {
            this.Position = position;
            this.Name = name;
        }

        public string Position
		{
			get { return position; }
			set 
			{
				if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Player position is invalid!");
				}

				position = value; 
			}
		}

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Player name is invalid!");
                }

                name = value;
            }
        }
    }
}
