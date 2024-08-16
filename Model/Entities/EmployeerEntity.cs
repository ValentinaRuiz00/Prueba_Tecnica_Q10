namespace Model.Entities
{
    public class EmployeerEntity
    {
        //Modelo de la base de datos Employeers
        public int IdEmployeers { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Office { get; set; }
        public decimal Salary { get; set; }
    }
}
