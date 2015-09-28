﻿namespace Statistics.Domain
{
    public class Card
    {
        public int CardId { get; set; }
        public int UserId { get; set; }
        public string CardName { get; set; }
        public string Edition { get; set; }
        public int Quantity { get; set; }
        public string Features { get; set; }
        public bool IsForSale { get; set; }
        public UserProfile Owner { get; set; }
    }
}