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
#region API

//protected override void OnModelCreating(ModelBuilder modelBuilder)
//{
//    modelBuilder.Entity<student>(entity =>
//    {
//        entity.ToTable("Students");
//        entity.HasKey(e => e.Studentid);
//        entity.Property(e => e.FName).IsRequired().HasMaxLength(100);
//        entity.Property(e => e.Lname).IsRequired().HasMaxLength(100);
//        entity.Property(e => e.age).IsRequired();
//        entity.Property(e => e.address).HasMaxLength(100);
//    });

//    modelBuilder.Entity<course>(entity =>
//    {
//        entity.ToTable("Courses");
//        entity.HasKey(e => e.Id);
//        entity.Property(e => e.cname).IsRequired().HasMaxLength(100);
//        entity.Property(e => e.description).IsRequired();
//        entity.Property(e => e.duration).IsRequired();

//    });

//    modelBuilder.Entity<instructor>(entity =>
//    {
//        entity.ToTable("Instructors");
//        entity.HasKey(e => e.Id);
//        entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
//        entity.Property(e => e.bonus).HasMaxLength(100);
//        entity.Property(e => e.salary).HasMaxLength(50);
//    });

//    modelBuilder.Entity<department>(entity =>
//    {
//        entity.ToTable("Departments");
//        entity.HasKey(e => e.Departmentid);
//        entity.Property(e => e.DName).IsRequired().HasMaxLength(100);
//    });

//    modelBuilder.Entity<topic>(entity =>
//    {
//        entity.ToTable("Topics");
//        entity.HasKey(e => e.Topicid);
//        entity.Property(e => e.tname).IsRequired().HasMaxLength(100);
//    });
#endregion

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
public static void Main(string[] args) {
using iti context = new iti();
#region insert
student student01 = new student() { FName = "george", Lname = "ragaee", address = "benisuef", age = 77 };
context.students.Add(student01);
Console.WriteLine(context.Entry(student01).State);
#endregion
#region update
var studentt = (from e in context.students where e.Studentid == 10 select e).FirstOrDefault();
if (studentt != null)
{
    Console.WriteLine(context.Entry(studentt).State);
    studentt.FName = "george";
    context.SaveChanges();
    Console.WriteLine(context.Entry(studentt).State);
}
#endregion
#region delete

var student = (from e in context.students where e.Studentid == 5 select e).FirstOrDefault();
if (student != null)
{
    context.students.Remove(student);
    context.SaveChanges();
}

#endregion
} 



}


