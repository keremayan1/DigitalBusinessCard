namespace Domain.Entities.Concrete
{
    public class Province
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Area { get; set; }
        public long Population { get; set; }
        public int Altitude { get; set; }
        public bool IsMetropolitan { get; set; }
        public List<Districts> Districts { get; set; }

    }
}
