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

        [JsonPropertyName("from_wallet_id")]
        [Required]
        public Guid? FromWalletId { get; set; }

        [JsonPropertyName("to_wallet_id")]
        [Required]
        public Guid? ToWalletId { get; set; }

        [JsonPropertyName("amount")]
        [Required]
        public decimal? Amount { get; set; }

        [JsonPropertyName("current_status")]
        public TransactionStatus CurrentStatus { get; set; }

        [JsonPropertyName("observations")]
        public List<string>? Observations { get; set; } = [];
    }
}
