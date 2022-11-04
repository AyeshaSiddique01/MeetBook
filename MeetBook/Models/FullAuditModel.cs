using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

public abstract class FullAuditModel : IAuditedModel, IActivatableModel, ISoftDeletable
{
    public string CreatedByUserId { get; set; }
    public string CreatedDate { get; set; }
    public string LastModifiedUserId { get; set; }
    public string LastModifiedDate { get; set; }
    public bool IsActive { get; set; }
    [Required]
    [DefaultValue(false)]
    public bool IsDeleted { get; set; }

}