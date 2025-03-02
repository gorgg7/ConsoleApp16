using Microsoft.EntityFrameworkCore;

public class student
{
    public int Studentid { get; set; }
    public string FName { get; set; }
    public string Lname { get; set; }
    public string address {  get; set; }    
    public int age {  get; set; }

}
public class course
{
    public int Id { get; set; }
    public int duration { get; set; }
    public string cname { get; set; }
    public string description { get; set; }

}
public class instructor
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string bonus { get; set; }
    public int salary { get; set; }
    public string address { get; set; }
    public int hourrate { get; set; }

}
public class department
{
    public int Departmentid { get; set; }
    public string DName { get; set; }
}
public class topic
{
    public int Topicid { get; set; }
    public string tname { get; set; }
}
public class iti : DbContext
{ 
 
 
    public DbSet<student> students { get; set; }
    public DbSet<course> courses { get; set; }
    public DbSet<instructor> instructors { get; set; }
    public DbSet<department> departments { get; set; }
    public DbSet<topic> topic { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=GORGG;database=itief;trusted_connection=true;trustServerCertificate=true");
    }
}
class program {
public static void Main(string[] args) {

} 



}


