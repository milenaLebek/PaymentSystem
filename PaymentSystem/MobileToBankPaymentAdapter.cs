namespace PaymentSystem;

public class MobileToBankPaymentAdapter : IBankPayment
{
    private readonly IMobilePayment _mobilePayment;

    public MobileToBankPaymentAdapter(IMobilePayment mobilePayment)
    {
        _mobilePayment = mobilePayment;
    }

    public int Amount() => _mobilePayment.Amount();

    public string BankAccount()
    {
        string phone = _mobilePayment.PhoneNumber();
        return "PL000000000000000000" + phone[^6..];
    }

}