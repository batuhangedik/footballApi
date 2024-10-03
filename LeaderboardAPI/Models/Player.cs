namespace Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string DeviceId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int Level { get; set; } = 1;
        public int TrophyCount { get; set; } = 0;
    }   
}
