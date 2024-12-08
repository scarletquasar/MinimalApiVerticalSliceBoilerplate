using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MinimalApiVerticalSliceBoilerplate.Shared.Models.Financial
{
    [Index(nameof(PublicId))]
    [Index(nameof(Id))]
    [Index(nameof(Version))]
    [Index(nameof(Balance))]
    public class Wallet
    {
        [Key, Column(Order = 0)]
        [JsonIgnore]
        public long Id { get; set; }

        [Key, Column(Order = 1)]
        [JsonPropertyName("version")]
        public DateTimeOffset Version { get; }

        [JsonPropertyName("id")]
        public Guid? PublicId { get; } = Guid.NewGuid();

        [JsonPropertyName("balance")]
        [Required]
        public decimal? Balance { get; set; }
    }
}
