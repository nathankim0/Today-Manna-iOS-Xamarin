﻿using SQLite;
namespace TodaysManna.Models
{
    public class MemoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Verse { get; set; }
        public string Note { get; set; }
    }
}