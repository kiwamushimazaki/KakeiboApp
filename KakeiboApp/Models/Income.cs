using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KakeiboApp.Models
{
    public class Income
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        [DisplayName("内容")]
        public string Name { get; set; }
        [DisplayName("日付")]
        [DisplayFormat(DataFormatString = "{0:yyyy年MM月dd日}")]
        public DateTime Date { get; set; }
        [DisplayName("値段")]
        public int Price { get; set; }
        [DisplayName("メモ")]
        public string Memo { get; set; }
    }
}