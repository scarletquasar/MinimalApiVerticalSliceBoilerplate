using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MinimalApiVerticalSliceBoilerplate.Shared.Models.Financial
{
    public enum TransactionStatus
    {
        FailedToCreate,
        Created,
        FailedToSend,
        Sent
    }

    [Index(nameof(PublicId))]
    [Index(nameof(Id))]
    [Index(nameof(Version))]
    [Index(nameof(Amount))]
    [Index(nameof(CurrentStatus))]
    public class Transaction
    {
        [Key, Column(Order = 0)]
        [JsonIgnore]
        public long Id { get; set; }

        [Key, Column(Order = 1)]
        [JsonPropertyName("version")]
        public DateTimeOffset Version { get; }

        [JsonPropertyName("id")]
        public Guid? PublicId { get; } = Guid.NewGuid();

        [JsonPropertyName("from_id")]
        [Required]
        public Guid? FromId { get; set; }

        [JsonPropertyName("to_id")]
        [Required]
        public Guid? ToId { get; set; }

        [JsonPropertyName("amount")]
        [Required]
        public decimal? Amount { get; set; }

        [JsonPropertyName("current_status")]
        public TransactionStatus CurrentStatus { get; set; }
    }
}
