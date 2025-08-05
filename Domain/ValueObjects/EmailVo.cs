using Domain.Exceptions;

namespace Domain.ValueObjects;

public class EmailVo
{
    public string Address { get; private set; }
    public EmailVo(string address)
    {
        Address = address;
        Validate();
    }

    private void Validate()
    {
        if (!IsValid())
        {
            throw new InvalidEmailException("Invalid Email");
        }
    }

    public bool IsValid()
    {
        return !string.IsNullOrEmpty(Address) && Address.Contains("@");
    }

    //SOLID - OCP
    //public bool IsValid(string address)
    //{
    //    return string.IsNullOrWhiteSpace(address);
    //}
}
