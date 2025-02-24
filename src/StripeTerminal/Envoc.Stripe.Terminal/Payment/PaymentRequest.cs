﻿using StripeTerminal.Helpers;

namespace StripeTerminal.Payment
{
    public class PaymentRequest
    {
        public PaymentRequest(decimal amount, Dictionary<string, string> metadata, string paymentIntentSecret = null, string currency = null)
        {
            Amount = amount;
            Metadata = metadata;
            PaymentIntentSecret = paymentIntentSecret;
            Currency = string.IsNullOrWhiteSpace(currency) ? "usd" : currency;
        }

        public decimal Amount { get; }
        public string Currency { get; set; }

        public string PaymentIntentSecret { get; }

        public Dictionary<string, string> Metadata { get; }

        //Amounts have to be whole numbers
        //https://stripe.com/docs/currencies#zero-decimal
        public nuint GetAmount() => CalculationHelper.GetAmount(Amount);
    }
}