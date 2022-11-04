 public interface IAuditedModel
    {
        public string CreatedByUserId { get; set; }
        public string CreatedDate { get; set; }
        public string LastModifiedUserId { get; set; }
        public string LastModifiedDate { get; set; }
    }