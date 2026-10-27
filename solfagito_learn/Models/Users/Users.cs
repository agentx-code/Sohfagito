using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace solfagito_learn.Models.Users
{
    [Table("tbl_users")]
    public class Users
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(150)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        [Column("password")]
        public string Password { get; set; } = string.Empty;

        [StringLength(20)]
        [Column("phone")]
        public string? Phone { get; set; }

        [Required]
        [Column("role_id")]
        public Guid RoleId { get; set; }

        [StringLength(20)]
        [Column("status")]
        public string? Status { get; set; }

        [Column("is_deleted")]
        public bool? IsDeleted { get; set; }

        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [StringLength(6)]
        [Column("reset_otp")]
        public string? ResetOtp { get; set; }

        [Column("reset_otp_expiry")]
        public DateTime? ResetOtpExpiry { get; set; }


        public Roles Role { get; set; }
    }
}
