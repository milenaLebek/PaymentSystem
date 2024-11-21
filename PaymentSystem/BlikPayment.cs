namespace PaymentSystem;

public class BlikPayment : IMobilePayment
{
    private readonly int _amount;
    private readonly string _phoneNumber;

    public BlikPayment(int amount, string phoneNumber)
    {
        _amount = amount;
        _phoneNumber = phoneNumber;
    }

    public int Amount() => _amount;
    public string PhoneNumber() => _phoneNumber;
}