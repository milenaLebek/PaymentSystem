namespace PaymentSystem;
using System;
using System.IO;

public class PaymentService
{
    public void ProcessPayment(IBankPayment payment)
    {
        if (payment.Amount() <= 0)
        {
            Console.WriteLine("Błąd: Kwota płatności musi być większa niż 0.");
            return;
        }

        if (!ValidateBankAccount(payment.BankAccount()))
        {
            Console.WriteLine("Błąd: Nieprawidłowy numer konta bankowego.");
            return;
        }

        Console.WriteLine($"Przetwarzanie płatności: {payment.Amount()} PLN na konto {payment.BankAccount()}");
        LogTransaction(payment);
    }

    private bool ValidateBankAccount(string bankAccount)
    {
        return bankAccount.StartsWith("PL") && bankAccount.Length == 28 && long.TryParse(bankAccount.Substring(2), out _);
    }

    private void LogTransaction(IBankPayment payment)
    {
        string logEntry = $"{DateTime.Now}: Płatność {payment.Amount()} PLN na konto {payment.BankAccount()}\n";
        File.AppendAllText("transactions.log", logEntry);
    }
}