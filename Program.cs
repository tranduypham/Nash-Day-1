// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// Generate dữ liệu lại cho phong phú
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

/**
* Show male list
* @param List<Memember>
* @return List<Mememeber>
*/
List<Memember> showMaleList(List<Memember> l){
    List<Memember> maleTeam = new List<Memember>();
    foreach(Memember m in l){
        if(m.Gender == 1){
            maleTeam.Add(m);
        }
    }
    return maleTeam;
}

/**
* Show oldest memember
* @param List<Memember>
* @return Mememeber
*/
Memember showOldest(List<Memember> l){
    int maxAge = l[0].Age;
    int maxAgeIndex = 0;
    foreach(Memember m in l){
        if(maxAge < m.Age){
            maxAge = m.Age;
            maxAgeIndex = l.IndexOf(m);
        }
    }
    return l[maxAgeIndex];
}

/**
* Show fullname List
* @param List<Memember>
* @return List<String>
*/
List<String> showFullName(List<Memember> l){
    List<String> fullName = new List<String>();
    foreach(Memember m in l){
        fullName.Add(m.FirstName + " " + m.LastName);
    }
    return fullName;
}

/**
* Show age into group
* @param List<Memember>
* @return List<Memember>[]
*/
List<Memember>[] showAgeGroup(List<Memember> l){
    List<Memember> is2000 = new List<Memember>();
    List<Memember> above2000 = new List<Memember>();
    List<Memember> below2000 = new List<Memember>();
    foreach(Memember m in l){
        switch(m.YearOfBirth){
            case 2000:{
                is2000.Add(m);
                break;
            }
            case int value when value > 2000:{
                above2000.Add(m);
                break;
            }
            case int value when value < 2000:{
                below2000.Add(m);
                break;
            }
            default:{
                break;
            }
        }
    }
    return new List<Memember>[]{
        is2000,
        above2000,
        below2000
    };
}

/**
* Show first memember from Ha noi
* @param List<Memember>
* @return Mememeber
*/
Memember showFirstHanoi(List<Memember> l){
    foreach(Memember m in l){
        if(m.BirthPlace == "Ha noi"){
            return m;
        }
    }
    return null;
}

Console.WriteLine("Memember co tuoi cao nhat la : ");
Memember oldestMemember = showOldest(team);
oldestMemember.showInfo();

Console.WriteLine("Memember co gender la male : ");
foreach(Memember m in showMaleList(team)){
    m.showInfo();
}

Console.WriteLine("List of full name : ");
foreach(String name in showFullName(team)){
    Console.Write(name + " --- ");
}

Console.WriteLine("\nFirst born in Hanoi : ");
showFirstHanoi(team).showInfo();

List<Memember>[] arrAge = showAgeGroup(team);
Console.WriteLine("Born in 2000 : ");
foreach(Memember m in arrAge[0]){
    m.showInfo();
}
Console.WriteLine("Born after 2000 : ");
foreach(Memember m in arrAge[2]){
    m.showInfo();
}
Console.WriteLine("Born before 2000 : ");
foreach(Memember m in arrAge[1]){
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
    private String[] city = new String[]{"Ha noi", "Hai Duong", "Nam Dinh", "Hai Phong", "Hue"};
    private static int cityIndex = 0;

    public Memember(){
        firstName = "A";
        lastName = "B";
        gender = (gen + 1) % 2;
        dateOfBirth = year + "/12/24";
        phoneNumber = "0946301025";
        birthPlace = this.city[cityIndex];
        age = ageCal(dateOfBirth);
        isGraduated = 0;

        year++;
        gen = gender;
        cityIndex = (cityIndex + 1) % city.Length;
    }
    public Memember(int age){
        this.age = age;
    }
    private int ageCal(String dateOfBirht) {
        DateTime date = Convert.ToDateTime(dateOfBirht);
        DateTime now = DateTime.Now;
        int age = now.Year - date.Year;
        return age;
    }

    public void showInfo() {
        Console.WriteLine("Full-Name: {0} {1} Age: {2} Gender: {3} City: {4}", firstName, lastName, age, (gender==0 ? "Female" : "Male"), birthPlace);
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