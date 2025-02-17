namespace AspnetCoreMvcStarter.Models.Enums
{
  public enum UserRole
  {
    EndUser,
    FacilityHead,
    Assignee,
    Admin
  }

  public enum RequestStatus
  {
    Open,
    Assigned,
    InProgress,
    NeedMoreInfo,
    Rejected,
    Closed
  }

  public enum SeverityLevel
  {
    Low,
    Medium,
    High,
    Critical
  }

  public enum BorrowStatus
  {
    Borrowed,
    Returned
  }
}
