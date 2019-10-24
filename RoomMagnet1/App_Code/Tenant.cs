using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// Tenant Class
/// Information included:
/// Name, Date of Birth, Current Address, Account Password, type of Tenant
/// 
public class Tenant
{
    private int tenantID;
    private string firstName;
    private string lastName;
    private string houseNumber;
    private string street;
    private string city;
    private string zip;
    private string state;
    private string country;
    private string email;
    private string phoneNumber;
    private string password;
    private DateTime birthDate;
    private string tenantType;
    public Tenant()
    {
        
    }
    public void SetTenantID(int tenantID)
    {
        this.tenantID = tenantID;
    }
    public int GetTenantID()
    {
        return this.tenantID;
    }
    public void SetFirstName(string firstName)
    {
        this.firstName = firstName;
    }
    public string GetFirstName()
    {
        return this.firstName;
    }
    public void SetLastName(string lastName)
    {
        this.lastName = lastName;
    }
    public string GetLastName()
    {
        return this.lastName;
    }
    public void SetHouseNumber(string houseNumber)
    {
        this.houseNumber = houseNumber;
    }

    public string GetHouseNumber()
    {
        return this.houseNumber;
    }

    public void SetStreet(string street)
    {
        this.street = street;
    }
    public string GetStreet()
    {
        return this.street;
    }
    public void SetCity(string city)
    {
        this.city = city;
    }
    public string GetCity()
    {
        return this.city;
    }
    public void SetZip(string zip)
    {
        this.zip = zip;
    }
    public string GetZip()
    {
        return this.zip;
    }
    public void SetState(string state)
    {
        this.state = state;
    }
    public string GetState()
    {
        return this.state;
    }
    public void SetCountry(string country)
    {
        this.country = country;
    }
    public string GetCountry()
    {
        return this.country;
    }

    public void SetEmail(string email)
    {
        this.email = email;
    }
    public string GetEmail()
    {
        return this.email;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        this.phoneNumber = phoneNumber;
    }
    public string GetPhoneNumber()
    {
        return this.phoneNumber;
    }
    public void SetPassword(string password)
    {
        this.password = password;
    }
    public string GetPassword()
    {
        return this.password;
    }
    public void SetBirthDate(DateTime birthDate)
    {
        this.birthDate = birthDate;
    }
    public DateTime GetBirthDate()
    {
        return this.birthDate;
    }
    public void SetTenantType(string tenantType)
    {
        this.tenantType = tenantType;
    }
    public string GetTenantType()
    {
        return this.tenantType;
    }
}