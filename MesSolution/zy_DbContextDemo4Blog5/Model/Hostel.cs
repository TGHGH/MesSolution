namespace DbContexts.Model
{
    /// <summary>
    /// 宿舍类
    /// </summary>
    public class Hostel : Lodging
    {
        public int MaxPersonsPerRoom { get; set; }
        public bool PrivateRoomsAvailable { get; set; }
    }
}
