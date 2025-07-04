using System;
using System.Text.Json.Serialization;
using BYT_03.entities.enums;

namespace BYT_03.entities
{
    [Serializable()]
    public class Payment
    {
        private static long _id = 0;
        public long PaymentId { get; set; } = ++_id;
        public DateTime Date { get; init; }
        public PaymentMethod PaymentMethod { get; init; } = PaymentMethod.Card;
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.NotStarted;
        [JsonIgnore] public Order? Order { get; set; }

        public static void SetStaticId(long id)
        {
            _id = id;
        }

        public Payment()
        {
        }

        public Payment(Payment payment)
        {
            PaymentId = payment.PaymentId;
            Date = payment.Date;
            PaymentMethod = payment.PaymentMethod;
            PaymentStatus = payment.PaymentStatus;
            Order = payment.Order;
        }

        public void SetOrder(Order order)
        {
            ArgumentNullException.ThrowIfNull(order, nameof(order));
            Order = order;
        }

        public void UnsetOrder()
        {
            Order = null;
        }
    }
}