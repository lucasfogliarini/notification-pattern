namespace NotificationPattern
{
    public class TransferInput
    {
        public decimal Value { get; set; }
        public string FromAccountCpf { get; set; }
        public string ToAccountCpf { get; set; }
        internal Account FromAccount { get; set; }
        internal Account ToAccount { get; set; }
    }
}