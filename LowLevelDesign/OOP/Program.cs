using LowLevelDesign.OOP;
using LowLevelDesign.OOP.Checout;
using LowLevelDesign.OOP.Payment;

EmailService em =  new EmailService();
em.sendEmail();

//CreditCard cc = new CreditCard();
//cc.process(100);

//PayPalPayment payPalPayment = new PayPalPayment();
//payPalPayment.process(100);

string method = "Paypal";

IPayment payment;
if (method == "Paypal")
{
    payment = new PayPalPayment();
}
else
{
    payment = new CreditCard();
}
CheckoutService cs = new CheckoutService(payment);
cs.CompleteOrder(100);