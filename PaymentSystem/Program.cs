using System;
using PaymentSystem;

class Program
{
    static void Main(string[] args)
    {
        // Płatność SWIFT
        IBankPayment swiftPayment = new SwiftPayment(1500, "PL60102010260000042270201111");
        PaymentService paymentService = new PaymentService();
        paymentService.ProcessPayment(swiftPayment);

        // Płatność BLIK
        IMobilePayment blikPayment = new BlikPayment(250, "123456789");
        IBankPayment paymentAdapter = new MobileToBankPaymentAdapter(blikPayment);
        paymentService.ProcessPayment(paymentAdapter);
    }
}