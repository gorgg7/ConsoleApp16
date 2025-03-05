public class student
{
    public int Studentid { get; set; }
    public string FName { get; set; }
    public string Lname { get; set; }
    public string address {  get; set; }    
    public int age {  get; set; }
    public int departmentid { get; set; }
    public department department { get; set; }
    public ICollection<studentcourse> studentcourses { get; set; }


}
public class course
{
    public int Id { get; set; }
    public int duration { get; set; }
    public string cname { get; set; }
    public string description { get; set; }
    public int topicid {  get; set; }
    public topic topic { get; set; }
    public ICollection<courseinstructor> courseinstructors { get; set; }
    public ICollection<studentcourse> studentcourses { get; set; }

}
public class instructor
{
    public int Instructorid { get; set; }
    public string Name { get; set; }
    public string bonus { get; set; }
    public int salary { get; set; }
    public string address { get; set; }
    public int hourrate { get; set; }
    public int departmentid { get; set; }
    public department department{ get; set; }
    public ICollection<courseinstructor> courseinstructors { get; set; }

}
public class department
{
    public int Departmentid { get; set; }
    public string DName { get; set; }
    public DateTime hiringdate { get; set; }
    public ICollection<student> students { get; set; }
    public int instructorid {  get; set; }
    public ICollection<instructor> instructors { get; set; }

}
public class topic
{
    public int Topicid { get; set; }
    public string tname { get; set; }
    public ICollection<course>courses { get; set; }
}
public class studentcourse
{
    public int studentid { get; set; }
    public int courseid { get; set; }

    public int grade { get; set; }
    public student student { get; set; }
    public course course { get; set; }

}
public class courseinstructor
{
    public int instructorid { get; set; }
    public int courseid { get; set; }
    public int evaluate { get; set; }
    public course course { get; set; }
    public instructor instructor { get; set; }
}
public class iti : DbContext


{
    public DbSet<student> students { get; set; }
    public DbSet<course> courses { get; set; }
    public DbSet<instructor> instructors { get; set; }
    public DbSet<department> department { get; set; }
    public DbSet<topic> topic { get; set; }
    public DbSet<studentcourse> studentcourses { get; set; }
    public DbSet<courseinstructor>courseinstructors { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<courseinstructor>()
            .HasKey(ci => new { ci.courseid, ci.instructorid });

        modelBuilder.Entity<courseinstructor>()
            .HasOne(ci => ci.course)
            .WithMany(c => c.courseinstructors)
            .HasForeignKey(ci => ci.courseid);

        modelBuilder.Entity<courseinstructor>()
            .HasOne(ci => ci.instructor)
            .WithMany(i => i.courseinstructors)
            .HasForeignKey(ci => ci.instructorid);

        modelBuilder.Entity<studentcourse>().HasKey(sc => new { sc.courseid, sc.studentid });
        modelBuilder.Entity<studentcourse>().HasOne(sc => sc.student).WithMany(s => s.studentcourses).HasForeignKey(sc => sc.studentid);
        modelBuilder.Entity<studentcourse>().HasOne(sc=>sc.course).WithMany(s => s.studentcourses).HasForeignKey(sc=>sc.courseid);

    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("server=GORGG;database=itieff;trusted_connection=true;trustServerCertificate=true");
    }
}
class program {

} 



}


