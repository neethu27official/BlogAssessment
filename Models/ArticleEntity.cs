using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace BlogAssessment.Models
{
    public class ArticleEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 0)]
        [JsonProperty(PropertyName = "id")]
        public Guid ID { get; set; }
        [Column(Order = 1)]
        [JsonProperty(PropertyName = "lastUpdated")]
        public DateTime LastUpdated { get; set; }
        [Column(Order = 2)]
        [MaxLength(100)]
        [Required]
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [Column(Order = 3)]
        [JsonProperty(PropertyName = "author")]
        public string Author { get; set; }
        [Column(Order = 4)]
        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }
        [Column(Order = 5)]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        [Column(Order = 6)]
        [JsonProperty(PropertyName = "mobileNo")]
        public string Mobileno { get; set; }

    }
}