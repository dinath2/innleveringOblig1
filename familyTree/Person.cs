using System;

public class Person
{
        public int Id;
        public string FirstName;
        public string LastName;
        public int BirthYear;
        public int DeathYear;
        public Person Father;
        public Person Mother;

    public string GetDescription()

    {
        string bb = string.Empty;
        if (FirstName != null) bb += FirstName + " ";
        if (LastName != null) bb += LastName + " ";
        if (Id != 0) bb += "(Id=" + Id + ")";
        // bb += "(Id=" + Id + ") ";
        if (BirthYear != 0) bb += " Født: " + BirthYear + " ";
        if (DeathYear != 0) bb += "Død: " + DeathYear + " ";
        if (Father != null) bb += "Far: " + Father.FirstName + " (Id=" + Father.Id + ")";
        if (Mother != null) bb += " Mor: " + Mother.FirstName + " (Id=" + Mother.Id + ")";
        return bb;
    }
}
