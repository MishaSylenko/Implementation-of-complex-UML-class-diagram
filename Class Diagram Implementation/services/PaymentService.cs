using BYT_03.data;
using BYT_03.entities;
using BYT_03.exceptions;
using BYT_03.exceptions.payment;

namespace BYT_03.services
{
    public class PaymentService
    {
        public void AddPayment(Payment payment)
        {
            if (payment.Order.OrderId <= 0)
            {
                throw new ArgumentException("OrderId must be a positive number.");
            }

            if (payment.Date < DateTime.Today || payment.Date > DateTime.Today)
            {
                throw new ArgumentException("Date cannot be in the past or future; it must be today's date.");
            }

            Storage.Payments.Remove(payment.PaymentId);
            Storage.Payments.Add(payment.PaymentId, payment);
            Storage.SaveChanges();
        }

        public void AddPayments(List<Payment> payments)
        {
            foreach (var payment in payments)
            {
                AddPayment(payment);
            }

            Storage.SaveChanges();
        }

        public Payment GetPaymentById(long id)
        {
            if (Storage.Payments.ContainsKey(id))
            {
                return new Payment(Storage.Payments[id]);
            }

            throw new PaymentNotFoundException($"Payment with id {id} not found");
        }

        public int GetPaymentsCount()
        {
            return Storage.Payments.Count;
        }

        public void RemovePayment(long id)
        {
            if (Storage.Payments.ContainsKey(id))
            {
                Storage.Payments.Remove(id);
                Storage.SaveChanges();
                return;
            }

            throw new PaymentNotFoundException($"Payment with id {id} not found");
        }

        public Dictionary<long, Payment> GetAllPayments()
        {
            return Storage.Payments.ToDictionary(idPayment => idPayment.Key, idPayment => new Payment(idPayment.Value));
        }
    }
}