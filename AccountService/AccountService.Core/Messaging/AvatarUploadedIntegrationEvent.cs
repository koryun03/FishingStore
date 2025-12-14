namespace AccountService.Core.Messaging;

public record AvatarUploadedIntegrationEvent(Guid FileId, string BucketName);