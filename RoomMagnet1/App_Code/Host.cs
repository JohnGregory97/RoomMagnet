using System;

public class Host
{
    private int hostID;
    private String firstName;
    private String lastName;
    private String hostEmail;
    private String houseNumber;
    private String street;
    private String city;
    private String state;
    private String country;
    private String zip;
    private String password;
    private String phoneNumber;
    private String lastUpdated;
    private DateTime birthDate;
    private int accomodationID;
   

    public Host()
    {
        this.hostID = 0;
        this.firstName = String.Empty;
        this.lastName = String.Empty; ;
        this.hostEmail = String.Empty; ;
        this.houseNumber = String.Empty; ;
        this.street = String.Empty; ;
        this.city = String.Empty; ;
        this.state = String.Empty; ;
        this.country = String.Empty; ;
        this.zip = String.Empty; ;
        this.phoneNumber = String.Empty; ;
        this.lastUpdated = String.Empty; ;
        this.accomodationID = 0;
    }

    public Host(int hostID, String firstName, String lastName, String hostEmail, String houseNumber, String street, String city, String state, 
        String country, String zip, String phoneNumber, String lastUpdated, int accomodationID)
	{
        this.hostID = hostID;
        this.firstName = firstName;
        this.lastName = lastName;
        this.hostEmail = hostEmail;
        this.houseNumber = houseNumber;
        this.street = street;
        this.city = city;
        this.state = state;
        this.country = country;
        this.zip = zip;
        this.phoneNumber = phoneNumber;
        this.lastUpdated = lastUpdated;
        this.accomodationID = accomodationID;
	}

    public DateTime GetBirthDate()
    {
        return this.birthDate;
    }

    public void SetBirthDate(DateTime dob)
    {
        this.birthDate = dob;
    }

    public void SetPassword(String password)
    {
        this.password = password;
    }

    public void setHostID(int hostID)
    {
        this.hostID = hostID;
    }

    public void SetFirstName(String firstName)
    {
        this.firstName = firstName;
    }

    public void SetLastName(String lastName)
    {
        this.lastName = lastName;
    }

    public void SetHostEmail(String email)
    {
        this.hostEmail = email;
    }

    public void SetHouseNumber(String houseNum)
    {
        this.houseNumber = houseNum;
    }

    public void SetStreet(String street)
    {
        this.street = street;
    }

    public void SetCity(String city)
    {
        this.city = city;
    }

    public void SetState(String state)
    {
        this.state = state;
    }

    public void SetCountry(String country)
    {
        this.country = country;
    }

    public void SetZip(String zip)
    {
        this.zip = zip;
    }

    public void SetPhoneNumber(String phoneNum)
    {
        this.phoneNumber = phoneNum;
    }

    public void SetLastUpdated(String lastUpdated)
    {
        this.lastUpdated = lastUpdated;
    }

    public void SetAccomodationID(int accomID)
    {
        this.accomodationID = accomID;
    }

    public String GetPassword()
    {
        return this.password;
    }

    public int GetHostID()
    {
        return this.hostID;
    }

    public String GetFistName()
    {
        return this.firstName;
    }

    public String GetLastName()
    {
        return this.lastName;
    }

    public String GetHostEmail()
    {
        return this.hostEmail;
    }

    public String GetHouseNumber()
    {
        return this.houseNumber;
    }
    
    public String GetStreet()
    {
        return this.street;
    }

    public String GetCity()
    {
        return this.city;
    }

    public String GetState()
    {
        return this.state;
    }

    public String GetCountry()
    {
        return this.country;
    }

    public String GetZip()
    {
        return this.zip;
    }

    public String GetPhoneNumber()
    {
        return this.phoneNumber;
    }

    public int GetAccomodationID()
    {
        return this.accomodationID;
    }
}
