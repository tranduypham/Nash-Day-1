// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Memember m1 = new Memember();
Memember m2 = new Memember();
Memember m3 = new Memember();
Memember m4 = new Memember();
Memember m5 = new Memember();
Memember m6 = new Memember();
List<Memember> team = new List<Memember>();
team.Add(m1);
team.Add(m2);
team.Add(m3);
team.Add(m4);
team.Add(m5);
team.Add(m6);

int maxAge = m1.Age;
List<Memember> maleTeam = new List<Memember>();
List<String> fullName = new List<String>();
List<Memember> is2000 = new List<Memember>();
List<Memember> above2000 = new List<Memember>();
List<Memember> below2000 = new List<Memember>();

foreach(Memember m in team){
    m.showInfo();
    if(maxAge < m.Age){
        maxAge = m.Age;
    }
    if(m.Gender == 1){
        maleTeam.Add(m);
    }
    fullName.Add(m.FirstName + " " + m.LastName);
    if(m.YearOfBirth == 2000){
        is2000.Add(m);
    } else if(m.YearOfBirth > 2000) {
        above2000.Add(m);
    } else {
        below2000.Add(m);
    }
}

Console.WriteLine("Memember co tuoi cao nhat la : ");
foreach(Memember m in team){
    if(maxAge == m.Age){
        m.showInfo();
        break;
    }
}
Console.WriteLine("Memember co gender la male : ");
foreach(Memember m in maleTeam){
    m.showInfo();
}
Console.WriteLine("List of full name : ");
foreach(String name in fullName){
    Console.Write(name + " --- ");
}
Console.WriteLine("\nFirst born in Hanoi : ");
foreach(Memember m in team){
    if(m.BirthPlace == "Ha noi"){
        m.showInfo();
        break;
    }
}
Console.WriteLine("Born in 2000 : ");
foreach(Memember m in is2000){
    m.showInfo();
}
Console.WriteLine("Born after 2000 : ");
foreach(Memember m in below2000){
    m.showInfo();
}
Console.WriteLine("Born before 2000 : ");
foreach(Memember m in above2000){
    m.showInfo();
}


class Memember {
    String firstName;
    String lastName;
    int gender;
    String dateOfBirth;
    String phoneNumber;
    String birthPlace;
    int age;
    int isGraduated;
    private static int year = 1999;
    private static int gen = 0;

    public Memember(){
        firstName = "A";
        lastName = "B";
        gender = (gen + 1) % 2;
        dateOfBirth = year + "/12/24";
        phoneNumber = "0946301025";
        birthPlace = "Ha noi";
        age = ageCal(dateOfBirth);
        isGraduated = 0;

        year++;
        gen = gender;
    }
    public Memember(int age){
        this.age = age;
    }
    private int ageCal(String dateOfBirht) {
        DateTime date = Convert.ToDateTime(dateOfBirht);
        DateTime now = DateTime.Now;
        int age = now.Year - date.Year;
        // Console.WriteLine(age);
        return age;
    }

    public void showInfo() {
        Console.WriteLine("Full-Name: " + firstName + " " + lastName + " Age: " + age + " Gender: " + (gender==0 ? "Female" : "Male"));
    }

    public int Age {
        get{
            return age;
        }
        set {
            age = value;
        }
    }
    public int Gender {
        get{
            return gender;
        }
        set {
            gender = value;
        }
    }
    public String LastName {
        get{
            return lastName;
        }
        set {
            lastName = value;
        }
    }
    public String FirstName {
        get{
            return firstName;
        }
        set {
            firstName = value;
        }
    }
    public String BirthPlace {
        get{
            return birthPlace;
        }
        set {
            birthPlace = value;
        }
    }
    public String DateOfBirth {
        get{
            return dateOfBirth;
        }
        set {
            dateOfBirth = value;
        }
    }
    public int YearOfBirth {
        get{
            DateTime date = Convert.ToDateTime(dateOfBirth);
            return date.Year;
        }
    }
}